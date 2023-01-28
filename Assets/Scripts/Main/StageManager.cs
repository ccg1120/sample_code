using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public delegate void SceneLoadCallback(in string sceneName);

    private Dictionary<string, SceneLoadCallback> _sceneCallbackDict = null;

    #region Public
    public void StartNextStage(in string sceneName, SceneLoadCallback callback = null)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        if (callback != null)
            _sceneCallbackDict.Add(sceneName, callback);
    }
    #endregion //#region Public

    #region Private
    private void LoadedSceneCallback(Scene sceneInfo, LoadSceneMode loadSceneMode)
    {
        string sceneName = sceneInfo.name;

        Debug.Log($"LoadedSceneCallback : {sceneName}");
        SceneLoadCallback callback;
        if (_sceneCallbackDict.TryGetValue(sceneName, out callback))
        {
            callback.Invoke(sceneName);
            _sceneCallbackDict.Remove(sceneName);
        }
    }

    #endregion //#region Private

    #region Private_Unity
    private void Awake()
    {
        _sceneCallbackDict = new Dictionary<string, SceneLoadCallback>();

        SceneManager.sceneLoaded += LoadedSceneCallback;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= LoadedSceneCallback;
    }
    #endregion // #region Private_Unity

    
}
