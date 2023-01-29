using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.Assertions;

[CustomEditor(typeof(ButtonAction_SceneLoad))]
public class ButtonActionSceneLoadEditor : Editor
{  
    private void OnEnable()
    {
        

        _sceneNameProperty = serializedObject.FindProperty("_secneName");
        _buttonProperty = serializedObject.FindProperty("_button");

        getBuildSceneList();
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(_buttonProperty, new GUIContent("button"));
        _currnetSelectIndex = EditorGUILayout.Popup(new GUIContent("Scene"), _setSelectIndex, _sceneList.ToArray());
        if(_currnetSelectIndex != _setSelectIndex)
        {
            _setSelectIndex = _currnetSelectIndex;
            _sceneNameProperty.stringValue = _sceneList[_setSelectIndex];
            Debug.Log(_sceneList[_setSelectIndex]);
            serializedObject.ApplyModifiedProperties();
            Debug.Log(_sceneNameProperty.stringValue);
        }
    }

#region Private
    void getBuildSceneList()
    {
        Assert.IsNotNull(_sceneNameProperty, "_sceneNameProperty가 Null 입니다. 호출 순서가 잘못 되었습니다. 확인이 필요합니다");

        _sceneList.Clear();
        string currentSelectSceneName = _sceneNameProperty.stringValue;
        string currentActiveScene = SceneManager.GetActiveScene().name;

        int sceneCountInBuildSettingsCount = SceneManager.sceneCountInBuildSettings;
        for (int index = 0; index < sceneCountInBuildSettingsCount; index++)
        {
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(index));

            if (currentActiveScene.Equals(sceneName))
                continue;

            _sceneList.Add(sceneName);

            if (sceneName.Equals(currentSelectSceneName))
                _setSelectIndex = index;
        }
    }
#endregion


    SerializedProperty _sceneNameProperty;
    SerializedProperty _buttonProperty;    
    int _currnetSelectIndex = 0;
    int _setSelectIndex = 0;
    List<string> _sceneList = new List<string>();
}
