using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// スクリプタブルオブジェクトのアイテム情報
/// </summary> 

[CreateAssetMenu(fileName ="CreateItemData",menuName ="CreateNewItem/Item Data",order =0)]
public class ItemData : ScriptableObject
{
    [Header("基本情報")]
    [Space(10)]
    [Tooltip("アイテムの名前")]
    public string itemName;

    [Tooltip("アイテムのイメージ画像")]
    public Sprite itemImage;

    [Tooltip("アイテムのレアリティ")]
    public Quality itemQuality;

    [Tooltip("アイテムの基礎値段")]
    public int BasicPrice;
    [HideInInspector]
    public int price;           //これが実際のアイテムの値段(基礎値段x品質で求めるつもり)

    [Tooltip("アイテムの種類")]
    public ObjType type;

    [Tooltip("アイテムの最大スタック数")]
    public int MaxStack;

    //スタック出来る場合は1以上
    public bool isStackable => MaxStack > 1;


    public int Price()
    {
        float multiplier = 1f;

        switch (itemQuality)
        {
            case Quality.Inferior:
                multiplier = 1.0f;
                break;

            case Quality.Damaged:
                multiplier = 1.5f;
                break;

            case Quality.Normal:
                multiplier = 2.0f;
                break;

            case Quality.Perfect:
                multiplier = 3.0f;
                break;
        }

        return Mathf.RoundToInt(BasicPrice * multiplier);
    }

}


public enum ObjType
{ 
    States,             //ポーションや包帯等に振り分ける予定
    Valuables,          //貴重品。宝石等に振り分ける予定
    Weapons,            //武器
}

public enum Quality
{
    Perfect,        //完璧
    Normal,         //普通
    Damaged,        //傷物
    Inferior,       //粗悪品
}