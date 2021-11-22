using UnityEngine;
using UnityEditor;

namespace Lavid.Libraske.Editor
{
    internal static class Tags
    {
        internal const string EditorOnly = "EditorOnly";
        internal const string Web = "Web";
        internal const string Debug = "Debug";
    }

    // Restyle colors of gameobjects in hierarchy
    [InitializeOnLoad]
    public class HierarchyColorChange
    {
        static HierarchyColorChange() => EditorApplication.hierarchyWindowItemOnGUI += ChangeColors;
        static readonly int WidthFill = 12;

        private static void ChangeColors(int instanceID, Rect selectionRect)
        {
            var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            if (gameObject == null)
                return;

            if (gameObject.CompareTag(Tags.EditorOnly))
            {
                Color textColor = gameObject.activeSelf ? Color.white : Color.gray;
                string name = gameObject.name.ToUpperInvariant();
                Apply(selectionRect, name, Color.black, textColor, TextAnchor.MiddleCenter);
            }

            if (gameObject.CompareTag(Tags.Web))
            {
                Color textColor = gameObject.activeInHierarchy ? Color.white : Color.gray;
                Color color = gameObject.activeInHierarchy ? new Color(0.6f, 0.2f, 0.2f) : new Color(0.3f, 0.1f, 0.1f);
                Apply(selectionRect, gameObject.name, color, textColor, TextAnchor.MiddleRight);
            }

            if (gameObject.CompareTag(Tags.Debug))
            {
                Color textColor = gameObject.activeInHierarchy ? Color.white : Color.gray;
                Color color = gameObject.activeInHierarchy ? new Color(0.2f, 0.2f, 0.6f) : new Color(0.1f, 0.1f, 0.3f);
                Apply(selectionRect, gameObject.name, color, textColor, TextAnchor.MiddleRight);
            }
        }

        private static void Apply(Rect selectionRect, string name, Color color, Color textColor, TextAnchor align)
        {
            selectionRect.width += WidthFill;

            EditorGUI.DrawRect(selectionRect, color);

            EditorGUI.LabelField(selectionRect, name, new GUIStyle()
            {
                normal = new GUIStyleState() { textColor = textColor },
                alignment = align
            });
        }
    }
}