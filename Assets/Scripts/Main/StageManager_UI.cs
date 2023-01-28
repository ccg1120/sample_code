using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class StageManager_UI : MonoBehaviour
{
    [SerializeField]
    private Button _startButton;


    private StageManager _stageManager = null;

    #region Public
    #endregion //#region Public

    #region Private

    private void addUIEvents()
    {
        _startButton.onClick.AddListener(delegate { _stageManager.StartNextStage("Game"); });
    }
    #endregion //#region Private  

    #region Private_Unity
    private void Awake()
    {
        Debug.Log("Awake");
        _stageManager = FindObjectOfType<StageManager>();
        Assert.IsNotNull(_stageManager, "_stageManager 가 null 입니다. 해당 객체가 없다면 비정상 작도을 합니다. 바인딩 확인이 필요합니다.");

        Assert.IsNotNull(_startButton, "_startButton 가 null 입니다. 해당 버튼이 바인딩 되어 있어야 합니다.");

        addUIEvents();
    }
    #endregion //#region Private_Unity
}
