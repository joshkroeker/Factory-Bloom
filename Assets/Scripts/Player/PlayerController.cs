using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Required Components")]
    [SerializeField] InputManager input;
    [SerializeField] Rigidbody2D rb;
    
    [Header("Movement Values")]
    [SerializeField] float moveSpeed;
    [SerializeField] float linearDrag;
    [SerializeField] float angularDrag;
    
    Vector2 moveInput;
    bool isMovementPressed;

    void Awake()
    {
        input ??= FindAnyObjectByType<InputManager>();
        rb ??= GetComponent<Rigidbody2D>();
        
        rb.linearDamping = linearDrag;
        rb.angularDamping = angularDrag;

        if (input is null)
        {
            Debug.LogError($"{nameof(PlayerController)}.{nameof(Awake)}: InputManager is null in PlayerController!");
        }
    }

    void OnEnable()
    {
        input.OnPlayerMove += OnMoveInputRead;
    }

    void OnDisable()
    {
        input.OnPlayerMove -= OnMoveInputRead;
    }

    void OnMoveInputRead(Vector2 readInput)
    {
        moveInput = readInput;
        isMovementPressed = readInput.x != 0 || readInput.y != 0;
    }
    
    void FixedUpdate()
    {
        HandleLinearDamping();
        Move();
    }

    void Move()
    {
        if (!isMovementPressed) return;
        var normalizedMove = moveInput.normalized;
        rb.AddForce(normalizedMove * moveSpeed, ForceMode2D.Force);
    }

    void HandleLinearDamping() => rb.linearDamping = isMovementPressed ? 0f : linearDrag;
}
