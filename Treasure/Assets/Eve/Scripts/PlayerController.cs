using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("移動関連設定")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float runSpeed = 20f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float jumpHeight = 1.5f;

    [Header("スタミナ設定")]
    [SerializeField] private float maxStamina = 40f;
    [SerializeField] private float staminaUseRate = 5f;
    [SerializeField] private float staminaRecoverRate = 2f;
    [SerializeField] private Text staminaText;
    [HideInInspector]
    [SerializeField] private float stamina;


    private bool isRunning;


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
        stamina = maxStamina;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        HandleStamina();
        Look();
    }

    public void Move()
    {
        // 地面に接しているかチェック
        bool isGrounded = controller.isGrounded;

        // 接地中で下方向に速度が残っている場合はリセット（地面に吸着）
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        // WASD入力を取得
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // プレイヤーの向き（forward/right）を基準に移動方向を決定
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // 実際の移動処理
        controller.Move(move * moveSpeed * Time.deltaTime);

        //ダッシュ判定
        bool canRun = stamina > 0f;
        isRunning = Input.GetKey(KeyCode.LeftShift) && canRun && (moveX != 0 || moveZ != 0);

        float currentSpeed = isRunning ? runSpeed : moveSpeed;
        controller.Move(move * currentSpeed * Time.deltaTime);

        // ジャンプ入力
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // v = √(2 * g * h) から求めた初速度を設定
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // 重力を加算
        velocity.y += gravity * Time.deltaTime;

        // 垂直方向の移動も反映
        controller.Move(velocity * Time.deltaTime);
    }
    /// <summary>
    /// スタミナ回復や消費。UIへの反映
    /// </summary>
    void HandleStamina()
    {
        if(isRunning)
        {
            stamina -= staminaUseRate * Time.deltaTime;
            stamina = Mathf.Max(stamina, 0f);
        }
        else
        {
            stamina += staminaRecoverRate * Time.deltaTime;
            stamina = Mathf.Min(stamina, maxStamina);
        }
        UpdateStaminaUI();
    }

    public void UpdateStaminaUI()
    {
        staminaText.text = $"SP {Mathf.RoundToInt(stamina)} / {maxStamina}";
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
