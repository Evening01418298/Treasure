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

    public void OnInteract()
    {
        Debug.Log($"{gameObject.name} ‚ðŠJ‚¢‚½");
    }

}
