using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    Player player;
    Animator anim;
    Casting casting;

    void Awake()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
        casting = FindAnyObjectByType<Casting>();
    }

    void Update()
    {
        OnMove();
        OnRun();
    }

    #region Movement

    void OnMove()
    {
        if (player.direction.sqrMagnitude > 0)
        {
            if (player.isRolling)
            {
                anim.SetTrigger("isRoll");
            }
            else
            {
                anim.SetInteger("transition", 1);
            }
        }
        else
        {
            anim.SetInteger("transition", 0);
        }

        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

        // Cortando Árvore
        if (player.isCutting)
        {
            anim.SetInteger("transition", 3);
        }

        // Cavando
        if (player.isDigging)
        {
            anim.SetInteger("transition", 4);
        }

        // Regando
        if (player.iswatering)
        {
            anim.SetInteger("transition", 5);
        }
    }

    // Correndo
    void OnRun()
    {
        if (player.isRunning)
        {
            anim.SetInteger("transition", 2);
        }
    }

    #endregion

    // Pesca
    public void OnCastingStarted()
    {
        anim.SetTrigger("isCasting");
        player.isPaused = true;
    }

    public void OnCastingEnded()
    {
        casting.OnCasting();
        player.isPaused = false;
    }

    // Construção
    public void OnHammeringStarted()
    {
        anim.SetBool("hammering", true);
    }

    public void OnHammeringEnded()
    {
        anim.SetBool("hammering", false);
    }

}