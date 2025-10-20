using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private ItemDataBase dataBase;
    [SerializeField] private GameObject tooltip;

    [SerializeField] private ItemData itemData;
    private int amount;

    [SerializeField] private GameObject inventoryPanel;

    private void Awake()
    {
        amount = 1;
    }

    private void Update()
    {
        OpenInventory();

        if(Input.GetKey(KeyCode.R))
        {
            inventoryManager.RandomAddItem();
        }
    }

    public void OpenInventory()
    {
        //EキーでインベントリのON,OFF切り替え
        if (Input.GetKeyDown(KeyCode.E))
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
        }
    }

}
