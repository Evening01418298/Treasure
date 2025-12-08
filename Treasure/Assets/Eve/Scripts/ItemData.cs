using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemQuality
{
    Normal,
    Rare,
    Epic,
    Legendary,
}


[CreateAssetMenu(fileName = "CreateNewItem",menuName = "Item/ItemData")]
public class ItemData : ScriptableObject
{
    [Header("基本情報")]
    public string itemName;
    public Sprite itemImage;

    [Header("アイテム価格")]
    public int basePrice;
    public ItemQuality quality;

    public int GetPrice()
    {
        float multiplier = quality switch
        {
            ItemQuality.Normal      => 1.0f,
            ItemQuality.Rare        => 1.5f,
            ItemQuality.Epic        => 2.0f,
            ItemQuality.Legendary   => 3.0f,
            _ => 1.0f
        };

        return Mathf.RoundToInt(basePrice * multiplier);
    }   
}
