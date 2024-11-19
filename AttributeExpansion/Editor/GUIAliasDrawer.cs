using UnityEditor;
using UnityEngine;

namespace Momos.Tools.Attributes
{
    [CustomPropertyDrawer(typeof(GUIAliasAttribute))]
    internal class GUIAliasDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            label.text = ((GUIAliasAttribute)attribute).Alias;
            EditorGUI.PropertyField(position, property, label);
        }
    }
}