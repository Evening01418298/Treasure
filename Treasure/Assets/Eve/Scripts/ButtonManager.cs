using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [Header("用意したボタンを入れる")]
    [SerializeField] private ImageButton startButton;
    [SerializeField] private ImageButton continueButton;
    [SerializeField] private ImageButton endButton;
    //[SerializeField] private ImageButton optionButton;
    //[SerializeField] private ImageButton windowButton;
    //[SerializeField] private ImageButton titleButton;

    private void Awake()
    {
        startButton.onClick.AddListener(OnStart);
        continueButton.onClick.AddListener(OnContinue);
        endButton.onClick.AddListener(OnEnd);

        //optionButton.onClick.AddListener(OnOption);
        //windowButton.onClick.AddListener(OnWindow);
        //titleButton.onClick.AddListener(OnTitle);
    }
    /// <summary>
    /// Startボタンが押された
    /// </summary>
    public void OnStart()
    {
        Debug.Log("Start");
    }
    /// <summary>
    /// Continueボタンが押された
    /// </summary>
    public void OnContinue()
    {
        Debug.Log("Continue");
    }
    /// <summary>
    /// Endボタンが押された
    /// </summary>
    public void OnEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }

    /// <summary>
    /// 設定ボタンが押された時
    /// </summary>
    public void OnOption()
    {
        Debug.Log("Option");
    }

    /// <summary>
    /// 画面サイズ変更ボタンが押された時
    /// </summary>
    public void OnWindow()
    {
        Debug.Log("Window");
    }

    /// <summary>
    /// 「タイトルへ」ボタンが押された時
    /// </summary>
    public void OnTitle()
    {
        Debug.Log("Title");
    }
}
