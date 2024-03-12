using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl_Move : MonoBehaviour
{
    //prop
    public float moveSpeed;


    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
            Move("left");
        if (Input.GetKey(KeyCode.D))
            Move("right");
    }

    public void Move(string direction)
    {
        switch (direction)
        {
            case "left":
                transform.Translate(-moveSpeed * Time.fixedDeltaTime, 0, 0, Space.World);
                break;
            case "right":
                transform.Translate(moveSpeed * Time.fixedDeltaTime * 0.5f, 0, 0, Space.World);
                break;
        }
    }
}
