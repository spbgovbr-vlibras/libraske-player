using UnityEngine;
using UnityEditor;

namespace Lavid.Libraske.Editor
{
    // Restyle colors of gameobjects in hierarchy
    [InitializeOnLoad]
    public class HierarchyColorChange
    {
        static HierarchyColorChange() => EditorApplication.hierarchyWindowItemOnGUI += ChangeColors;

        private static void ChangeColors(int instanceID, Rect selectionRect)
        {
            var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            if (gameObject == null)
                return;

            Color textColor = gameObject.activeSelf ? Color.white : Color.gray;

            if (gameObject.CompareTag("EditorOnly"))
            {
                Color black = Color.black;
                string name = gameObject.name.ToUpperInvariant();

                Apply(selectionRect, name, black, textColor);
            }
        }

        private static void Apply(Rect selectionRect, string name, Color color, Color textColor)
        {
            EditorGUI.DrawRect(selectionRect, color);

            EditorGUI.LabelField(selectionRect, name, new GUIStyle()
            {
                normal = new GUIStyleState() { textColor = textColor }
            });
        }
    }
}