using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D colission)
    {
        if (colission.CompareTag("Player"))
        {
            colission.GetComponent<PlayerItens>().currentFishes++;
            Destroy(gameObject);
        }
    }
}
