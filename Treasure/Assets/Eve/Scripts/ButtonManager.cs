using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private ImageButton startButton;
    [SerializeField] private ImageButton continueButton;
    [SerializeField] private ImageButton endButton;

    private void Awake()
    {
        startButton.onClick.AddListener(OnStart);
        continueButton.onClick.AddListener(OnContinue);
        endButton.onClick.AddListener(OnEnd);
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
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }
}
