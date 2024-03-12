using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl_Jump : MonoBehaviour
{
    //prop
    public float jumpForce;

    /// <summary>
    /// ��Ծ����Ҹ߶ȵ��ڸ�ֵʱ������Ծ��
    /// ���͵�ֵ���ܻή�������ȣ����ߵ�ֵ�ᵼ�¶����Ծ��
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
    /// �����������Ƿ���ء�
    /// �ж��Ŀ��ɶ���jumpTolerance������
    /// </summary>
    /// <returns>�ж���ǰ�ڵ��ϣ�����true��</returns>
    private bool CheckGroundState()
    {
        if (transform.position.y <= jumpTolerance)
            return true;
        else
            return false;
    }
}
