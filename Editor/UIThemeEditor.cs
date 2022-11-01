using LiteNinja.Common.Editor;
using UnityEditor;
using UnityEngine;


namespace LiteNinja.UIThemes.Editor
{
    [CustomEditor(typeof(UITheme))]
    public class UIThemeEditor : CustomInspectorHelper
    {
        private bool _isCached;
        private SerializedProperty _colorTags;
        private SerializedProperty _colorGroupTags;
        private SerializedProperty _spriteTags;
        private UITheme _uiTheme;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            if (!_isCached)
            {
                _uiTheme = (UITheme)target;
                _colorTags = serializedObject.FindProperty("colorTags");
                _colorGroupTags = serializedObject.FindProperty("colorGroupTags");
                _spriteTags = serializedObject.FindProperty("spriteTags");
                _isCached = true;
            }

            if (_colorTags != null)
            {
                ShowColorTagsArray(_colorTags);
                ShowImageTagsArray(_spriteTags);
                EditorGUILayout.PropertyField(_colorGroupTags, true);
            }

            serializedObject.ApplyModifiedProperties();

            EditorUtility.SetDirty(_uiTheme);
        }

        

        

        public void ShowColorTagsArray(SerializedProperty list, string label = "ColorThemeTags ")
        {
            var isExpanded = BeginFoldoutBox("Color Tags");

            if (isExpanded)
            {
                if (list.arraySize > 0)
                {
                    var indentLevel = EditorGUI.indentLevel;
                    EditorGUI.indentLevel = 1;
                    
                    for (var i = 0; i < list.arraySize; i++)
                    {
                        BeginBox();
                        EditorGUILayout.BeginHorizontal();

                        var tagName = list.GetArrayElementAtIndex(i).FindPropertyRelative("tagName");
                        var isOpened = BeginSimpleFoldoutBox(tagName.stringValue, "ColorTag : " + (i + 1));
                        if (GUILayout.Button("+", EditorStyles.miniButtonLeft, GUILayout.Width(20f)))
                        {
                            list.InsertArrayElementAtIndex(i);
                        }

                        if (GUILayout.Button("-", EditorStyles.miniButtonRight, GUILayout.Width(20f)))
                        {
                            list.DeleteArrayElementAtIndex(i);
                            return;
                        }

                        EditorGUILayout.EndHorizontal();

                        if (isOpened)
                        {
                            EditorGUILayout.BeginHorizontal();
                            EditorGUI.indentLevel = indentLevel + 1;
                            EditorGUILayout.BeginVertical();

                            var labelStyle = new GUIStyle(GUI.skin.label);
                            labelStyle.fontStyle = FontStyle.Bold;

                            DrawLine();
                            EditorGUILayout.BeginHorizontal();
                            EditorGUILayout.LabelField("Tag Name : ", labelStyle, GUILayout.MaxWidth(120));
                            tagName.stringValue = EditorGUILayout.TextField(tagName.stringValue);
                            EditorGUILayout.EndHorizontal();

                            //GUILayout.Space(5);

                            EditorGUILayout.BeginHorizontal();
                            var tagColor =
                                list.GetArrayElementAtIndex(i).FindPropertyRelative("tagColor");
                            EditorGUILayout.LabelField("Tag Color : ", labelStyle, GUILayout.MaxWidth(120));
                            tagColor.colorValue = EditorGUILayout.ColorField(tagColor.colorValue);
                            EditorGUILayout.EndHorizontal();

                            EditorGUILayout.EndVertical();
                            EditorGUILayout.EndHorizontal();
                        }

                        EndBox();
                    }

                    EditorGUI.indentLevel = indentLevel;
                }
                
                GUI.backgroundColor = Color.grey;
                var style2 = new GUIStyle(GUI.skin.button);
                style2.richText = true;
                style2.fixedHeight = 20;

                if (GUILayout.Button(new GUIContent("<b>Add Color Tag</b>"), style2))
                {
                    list.arraySize += 1;
                }

                GUI.backgroundColor = Color.white;
            }

            EndBox();
        }

        public void ShowImageTagsArray(SerializedProperty list, string label = "ImageThemeTags ")
        {
            var isExpanded = BeginFoldoutBox("Sprite Tags");

            if (isExpanded)
            {
                if (list.arraySize > 0)
                {
                    var indentLevel = EditorGUI.indentLevel;
                    EditorGUI.indentLevel = 1;
                    
                    for (var i = 0; i < list.arraySize; i++)
                    {
                        BeginBox();
                        EditorGUILayout.BeginHorizontal();

                        var tagName = list.GetArrayElementAtIndex(i).FindPropertyRelative("tagName");
                        var isOpened = BeginSimpleFoldoutBox(tagName.stringValue, "ImageTag : " + (i + 1));
                        if (GUILayout.Button("+", EditorStyles.miniButtonLeft, GUILayout.Width(20f)))
                        {
                            list.InsertArrayElementAtIndex(i);
                        }

                        if (GUILayout.Button("-", EditorStyles.miniButtonRight, GUILayout.Width(20f)))
                        {
                            list.DeleteArrayElementAtIndex(i);
                            return;
                        }

                        EditorGUILayout.EndHorizontal();

                        if (isOpened)
                        {
                            EditorGUILayout.BeginHorizontal();
                            EditorGUI.indentLevel = indentLevel + 1;
                            EditorGUILayout.BeginVertical();

                            var labelStyle = new GUIStyle(GUI.skin.label);
                            labelStyle.fontStyle = FontStyle.Bold;

                            DrawLine();
                            EditorGUILayout.BeginHorizontal();
                            EditorGUILayout.LabelField("Tag Name : ", labelStyle, GUILayout.MaxWidth(120));
                            tagName.stringValue = EditorGUILayout.TextField(tagName.stringValue);
                            EditorGUILayout.EndHorizontal();

                            //GUILayout.Space(5);

                            EditorGUILayout.BeginHorizontal();
                            var tagSprite =
                                list.GetArrayElementAtIndex(i).FindPropertyRelative("tagSprite");
                            EditorGUILayout.LabelField("Tag Sprite : ", labelStyle, GUILayout.MaxWidth(120));
                            //EditorGUILayout.ObjectField(tagSprite, typeof(Sprite));
                            tagSprite.objectReferenceValue = EditorGUILayout.ObjectField(tagSprite.objectReferenceValue,
                                typeof(Sprite), false);
                            EditorGUILayout.EndHorizontal();


                            EditorGUILayout.EndVertical();
                            EditorGUILayout.EndHorizontal();
                        }

                        EndBox();
                    }

                    EditorGUI.indentLevel = indentLevel;
                }
                
                GUI.backgroundColor = Color.grey;
                var style2 = new GUIStyle(GUI.skin.button);
                style2.richText = true;
                style2.fixedHeight = 20;

                if (GUILayout.Button(new GUIContent("<b>Add Image Tag</b>"), style2))
                {
                    list.arraySize += 1;
                }

                GUI.backgroundColor = Color.white;
            }

            EndBox();
        }
    }
}