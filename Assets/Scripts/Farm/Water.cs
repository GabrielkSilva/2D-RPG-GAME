using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] bool detectingPlayer;
    [SerializeField] int waterValue;

    PlayerItens playerItens;

    void Awake()
    {
        playerItens = FindAnyObjectByType<PlayerItens>();
    }

    void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            playerItens.Waterlimit(waterValue);
        }
    }

    void OnTriggerEnter2D(Collider2D colission)
    {
        if (colission.CompareTag("Player"))
        {
            detectingPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D colission)
    {
        if (colission.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }
}
