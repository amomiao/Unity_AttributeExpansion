using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Momos.Tools.Attributes
{
    [CustomPropertyDrawer(typeof(ColoredAttribute))]
    internal class ColoredDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ColoredAttribute coloredAttribute = (ColoredAttribute)attribute;
            Color saveColor = GUI.color;
            GUI.color = coloredAttribute.Color;
            EditorGUI.PropertyField(position, property, label);
            GUI.color = saveColor;  // Reset the color to avoid affecting other GUI elements
        }
    }
}