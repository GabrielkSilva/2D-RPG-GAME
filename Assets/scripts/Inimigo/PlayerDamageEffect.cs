using System.Collections;
using UnityEngine;

public class PlayerDamageEffect : MonoBehaviour
{
    public float damageInterval = 1.0f; // Intervalo de tempo entre cada dano
    public Color damageColor = Color.red; // Cor usada quando o jogador sofre dano
    public float blinkDuration = 0.2f; // Duração do efeito de piscar

    private SpriteRenderer spriteRenderer;
    private float damageTimer; // Temporizador para controlar o dano
    private Color originalColor; // Cor original do jogador

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    private void Update()
    {
        // Reduz o temporizador a cada frame
        if (damageTimer > 0)
        {
            damageTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && damageTimer <= 0)
        {
            // Cria o efeito visual de dano
            StartCoroutine(BlinkEffect());

            // Aqui você pode adicionar a lógica para aplicar dano ao jogador, se necessário

            // Reinicia o temporizador
            damageTimer = damageInterval;
        }
    }

    private IEnumerator BlinkEffect()
    {
        // Altera a cor do jogador para a cor de dano
        spriteRenderer.color = damageColor;

        // Aguarda a duração do efeito de piscar
        yield return new WaitForSeconds(blinkDuration);

        // Retorna a cor original do jogador
        spriteRenderer.color = originalColor;
    }
}
