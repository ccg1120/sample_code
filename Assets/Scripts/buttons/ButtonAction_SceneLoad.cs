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
        Assert.IsNotNull(_button, "��ư�� ��ũ ���� �ʾҽ��ϴ�. �����տ��� ��ũ�� �Ǿ����� Ȯ���� �ʿ��մϴ�.");        
        // ������(2023/1/29) : �� �̸��� �����Ϳ��� ������� �޾Ƽ� ���� �ǵ��� ���� �ؾߵ�
        Assert.IsFalse(string.IsNullOrEmpty(_secneName), $"������ �� �̸��� �����ϴ�.\n object name = {gameObject.name}");
        
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
