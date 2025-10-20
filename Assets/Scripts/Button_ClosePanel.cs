using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Button_ClosePanel : MonoBehaviour,
    IPointerClickHandler,
    IPointerEnterHandler,
    IPointerExitHandler
{
    [Header("��\���ɂ������C���x���g���p�l�������Ă�")]
    [SerializeField] private GameObject inventoryPanel;

    [Header("��\���ɂ�����tooltip�����Ă�")]
    [SerializeField] private GameObject tooltip;

    [Header("�C���x���g����closeButton�����Ă�")]
    [SerializeField] private Image closeButton;

    [HideInInspector]
    public Color normalCol = Color.white;       //���i�̐F�i���j
    [Header("�J�[�\�������̃{�^���ɏ�������̐F")]
    public Color hoverCol = new Color(1f, 0f, 0f);


    void Awake()
    {
        //Image���擾
        closeButton = GetComponent<Image>();

        //�����̐F��ݒ�
        if (closeButton != null)
        {
            normalCol = closeButton.color;
        }

    }
    /// <summary>
    /// �w�肳�ꂽ�I�u�W�F�N�g��ŃN���b�N���ꂽ���̏���
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        bool panelIsActive = inventoryPanel.activeSelf;     //inventoryPanel�̃A�N�e�B�u��Ԃ��擾
        inventoryPanel.SetActive(!panelIsActive);           //inventoryPanel�̌���ԂƂ͔��΂ɂ���
        bool tooltipIsActive = tooltip.activeSelf;

        if (panelIsActive == false)
        {
            tooltip.SetActive(true);
        }
        else if (panelIsActive == true && tooltipIsActive == true)
        {
            tooltip.SetActive(false);
        }

        closeButton.color = normalCol;                       //closeButton�̐F�������F�ɕύX
    }

    /// <summary>
    /// �w�肳�ꂽ�I�u�W�F�N�g��ɃJ�[�\������������̏���
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (closeButton != null)
        {
            closeButton.color = hoverCol;
        }
    }

    /// <summary>
    /// �w�肳�ꂽ�I�u�W�F�N�g�ォ��J�[�\�������ꂽ���̏���
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        if (closeButton != null)
        {
            closeButton.color = normalCol;
        }
    }
}
