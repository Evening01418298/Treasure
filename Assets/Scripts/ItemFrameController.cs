using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemFrameController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("�A�C�e���t���[�������Ă�")]
    [SerializeField] private Image frameImage;

    [HideInInspector]
    //�e��Ԃ̃A�C�e���J���[
    public Color normalColor = Color.white;
    [Header("�A�C�e���g�̕ύX�F")]
    [Tooltip("�A�C�e���t���[���ɃJ�[�\������������̃t���[���F")]
    public Color hoverColor = new Color(1f, 0.8f, 0.6f);

    [Header("�A�C�e���̐�����")]
    public ItemTooltip tooltip;

    [Header("ItemData�����Ă�")]
    [SerializeField] private ItemData itemData;

    [HideInInspector]
    public bool onCursor;

    void Awake()
    {
        //Image���擾
        frameImage = GetComponent<Image>();

        //�����̐F��ݒ�
        if (frameImage != null)
        {
            normalColor = frameImage.color;
        }

        //�ꉞ
        if (tooltip == null)
        {
            tooltip = FindObjectOfType<ItemTooltip>();
        }
    }

    /// <summary>
    ///�J�[�\�����w�肵��UI�̏�ɏ�������̏���
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        onCursor = true;

        if (frameImage != null)
        {
            frameImage.color = hoverColor;
        }

        if (itemData != null && tooltip != null)
        {
            Debug.Log("�\����");

            tooltip.ShowTootip(
                itemData.itemName,
                itemData.itemQuality,
                itemData.BasicPrice
                );
        }

    }

    /// <summary>
    /// �J�[�\�����w�肵��UI���痣�ꂽ���̏���
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        onCursor = false;

        if (frameImage != null)
        {
            frameImage.color = normalColor;
        }
        tooltip.HideTooltips();
    }

    public void SetTooltip(ItemTooltip tooltipRef)
    {
        tooltip = tooltipRef;
    }

    public void SetItemData(ItemData data)
    {
        itemData = data;
    }

}
