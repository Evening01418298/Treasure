using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public List<ItemData> items = new List<ItemData>();

    public void Interact()
    {
        InventoryUI.Instance.ShowItems(this);
    }
}
