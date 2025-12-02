using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorController : MonoBehaviour
{
    private float timer;

    [Header("カーソルイメージ")]
    [SerializeField] private Image cursorImage;

    [Header("カーソルの色")]
    [SerializeField] private Color32 normalCol;          //通常の色
    [SerializeField] private Color32 hoverCol;           //オブジェクトと重なった時の色

    private float rayDistance = 5f;                     //Rayを飛ばす距離

    Camera cam;

    InteractableObject currentObj;

    private void Start()
    {
        cam = Camera.main;

        normalCol = new Color32(255, 255, 255, 255);        //白
        hoverCol = new Color32(255, 0, 0, 255);             //赤

        cursorImage.color = normalCol;
    }

    private void Update()
    {
        HitToObject();
    }

    /// <summary>
    /// オブジェクトとRayのヒット判定
    /// </summary>
    private void HitToObject()
    {
        Vector3 center = new Vector3(Screen.width / 2f, Screen.height / 2f);

        //Rayを照射
        Ray ray = cam.ScreenPointToRay(center);

        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
        {
            if (hit.collider.CompareTag("TresureBox"))
            {
                cursorImage.color = hoverCol;
                currentObj = hit.collider.GetComponent<InteractableObject>();
            }
            else
            {
                cursorImage.color = normalCol;
            }
        }
        else
        {
            cursorImage.color = normalCol;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(currentObj != null)
            {
                currentObj.OnInteract();
            }
        }
    }
}
