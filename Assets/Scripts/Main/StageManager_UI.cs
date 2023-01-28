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
        Assert.IsNotNull(_stageManager, "_stageManager �� null �Դϴ�. �ش� ��ü�� ���ٸ� ������ �۵��� �մϴ�. ���ε� Ȯ���� �ʿ��մϴ�.");

        Assert.IsNotNull(_startButton, "_startButton �� null �Դϴ�. �ش� ��ư�� ���ε� �Ǿ� �־�� �մϴ�.");

        addUIEvents();
    }
    #endregion //#region Private_Unity
}
