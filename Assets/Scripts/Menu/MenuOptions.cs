using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    private Animator _animatorScene, _animatorBack;
    private GameObject _optionsTab, _mainTab;

    private void Awake()
    {
        _animatorScene = GameObject.Find("Canvas").GetComponent<Animator>();
        _animatorBack = GameObject.Find("BackGround").GetComponent<Animator>();
        _mainTab = GameObject.Find("Canvas/MainTab");
        _optionsTab = GameObject.Find("Canvas/OptionsTab");
    }
    void Start()
    {
        _optionsTab.transform.position += new Vector3(_mainTab.transform.position.x * 40,0,0);
        _optionsTab.SetActive(false);
    }
    public void OpenOptions()
    {
        _animatorBack.SetTrigger("inOption");
        _animatorScene.SetTrigger("inOption");
    }
    public void CloseOptions()
    {
        _animatorBack.SetTrigger("outOption");
        _animatorScene.SetTrigger("outOption");
    }
    public void OpenMainTab()
    {
        _mainTab.SetActive(true);
        _optionsTab.SetActive(false);
    }
    public void OpenOptionTab()
    {
        _mainTab.SetActive(false);
        _optionsTab.SetActive(true);
    }
    public void OpenPlay()
    {
        _animatorBack.SetTrigger("inPlay");
    }
    public void Exit()
    {
        _animatorBack.SetTrigger("Exit");
    }
    public void SceneLoad(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
