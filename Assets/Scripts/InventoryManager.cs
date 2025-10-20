using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject backGroundPanel;

    [SerializeField] private ItemTooltip tooltipReference;

    [Header("現在のインベントリ状況")]
    public List<InventorySlot> slots = new List<InventorySlot>();

    [Header("アイテムデータベースを入れてね")]
    [SerializeField] private ItemDataBase dataBase;


    private void Awake()
    {
        backGroundPanel.SetActive(false);
    }


    /// <summary>
    /// ランダムにアイテム生成(アイテムデータベースのテスト用)
    /// </summary>
    public void RandomAddItem()
    {
        if (dataBase == null || dataBase.Items == null || dataBase.Items.Length == 0)
        {
            Debug.LogWarning("ItemDataBaseがアタッチされてないよ");
            return;
        }

        int randNum = Random.Range(0, dataBase.Items.Length);
        ItemData randItem = dataBase.Items[randNum];

        int randAmount = Random.Range(1, 6);

        AddItem(randItem, randAmount);
    }


    /// <summary>
    /// アイテムをインベントリに追加
    /// </summary>
    public void AddItem(ItemData itemToAdd, int amount = 1)
    {
        //スタックが可能な場合は、スタックする
        if (itemToAdd.isStackable)
        {
            foreach (InventorySlot slot in slots)
            {
                if (slot.item == itemToAdd && slot.count < itemToAdd.MaxStack)
                {
                    int spaceLeft = itemToAdd.MaxStack - slot.count;
                    int toAdd = Mathf.Min(spaceLeft, amount);
                    slot.count += toAdd;
                    amount -= toAdd;
                    slot.UpdateSlotDisplay();

                    if (amount <= 0) return;
                }
            }
        }

        foreach (InventorySlot slot in slots)
        {
            if (slot.item == null)
            {
                slot.item = itemToAdd;
                slot.count = Mathf.Min(amount, itemToAdd.MaxStack);
                amount -= slot.count;
                slot.UpdateSlotDisplay();
                Debug.Log("空スロットに追加");

                ItemFrameController frameCtrl = slot.GetComponentInChildren<ItemFrameController>(true);
                if (frameCtrl != null)
                {
                    frameCtrl.SetItemData(itemToAdd);
                    Debug.Log($"[DEBUG] {slot.name} に {itemToAdd.itemName} を設定しました");
                }
                else
                {
                    Debug.LogWarning($"[DEBUG] {slot.name} に ItemFrameController が見つからない");
                }

                if (amount <= 0) return;
            }
        }

        if (amount > 0)
        {
            Debug.Log("インベントリがいっぱいだよ");
        }

    }

    [Header("フレーム関連")]
    [Tooltip("フレームプレハブを入れてね")]
    [SerializeField] private GameObject itemFrame;
    [Tooltip("フレームの数を入力してね")]
    [SerializeField] int frameNumX;
    [SerializeField] int frameNumY;
    [Tooltip("フレーム間の幅")]
    [SerializeField] float space;

    private void Start()
    {
        GenerateFrames();
    }

    /// <summary>
    /// アイテムの枠を等間隔に生成するスクリプト
    /// </summary>
    public void GenerateFrames()
    {
        //親UIのRectTransformを取得
        RectTransform parentRect = GetComponent<RectTransform>();
        float parentWidth = parentRect.rect.width;
        float parentHeight = parentRect.rect.height;

        //プレハブの幅を取得
        RectTransform prefabRect = itemFrame.GetComponent<RectTransform>();
        float frameWidth = prefabRect.rect.width;
        float frameHeight = prefabRect.rect.height;

        //親UIと生成するオブジェクトの幅を算出
        float totalWidth = (frameWidth * frameNumX) + (space * (frameNumX - 1));
        float totalHeight = (frameHeight * frameNumY) + (space * (frameNumY - 1));

        //最初の生成するオブジェクトのx座標
        float startX = -(totalWidth / 2f) + (frameWidth / 2f);
        float startY = (totalHeight / 2f) - (frameHeight / 2f);


        for (int y = 0; y < frameNumY; y++)
        {
            for (int x = 0; x < frameNumX; x++)
            {
                //プレハブを子オブジェクトとして配置する
                GameObject frame = Instantiate(itemFrame, transform);

                ItemFrameController frameController = frame.GetComponent<ItemFrameController>();
                if(frameController != null)
                {
                    frameController.SetTooltip(tooltipReference);
                }

                //フレームのRectTransformを取得
                RectTransform rt = frame.GetComponent<RectTransform>();

                //計算した位置に配置
                float xPos = startX + x * (frameWidth + space);
                float yPos = startY - y * (frameHeight + space);
                rt.anchoredPosition = new Vector2(xPos, yPos);

                //スロットの情報を取得
                InventorySlot slot = frame.GetComponent<InventorySlot>();
                if (slot != null)
                {
                    slots.Add(slot);
                }
                else
                {
                    Debug.LogWarning("InventorySlotがアタッチされていないよ");
                }

            }

        }
    }

}
