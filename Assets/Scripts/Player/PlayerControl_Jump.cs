using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl_Jump : MonoBehaviour
{
    //prop
    public float jumpForce;

    /// <summary>
    /// 跳跃误差。玩家高度低于该值时允许跳跃。
    /// 过低的值可能会降低灵敏度，过高的值会导致多段跳跃。
    /// </summary>
    public float jumpTolerance;

    //component
    private Rigidbody2D rb;
    private Animator anim;

    //state
    private bool isGrounded;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (GameManager.Instance.PlayerIsDead)
            return;

        Jump();

        isGrounded = CheckGroundState();
        anim.SetBool("isGrounded", isGrounded);
    }


    private void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && transform.position.y <= jumpTolerance)
        {
            anim.SetTrigger("jump");
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    /// <summary>
    /// 检查玩家现在是否落地。
    /// 判定的宽松度由jumpTolerance决定。
    /// </summary>
    /// <returns>判定当前在地上，返回true。</returns>
    private bool CheckGroundState()
    {
        if (transform.position.y <= jumpTolerance)
            return true;
        else
            return false;
    }
}
