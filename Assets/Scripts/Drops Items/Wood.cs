using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float timeMove;

    float timeCount;

    void Update()
    {
        timeCount += Time.deltaTime;

        if (timeCount < timeMove)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D colission)
    {
        if (colission.CompareTag("Player"))
        {
            colission.GetComponent<PlayerItens>().currentWood++;
            Destroy(gameObject);
        }
    }
}
