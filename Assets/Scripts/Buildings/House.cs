using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [Header("AMOUNTS")]
    [SerializeField] int woodAmount;
    [SerializeField] Color startColor;
    [SerializeField] Color endColor;
    [SerializeField] float timeAmount;

    [Header("COMPONENTS")]
    [SerializeField] GameObject houseCollider;
    [SerializeField] SpriteRenderer houseSprite;
    [SerializeField] Transform point;

    bool detectingPlayer;
    Player player;
    PlayerItens playerItens;
    PlayerAnim playerAnim;

    float timeCount;
    bool isBegining;

    void Awake()
    {
        player = FindAnyObjectByType<Player>();
        playerAnim = player.GetComponent<PlayerAnim>();
        playerItens = player.GetComponent<PlayerItens>();
    }

    void Start()
    {

    }

    void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E) && playerItens.currentWood >= woodAmount)
        {
            //Construção inicializada
            isBegining = true;
            playerAnim.OnHammeringStarted();
            houseSprite.color = startColor;
            player.transform.position = point.position;
            player.isPaused = true;
            playerItens.currentWood -= woodAmount;
        }

        if (isBegining)
        {
            timeCount += Time.deltaTime;

            if (timeCount >= timeAmount)
            {
                // Casa é finalizada
                playerAnim.OnHammeringEnded();
                houseSprite.color = endColor;
                player.isPaused = false;
                houseCollider.SetActive(true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }


}
