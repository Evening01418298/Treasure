using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot:MonoBehaviour
{
    [Header("スロットに追加される情報")]
    public ItemData item;
    public int count;

    [Header("ItemDataを参照")]
    [SerializeField] private Image iconImage;
    [SerializeField] private Image backGround;
    [SerializeField] private Text countText;

    /// <summary>
    /// スロットの見た目がアイテムデータの無いようになるはず
    /// </summary>
    public void UpdateSlotDisplay()
    {
        if (item != null)
        {
            iconImage.sprite = item.itemImage;
            iconImage.enabled = true;

            countText.text = (count > 1) ? count.ToString() : "";

            switch(item.itemQuality)
            {
                case Quality.Inferior:
                    backGround.color = Color.gray;
                    //Debug.Log("Inf");
                    break;

                case Quality.Damaged:
                    backGround.color = Color.blue;
                    break;

                case Quality.Normal:
                    backGround.color = Color.magenta;
                    break;

                case Quality.Perfect:
                    backGround.color = Color.red;
                    break;
            }

        }
        else
        {
            iconImage.sprite = null;
            iconImage.enabled = false;
            countText.text = "";
        }
    }

    public void ClearSlot()
    {
        item = null;
        count -= 1;
        UpdateSlotDisplay();
    }
}
