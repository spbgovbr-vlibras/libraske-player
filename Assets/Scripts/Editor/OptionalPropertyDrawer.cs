using UnityEditor;
using UnityEngine;

namespace Lavid.Libraske.Editor
{
    [CustomPropertyDrawer(typeof(Optional<>))]
    public class OptionalPropertyDrawer : PropertyDrawer
    {
        // When using lists
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var valueProperty = property.FindPropertyRelative("_value");
            return EditorGUI.GetPropertyHeight(valueProperty);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var enabledProperty = property.FindPropertyRelative("_enabled");
            var valueProperty = property.FindPropertyRelative("_value");

            float spaceBetweenFields = 2;
            float fieldOffset = 32;

            /* ------- Begin -------- */
            EditorGUI.BeginProperty(position, label, property);

            EditorGUI.BeginDisabledGroup(!enabledProperty.boolValue);
            position.width -= fieldOffset;
            EditorGUI.PropertyField(position, valueProperty, label, true);
            EditorGUI.EndDisabledGroup();

            position.x += position.width + EditorGUI.GetPropertyHeight(enabledProperty) + spaceBetweenFields;
            position.width = position.height = EditorGUI.GetPropertyHeight(enabledProperty); // Same size because is  square
            position.x -= EditorGUI.GetPropertyHeight(enabledProperty); // position to start drawing
            EditorGUI.PropertyField(position, enabledProperty, GUIContent.none);

            EditorGUI.EndProperty(); 
            /* --------- END -------- */
        }
    }
}