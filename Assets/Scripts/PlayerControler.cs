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
        //E�L�[�ŃC���x���g����ON,OFF�؂�ւ�
        if (Input.GetKeyDown(KeyCode.E))
        {
            bool panelIsActive = inventoryPanel.activeSelf;     //inventoryPanel�̃A�N�e�B�u��Ԃ��擾
            inventoryPanel.SetActive(!panelIsActive);           //inventoryPanel�̌���ԂƂ͔��΂ɂ���
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
