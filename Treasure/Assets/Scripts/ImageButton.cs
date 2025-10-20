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
    [Header("�N���b�N�������̃C�x���g")]
    public UnityEvent onClick;


    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onClick?.Invoke();
    }

}
