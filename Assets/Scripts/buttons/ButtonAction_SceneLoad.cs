using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;

public class ButtonAction_SceneLoad : MonoBehaviour
{
    #region Private_Method
    private void addUIEvents()
    {
        SceneManager.LoadScene(_secneName, LoadSceneMode.Additive);
    }
    #endregion //#region Private_Method
    #region Private_Unity
    private void Awake()
    {        
        Assert.IsNotNull(_button, "버튼이 링크 되지 않았습니다. 프리팹에서 링크가 되었는지 확인이 필요합니다.");        
        // 최충현(2023/1/29) : 씬 이름은 에디터에서 목록으로 받아서 지정 되도록 변경 해야됨
        Assert.IsFalse(string.IsNullOrEmpty(_secneName), $"지정된 씬 이름이 없습니다.\n object name = {gameObject.name}");
        
        _button.onClick.AddListener(addUIEvents);
    }
    #endregion //#region Private_Unity

    #region Public    
    public string SceneName { get { return _secneName; } }
    #endregion //#region Public    
    #region Private
    [SerializeField]
    private string _secneName;
    [SerializeField]
    private Button _button;
    
    #endregion //#region Private

}
