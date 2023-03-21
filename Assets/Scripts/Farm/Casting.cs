using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
{
    bool detectingPlayer;

    [SerializeField] int percentage; // chance de pesca
    [SerializeField] GameObject fishPrefab;

    PlayerItens playerItens;
    PlayerAnim playerAnim;

    void Awake()
    {
        playerItens = FindAnyObjectByType<PlayerItens>();
        playerAnim = playerItens.GetComponent<PlayerAnim>();
    }

    void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            playerAnim.OnCastingStarted();
        }
    }

    public void OnCasting()
    {
        int randomValue = Random.Range(1, 100);

        if (randomValue <= percentage)
        {
            Instantiate(fishPrefab, playerItens.transform.position + new Vector3(Random.Range(-3f, -1f), 0, 0), Quaternion.identity);
        }
        else
        {
            Debug.Log("não pescou");
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
