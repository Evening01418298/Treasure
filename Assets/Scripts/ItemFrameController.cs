using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemFrameController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("アイテムフレームを入れてね")]
    [SerializeField] private Image frameImage;

    [HideInInspector]
    //各状態のアイテムカラー
    public Color normalColor = Color.white;
    [Header("アイテム枠の変更色")]
    [Tooltip("アイテムフレームにカーソルが乗った時のフレーム色")]
    public Color hoverColor = new Color(1f, 0.8f, 0.6f);

    [Header("アイテムの説明欄")]
    public ItemTooltip tooltip;

    [Header("ItemDataを入れてね")]
    [SerializeField] private ItemData itemData;

    [HideInInspector]
    public bool onCursor;

    void Awake()
    {
        //Imageを取得
        frameImage = GetComponent<Image>();

        //初期の色を設定
        if (frameImage != null)
        {
            normalColor = frameImage.color;
        }

        //一応
        if (tooltip == null)
        {
            tooltip = FindObjectOfType<ItemTooltip>();
        }
    }

    /// <summary>
    ///カーソルが指定したUIの上に乗った時の処理
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
            Debug.Log("表示中");

            tooltip.ShowTootip(
                itemData.itemName,
                itemData.itemQuality,
                itemData.BasicPrice
                );
        }

    }

    /// <summary>
    /// カーソルが指定したUIから離れた時の処理
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
