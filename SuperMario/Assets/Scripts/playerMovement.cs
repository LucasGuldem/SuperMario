using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento do jogador
    public float jumpForce = 10f; // For�a do pulo

    public Transform groundCheck; // Refer�ncia ao objeto usado para verificar se o jogador est� no ch�o
    public LayerMask groundLayer; // Camada que representa o ch�o

    private Rigidbody2D rb;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica se o jogador est� no ch�o
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // Movimento horizontal
        float moveInput = Input.GetAxis("Horizontal"); // Obt�m a entrada do teclado (A/D ou Setas)
        Vector2 moveVelocity = new Vector2(moveInput * moveSpeed, rb.velocity.y); // Define a velocidade de movimento horizontal
        rb.velocity = moveVelocity; // Aplica a velocidade ao Rigidbody do jogador

        // Pulando
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    void FixedUpdate()
    {
        // Desenhar uma linha para verificar a detec��o de ch�o (apenas para fins de depura��o)
        Debug.DrawLine(transform.position, groundCheck.position, Color.red);
    }
}
