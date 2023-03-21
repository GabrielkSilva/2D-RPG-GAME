using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] float treeHealt;
    [SerializeField] Animator anim;

    [SerializeField] GameObject woodPrefab;
    [SerializeField] int totalWood;

    [SerializeField] ParticleSystem leafs;

    bool isCut;

    public void OnHit()
    {
        treeHealt--;

        anim.SetTrigger("isHit");
        leafs.Play();

        if (treeHealt <= 0 && !isCut)
        {
            for (int i = 0; i < totalWood; i++)
            {
                Instantiate(woodPrefab, transform.position + new Vector3(Random.Range(-0.5f, 0.5f),Random.Range(-0.5f, 0.5f), 0f), transform.rotation);
            }
            // cria o toco e instancia os drops (madeira)
            anim.SetTrigger("cut");

            isCut = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collisison)
    {
        if (collisison.CompareTag("Axe") && !isCut)
        {
            OnHit();
        }
    }
}
