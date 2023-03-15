using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2.0f;
    public float updateFrequency = 0.5f;
    public float stopDistance = 0.1f;

    private Rigidbody2D rb;
    private bool isCollidingWithPlayer = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(FollowPlayer());
    }

    private IEnumerator FollowPlayer()
    {
        while (true)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            float distance = Vector2.Distance(player.position, transform.position);

            if (distance > stopDistance && !isCollidingWithPlayer)
            {
                float horizontalInput = Mathf.Round(direction.x);
                float verticalInput = Mathf.Round(direction.y);

                Vector2 movement;

                if (Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput))
                {
                    movement = new Vector2(horizontalInput, 0);
                }
                else
                {
                    movement = new Vector2(0, verticalInput);
                }

                rb.velocity = movement * moveSpeed;
            }
            else
            {
                rb.velocity = Vector2.zero;
            }

            yield return new WaitForSeconds(updateFrequency);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isCollidingWithPlayer = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isCollidingWithPlayer = false;
        }
    }
}
