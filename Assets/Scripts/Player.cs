using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public bool isPaused;

    [SerializeField] float speed;
    [SerializeField] float runSpeed;

    Rigidbody2D rig;
    PlayerItens playerItens;

    // Atributes
    float initialSpeed;
    bool _isRunning;
    bool _isRolling;
    bool _isCutting;
    bool _isDigging;
    bool _iswatering;
    Vector2 _direction;

    int _handlingObj;

    public Vector2 direction { get => _direction; set => _direction = value; }
    public bool isRunning { get => _isRunning; set => _isRunning = value; }
    public bool isRolling { get => _isRolling; set => _isRolling = value; }
    public bool isCutting { get => _isCutting; set => _isCutting = value; }
    public bool isDigging { get => _isDigging; set => _isDigging = value; }
    public bool iswatering { get => _iswatering; set => _iswatering = value; }
    public int handlingObj { get => _handlingObj; set => _handlingObj = value; }

    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        playerItens = GetComponent<PlayerItens>();
    }

    void Start()
    {
        initialSpeed = speed;
    }

    void Update()
    {
        if (!isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                handlingObj = 0;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                handlingObj = 1;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                handlingObj = 2;
            }

            OnInput();
            OnRun();
            OnRolling();
            OnCutting();
            OnDig();
            OnWatering();
        }
    }

    void FixedUpdate()
    {
        if (!isPaused)
            OnMove();
    }

    #region  Movement

    void OnInput()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        rig.MovePosition(rig.position + direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            isRunning = false;
        }
    }

    void OnRolling()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRolling = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            isRolling = false;
        }
    }

    void OnCutting()
    {
        if (handlingObj == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isCutting = true;
                speed = 0;
            }

            if (Input.GetMouseButtonUp(0))
            {
                isCutting = false;
                speed = initialSpeed;
            }
        }
    }

    void OnDig()
    {
        if (handlingObj == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDigging = true;
                speed = 0;
            }

            if (Input.GetMouseButtonUp(0))
            {
                isDigging = false;
                speed = initialSpeed;
            }
        }
    }

    void OnWatering()
    {
        if (handlingObj == 2)
        {
            if (Input.GetMouseButtonDown(0) && playerItens.currentWater > 0)
            {
                iswatering = true;
                speed = 0;
            }

            if (Input.GetMouseButtonUp(0) || playerItens.currentWater < 0)
            {
                iswatering = false;
                speed = initialSpeed;
            }

            if (iswatering)
            {
                playerItens.currentWater -= 0.01f;
            }
        }
    }

    #endregion
}
