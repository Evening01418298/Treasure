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
    [Header("非表示にしたいインベントリパネルを入れてね")]
    [SerializeField] private GameObject inventoryPanel;

    [Header("非表示にしたいtooltipを入れてね")]
    [SerializeField] private GameObject tooltip;

    [Header("インベントリのcloseButtonを入れてね")]
    [SerializeField] private Image closeButton;

    [HideInInspector]
    public Color normalCol = Color.white;       //普段の色（白）
    [Header("カーソルがこのボタンに乗った時の色")]
    public Color hoverCol = new Color(1f, 0f, 0f);


    void Awake()
    {
        //Imageを取得
        closeButton = GetComponent<Image>();

        //初期の色を設定
        if (closeButton != null)
        {
            normalCol = closeButton.color;
        }

    }
    /// <summary>
    /// 指定されたオブジェクト上でクリックされた時の処理
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        bool panelIsActive = inventoryPanel.activeSelf;     //inventoryPanelのアクティブ状態を取得
        inventoryPanel.SetActive(!panelIsActive);           //inventoryPanelの現状態とは反対にする
        bool tooltipIsActive = tooltip.activeSelf;

        if (panelIsActive == false)
        {
            tooltip.SetActive(true);
        }
        else if (panelIsActive == true && tooltipIsActive == true)
        {
            tooltip.SetActive(false);
        }

        closeButton.color = normalCol;                       //closeButtonの色を初期色に変更
    }

    /// <summary>
    /// 指定されたオブジェクト上にカーソルが乗った時の処理
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
    /// 指定されたオブジェクト上からカーソルが離れた時の処理
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
