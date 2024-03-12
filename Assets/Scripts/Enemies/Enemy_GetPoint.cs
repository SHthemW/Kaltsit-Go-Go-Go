using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_GetPoint : MonoBehaviour
{
    private GameObject player;

    private bool isGotPoint = false;

    private void Awake()
    {
        player = GameObject.Find("KELTHIT");
    }

    private void Update()
    {
        if (transform.position.x <= player.transform.position.x && !isGotPoint)
        {
            GameManager.Instance.UpdateScore();
            isGotPoint = true;
        }
    }


}
