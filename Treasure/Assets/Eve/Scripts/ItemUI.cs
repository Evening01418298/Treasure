using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private Text itemNameText;
    [SerializeField] private Button takeButton;

    private ItemData currentItem;

    public void Setup(ItemData item, System.Action onTake)
    {
        currentItem = item;
        itemNameText.text = item.itemName;

        takeButton.onClick.RemoveAllListeners();
        takeButton.onClick.AddListener(() => onTake());
    }
}
