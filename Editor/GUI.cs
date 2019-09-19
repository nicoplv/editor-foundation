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

        #endregion
    }
}