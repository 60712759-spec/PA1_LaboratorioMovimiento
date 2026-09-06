using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento Horizontal")]
    [SerializeField] private float speed = 8f;

    [Header("Sistema de Salto")]
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private float horizontalInput;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Movimiento instantáneo sin inercia (GetAxisRaw)
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Detección física del suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Lógica de salto (solo si toca el suelo)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void FixedUpdate()
    {
        // Aplicar la velocidad al Rigidbody2D
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
    }

    private void OnDrawGizmosSelected()
    {
        // Permite ver el radio de detección de suelo en el editor de Unity
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
