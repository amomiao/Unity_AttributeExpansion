using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Momos.Tools.Attributes
{
    [CustomPropertyDrawer(typeof(EnumFilterAttribute))]
    internal class EnumFilterDrawer : PropertyDrawer
    {
        private string inputValue;
        private int nowIndex;
        private List<string> enumValues;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EnumFilterAttribute filterAttribute = (EnumFilterAttribute)attribute;
            if (!filterAttribute.EnumType.IsEnum)
            {
                position.height /= 2;
                EditorGUI.HelpBox(position, "修饰的变量并非枚举", MessageType.Warning);
                position.y += position.height;
                EditorGUI.PropertyField(position, property, label);
            }
            else
            {
                // -获取枚举Names
                enumValues = new List<string>(Enum.GetNames(filterAttribute.EnumType));
                string nn = Enum.GetName(filterAttribute.EnumType, property.enumValueIndex);
                float quarWidth = position.width / 4;
                // -枚举Names过滤
                nowIndex = FilterStringList(ref enumValues, nn);
                // 标签
                EditorGUI.LabelField(new Rect(position.x, position.y, quarWidth, position.height), property.displayName);
                // 当前选择
                EditorGUI.BeginDisabledGroup(true);
                EditorGUI.TextField(new Rect(position.x + quarWidth, position.y, quarWidth, position.height), nn);
                EditorGUI.EndDisabledGroup();
                // 过滤关键词
                inputValue = EditorGUI.TextField(new Rect(position.x + quarWidth * 2, position.y, quarWidth, position.height), inputValue);
                // 选择下拉框
                EditorGUI.BeginDisabledGroup(enumValues.Count == 0);
                nowIndex = EditorGUI.Popup(new Rect(position.x + quarWidth * 3, position.y, quarWidth, position.height), 
                    nowIndex, 
                    enumValues.ToArray());
                if (nowIndex != -1)
                {
                    property.enumValueIndex = (int)Enum.Parse(filterAttribute.EnumType, enumValues[nowIndex]);
                }
                EditorGUI.EndDisabledGroup();
            }
        }

        private int FilterStringList(ref List<string> enumValues,string nowEnumName)
        {
            if (!string.IsNullOrEmpty(inputValue))
            {
                for (int i = enumValues.Count - 1; i >= 0; i--)
                {
                    if (!enumValues[i].ToLower().Contains(inputValue.ToLower()))
                        enumValues.RemoveAt(i);
                }
            }
            for (int i = 0; i < enumValues.Count; i++) 
            {
                if (nowEnumName.Equals(enumValues[i]))
                    return i;
            }
            return -1;
        }
    }
}