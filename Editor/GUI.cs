using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorFoundations
{
    public static class GUI
    {
        #region Methods

        public static void DrawSpace(int _height = Styles.SpaceHeight)
        {
            GUILayoutUtility.GetRect(GUIContent.none, Styles.DefaultStyle, new GUILayoutOption[] { GUILayout.MinWidth(Styles.MinSpaceWidth), GUILayout.MaxWidth(Styles.MaxSpaceWidth), GUILayout.Height(_height) });
        }

        public static void DrawLine(int _thickness = Styles.LineThickness, int _topPadding = Styles.GlobalPadding, int _bottomPadding = Styles.GlobalPadding)
        {
            DrawLine(Styles.LineColor, _thickness, _topPadding, _bottomPadding);
        }

        public static void DrawLine(Color _color, int _thickness = Styles.LineThickness, int _topPadding = Styles.GlobalPadding, int _bottomPadding = Styles.GlobalPadding)
        {
            Rect bRect = GUILayoutUtility.GetRect(GUIContent.none, Styles.DefaultStyle, new GUILayoutOption[] { GUILayout.Height(_thickness + _topPadding + _bottomPadding), GUILayout.MinWidth(Styles.MinSpaceWidth) });
            bRect.height = _thickness;
            bRect.y += _topPadding;
            EditorGUI.DrawRect(bRect, _color);
        }

        public static T DrawSelectableList<T>(T _current, string _currentLabel, string _typeLabel, List<T> _list, List<string> _labels, Func<T> _addCallback, Action<T> _deleteCallback) where T : UnityEngine.Object
        {
            for (int index = 0; index < _list.Count; ++index)
            {
                GUILayout.BeginHorizontal();

                GUIStyle backgroundStyle = index % 2 != 0 ? EditorFoundations.Styles.BackgroundOddStyle : EditorFoundations.Styles.BackgroundEvenStyle;
                T iT = _list[index];
                bool selected = iT == _current;
                string displayLabel = _labels[index];
                Rect rectListItem = GUILayoutUtility.GetRect(EditorGUIUtility.TrTextContent(displayLabel), EditorFoundations.Styles.DefaultStyle, new GUILayoutOption[] { GUILayout.ExpandWidth(true), GUILayout.MinWidth(EditorFoundations.Styles.MinSpaceWidth) });
                Event eventCurrent = Event.current;

                switch (eventCurrent.type)
                {
                    case EventType.MouseDown:
                        if (rectListItem.Contains(eventCurrent.mousePosition))
                        {
                            _current = iT;
                            GUIUtility.keyboardControl = 0;
                            GUIUtility.hotControl = iT.GetHashCode();
                            eventCurrent.Use();
                        }
                        break;
                    case EventType.MouseUp:
                        if (GUIUtility.hotControl == iT.GetHashCode())
                        {
                            GUIUtility.hotControl = 0;
                            eventCurrent.Use();
                        }
                        break;
                    case EventType.Repaint:
                        backgroundStyle.Draw(rectListItem, GUIContent.none, false, false, selected, false);
                        UnityEngine.GUI.Label(rectListItem, displayLabel);
                        break;
                }

                //Extra column for deleting button
                var deleteButton = GUILayoutUtility.GetRect(GUIContent.none, EditorFoundations.Styles.DefaultStyle, GUILayout.MinWidth(EditorFoundations.Styles.MinSpaceWidth), GUILayout.MaxWidth(EditorFoundations.Styles.MaxSpaceWidth));
                if (Event.current.type == EventType.Repaint)
                {
                    backgroundStyle.Draw(deleteButton, GUIContent.none, false, false, selected, false);
                }
                if (UnityEngine.GUI.Button(deleteButton, Contents.IconTrash, GUIStyle.none))
                {
                    if (EditorUtility.DisplayDialog(
                        "Delete " + _currentLabel + " " + _typeLabel + "?",
                        "Are you sure you want to delete " + _currentLabel + " " + _typeLabel + "?", "Yes", "No"))
                    {
                        _deleteCallback(iT);
                    }
                }

                GUILayout.EndHorizontal();
            }

            EditorFoundations.GUI.DrawLine(1, 10, 10);

            if (UnityEngine.GUI.Button(GUILayoutUtility.GetRect(GUIContent.none, EditorFoundations.Styles.DefaultStyle, new GUILayoutOption[] { GUILayout.ExpandWidth(true), GUILayout.MinWidth(EditorFoundations.Styles.LabelWidth) }), EditorGUIUtility.TrTextContent("Add " + _typeLabel, "Add a new " + _typeLabel + " to the list")))
            {
                _current = _addCallback();
            }

            return _current;
        }

        #endregion
    }
}