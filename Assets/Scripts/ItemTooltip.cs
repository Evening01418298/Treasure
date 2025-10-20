using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    [SerializeField] private Text nameText;
    [SerializeField] private Text qualityText;
    [SerializeField] private Text priceText;

    private void Awake()
    {
        gameObject.SetActive(false);    
    }

    public void ShowTootip(string name, Quality quality, int price)
    {
        gameObject.SetActive(true);

        nameText.text = "���O :" + name;
        qualityText.text = "�i�� :" + quality.ToString();
        priceText.text = "���i :$" + price.ToString();
    }

    public void HideTooltips()
    {
        gameObject.SetActive(false);
    }
}
