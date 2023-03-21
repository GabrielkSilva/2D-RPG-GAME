using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite hole;
    [SerializeField] Sprite carrot;

    [Header("Settings")]
    [SerializeField] int digAmount;
    [SerializeField] float waterAmout;

    [SerializeField] bool detecting;

    int initialDigAmoun;
    float currentWater;

    bool dugHole;

    PlayerItens playerItens;

    void Awake()
    {
        playerItens = FindAnyObjectByType<PlayerItens>();
    }

    void Start()
    {
        initialDigAmoun = digAmount;

    }

    void Update()
    {
        if (dugHole)
        {
            if (detecting)
            {
                currentWater += 0.01f;
            }

            // encheu o total de agua necessario
            if (currentWater >= waterAmout)
            {
                spriteRenderer.sprite = carrot;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    spriteRenderer.sprite = hole;
                    playerItens.currentCarrots++;
                    currentWater = 0;
                }
            }
        }
    }

    public void OnHit()
    {
        digAmount--;

        if (digAmount <= initialDigAmoun / 2)
        {
            spriteRenderer.sprite = hole;
            dugHole = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collisison)
    {
        if (collisison.CompareTag("Dig"))
        {
            OnHit();
        }

        if (collisison.CompareTag("Water"))
        {
            detecting = true;
        }
    }

    void OnTriggerExit2D(Collider2D collisison)
    {
        if (collisison.CompareTag("Water"))
        {
            detecting = false;
        }
    }
}
