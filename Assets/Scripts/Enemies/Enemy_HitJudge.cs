using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ¹¥»÷ÅÐ¶¨¡£
/// </summary>
public class Enemy_HitJudge : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Animator>().SetBool("isDead", true);
            GameManager.Instance.PlayerIsDead = true;
        }
    }
}
