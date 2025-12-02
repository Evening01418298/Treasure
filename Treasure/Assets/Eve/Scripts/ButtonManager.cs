using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    /// <summary>
    /// 下で探したボタンを登録
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SearchAndRegisterButtons();
    }


    /// <summary>
    /// シーン内の指定した名前のボタンを探す
    /// </summary>
    private void SearchAndRegisterButtons()
    {
        TryFindButton("StartButton", OnStart);
        TryFindButton("ContinueButton", OnContinue);
        TryFindButton("EndButton", OnEnd);
        TryFindButton("ToTitleButton", OnTitle);
    }



    private void TryFindButton(string objectName, UnityEngine.Events.UnityAction action)
    {
        var obj = GameObject.Find(objectName);
        if(obj==null)
        {
            return;
        }

        var imageButton = obj.GetComponent<ImageButton>();
        if(imageButton == null)
        {
            return;
        }

        imageButton.onClick.AddListener(action);
        Debug.Log($"Button Registered: {objectName}");
    }


    public void OnStart()
    {
        Debug.Log("Start");
    }

    public void OnContinue()
    {
        Debug.Log("Continue");
    }

    public void OnEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void OnTitle()
    {
        //SceneManager.LoadScene("Title");
        Debug.Log("Title");
    }
}