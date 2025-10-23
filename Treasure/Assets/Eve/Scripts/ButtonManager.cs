using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [Header("用意したボタンを入れる")]
    [SerializeField] private ImageButton startButton;
    [SerializeField] private ImageButton continueButton;
    [SerializeField] private ImageButton endButton;

    private void Awake()
    {
        startButton.onClick.AddListener(OnStart);
        continueButton.onClick.AddListener(OnContinue);
        endButton.onClick.AddListener(OnEnd);
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
}
