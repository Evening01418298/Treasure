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
    [SerializeField] private float upGreadStamina;

    private bool isRunning;

    [Header("UI")]
    [Tooltip("Option_BGを入れてね")]
    public  GameObject displayWindow;

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
        displayWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //displayWindowが表示されているときはPlayerの入力を拒否
        //本当はゲームタイマーを止めるべき
        if (displayWindow.activeSelf == false)
        {
            Move();
            Look();
        }
        HandleStamina();
        PlayerInput();
    }

    /// <summary>
    /// Playerの入力状況。移動操作以外
    /// </summary>
    public void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool windowIsActive = displayWindow.activeSelf;
            displayWindow.SetActive(!windowIsActive);
            Debug.Log("displayWindowのアクティブ状態は : " + displayWindow.activeSelf);
        }
    }

    /// <summary>
    /// プレイヤーの移動処理
    /// </summary>
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

        if (Input.GetKeyDown(KeyCode.P))
        {
            maxStamina += upGreadStamina;
        }

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

    /// <summary>
    /// プレイヤーのステータスを表示する処理
    /// </summary>
    public void UpdateStaminaUI()
    {
        staminaText.text = $"SP {Mathf.RoundToInt(stamina)} / {maxStamina}";
    }

    /// <summary>
    /// 視点移動の処理
    /// </summary>
    public void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minLookX, maxLookX);
        cameraTrans.localRotation = Quaternion.Euler(rotationX, 0, 0);

        transform.Rotate(Vector3.up * mouseX);
    }

    /// <summary>
    /// アップグレードを取った時の処理
    /// </summary>
    public void UpGread()
    {

    }

    /// <summary>
    /// 敵から被弾したときの処理
    /// </summary>
    public void Damage()
    {

    }

}
