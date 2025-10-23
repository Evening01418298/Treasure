using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("移動速度")]
    public float moveSpeed = 5f;
    [Header("重力")]
    public float gravity = -9.8f;
    [Header("ジャンプの高さ")]
    public float jampHight = 1.5f;


    [Header("カメラ関連")]
    public Transform cameraTrans;
    [Tooltip("カメラの感度")]
    public float mouseSensitivity = 2f;
    [Tooltip("カメラが上に向ける最大の角度")]
    public float maxLookX = 80f;
    [Tooltip("カメラが下に向ける最大の角度Y")]
    public float minLookX = -80f;

    private CharacterController controller;
    private float rotationX = 0f;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Look();
    }

    public void Move()
    {
        
    }

    public void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minLookX, maxLookX);
        cameraTrans.localRotation = Quaternion.Euler(rotationX, 0, 0);

        transform.Rotate(Vector3.up * mouseX);
    }
}
