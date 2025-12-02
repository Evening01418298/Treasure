using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [System.Serializable]
    public class Item
    {
        public string itemName;
    }

    public Item[] items;

    private void Awake()
    {
        items = new Item[1];
    }

    public void OnInteract()
    {
        Debug.Log($"{gameObject.name} ‚ðŠJ‚¢‚½");

        InventoryUI.Instance.ShowItems(items);
    }

}
