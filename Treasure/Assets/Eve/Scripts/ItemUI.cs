using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private Text nameText;

    private ItemData item;

    public void SetUp(ItemData data)
    {
        item = data;
        nameText.text = data.itemName;
        Debug.Log("wow");
    }

    public void OnClickGet()
    {
        //ここでプレイヤーのインベントリーに追加する予定
    }

}
