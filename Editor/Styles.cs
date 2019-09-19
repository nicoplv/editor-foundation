using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorFoundations
{
    public static class Styles
    {
        public static readonly GUIStyle DefaultStyle = "OL Toggle";

        public static readonly GUIStyle BackgroundEvenStyle = "ObjectPickerResultsOdd";
        public static readonly GUIStyle BackgroundOddStyle = "ObjectPickerResultsEven";

        public static Color LineColorProSkin = UnityEngine.GUI.backgroundColor * 0.7058f; 
        public static Color LineColorNoProSkin = Color.black;
        public static Color LineColor { get { return EditorGUIUtility.isProSkin ? LineColorProSkin : LineColorNoProSkin; } }

        public const int SpaceHeight = 20;
        public const int MinSpaceWidth = 15;
        public const int MaxSpaceWidth = 20;

        public const int LineThickness = 1;
        public const int GlobalPadding = 20;

        public const int LabelWidth = 80;
    }
}