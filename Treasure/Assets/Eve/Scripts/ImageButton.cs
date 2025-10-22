using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;


/// <summary>
/// Image->Button
/// </summary>
[RequireComponent(typeof(Image))]
public class ImageButton : MonoBehaviour,IPointerEnterHandler,IPointerClickHandler,IPointerExitHandler
{
    private Animator animator;
    private static readonly int IsHover = Animator.StringToHash("IsHover");

    [Header("�ύX����������Text")]
    [SerializeField] private Text buttonText;

    [Header("Text�̒ʏ�J���[")]
    public Color32 normalColor;
    [Header("Text�̃J�[�\������������̃J���[")]
    public Color32 hoverColor;


    [Header("�N���b�N�������̃C�x���g")]
    [HideInInspector]
    public UnityEvent onClick;


    private void Awake()
    {
        animator = GetComponent<Animator>();

        normalColor = new Color32(200, 200, 200, 255);
        hoverColor = new Color32(255, 0, 0, 255);

        buttonText.color = normalColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool(IsHover, true);
        buttonText.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool(IsHover, false);
        buttonText.color = normalColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onClick?.Invoke();
    }

}
