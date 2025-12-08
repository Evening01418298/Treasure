using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Transform itemsParent;

    private InteractableObject currentChest;

    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void ShowItems(InteractableObject chest)
    {
        currentChest = chest;
        gameObject.SetActive(true);

        // 既存をクリア
        foreach (Transform child in itemsParent)
            Destroy(child.gameObject);

        // アイテムを並べる
        foreach (var item in chest.items)
        {
            var obj = Instantiate(itemPrefab, itemsParent);
            var ui = obj.GetComponent<ItemUI>();
            ui.SetUp(item);
        }
    }

    private void TakeItem(ItemData item)
    {
        // プレイヤーインベントリへ追加（仮）
        //PlayerInventory.Instance.Add(item);

        // 宝箱から削除
        currentChest.items.Remove(item);

        // UIを更新
        ShowItems(currentChest);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

}
