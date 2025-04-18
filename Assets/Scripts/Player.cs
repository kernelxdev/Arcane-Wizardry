using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;

    void Awake()
    {
        if (Instance != null) Destroy(this);
        Instance = this;
        
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        
        Vector2 normalizedInput = moveInput.normalized;
        
        moveVelocity = normalizedInput * moveSpeed;
        
        rb.linearVelocity = moveVelocity;
    }
}