using UnityEditor;
using UnityEngine;

namespace Momos.Tools.Attributes
{
    [CustomPropertyDrawer(typeof(GUIReadOnlyAttribute))]
    internal class GUIReadOnlyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUIReadOnlyAttribute guiAttribute = (GUIReadOnlyAttribute)attribute;
            EditorGUI.BeginDisabledGroup(true);
            EditorGUI.PropertyField(position, property, label);
            EditorGUI.EndDisabledGroup();
        }
    }
}