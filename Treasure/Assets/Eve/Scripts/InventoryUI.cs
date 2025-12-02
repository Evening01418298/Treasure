using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    [SerializeField] private GameObject uiPanel;
    [SerializeField] private Text itemName;

    private bool panelIsActive;

    private void Awake()
    {
        Instance = this;
    }

    private void ShowItems(InteractableObject.Item[] items)
    {
        uiPanel.SetActive(true);

        itemName.text = "";
        foreach(var i in items)
        {
            itemName.text = "-" + i.itemName + "\n";
        }

    }
}
