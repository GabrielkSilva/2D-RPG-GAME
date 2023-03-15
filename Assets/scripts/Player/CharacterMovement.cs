using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 10.0f;

    public Rigidbody2D rb;

    public Animator anim;
    Vector2 movement;
    Vector2 lastDirection;

    private void Start()
    {
        lastDirection = Vector2.right; // Inicializa a direção padrão para a direita
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Limita o movimento às 4 direções principais
        if (Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput))
        {
            movement = new Vector2(horizontalInput, 0);
        }
        else
        {
            movement = new Vector2(0, verticalInput);
        }

        anim.SetFloat("Speed", movement.sqrMagnitude);

        if (movement != Vector2.zero) // Se o jogador estiver se movendo
        {
            lastDirection = movement;
            anim.SetFloat("Horizontal", movement.x);
            anim.SetFloat("Vertical", movement.y);
        }
        else // Se o jogador estiver parado
        {
            anim.SetFloat("Horizontal", lastDirection.x);
            anim.SetFloat("Vertical", lastDirection.y);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
