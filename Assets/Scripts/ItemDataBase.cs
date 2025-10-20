using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


[CreateAssetMenu(fileName ="CreateItemBase",menuName ="CreateNewItem/Data Base",order =0)]
public class ItemDataBase : ScriptableObject
{
    public ItemData[] Items;
}
