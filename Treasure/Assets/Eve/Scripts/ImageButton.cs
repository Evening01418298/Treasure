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

    [Header("変更を加えたいText")]
    [SerializeField] private Text buttonText;

    [Header("Textの通常カラー")]
    public Color32 normalColor;
    [Header("Textのカーソルが乗った時のカラー")]
    public Color32 hoverColor;


    [Header("クリックした時のイベント")]
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
