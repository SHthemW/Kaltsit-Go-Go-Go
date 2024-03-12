using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public GameObject backgroundPrefeb;  

    [Header("Properties")]
    public float speed_percentage;  // �ƶ��ٶ������speed_Ground�İٷֱ�
    public string transfromName;
    public float disappearPos_X;

    private float speed_backGround;
    private Transform newPositionTransfrom;
    private Transform parentTransform;

    private void Awake()
    {        
        newPositionTransfrom = GameObject.Find(transfromName).transform;
        parentTransform = GameObject.Find("Sky").transform;
    }

    private void Start()
    {
        //��ȡ�ƶ��ٶ�
        speed_backGround = GameManager.Instance.gameSpeedData.ground_MoveSpeed * speed_percentage;
    }

    private void Update()
    {
        ///MOVE
        transform.Translate(-speed_backGround * Time.deltaTime, 0, 0, Space.World);

        if (transform.position.x <= disappearPos_X)
            DestoryOldGroundAndGenerateNew();

        //��ȡ�ƶ��ٶ�
        speed_backGround = GameManager.Instance.gameSpeedData.ground_MoveSpeed * speed_percentage;
    }

    private void DestoryOldGroundAndGenerateNew()
    {
        GenerateNewGround();
        Destroy(gameObject);
    }


    private void GenerateNewGround()
    {
        // ����newPosition������±����������λ�á�
        // ���Ե�����ֵ���������
        Vector2 summonPos = new Vector2(newPositionTransfrom.position.x, newPositionTransfrom.position.y);

        Instantiate(backgroundPrefeb, summonPos, newPositionTransfrom.rotation, parentTransform);

    }

}
