using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [Header("�p�ӂ����{�^��������")]
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
    /// Start�{�^���������ꂽ
    /// </summary>
    public void OnStart()
    {
        Debug.Log("Start");
    }
    /// <summary>
    /// Continue�{�^���������ꂽ
    /// </summary>
    public void OnContinue()
    {
        Debug.Log("Continue");
    }
    /// <summary>
    /// End�{�^���������ꂽ
    /// </summary>
    public void OnEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
    }
}
