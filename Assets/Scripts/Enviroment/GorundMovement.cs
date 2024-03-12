using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorundMovement : MonoBehaviour
{
    public GameObject groundPrefeb;
    public Transform[] summonPostions;

    [Header("Properties")]
    public static float speed_Ground;
    public Transform newPosition;
    public string posName;

    private Transform parentTransform;
    


    private void Awake()
    {
        newPosition = GameObject.Find(posName).transform;
        parentTransform = GameObject.Find("Ground").transform;
    }

    private void Start()
    {
        speed_Ground = GameManager.Instance.gameSpeedData.ground_MoveSpeed;
    }

    private void Update()
    {
        //MOVE
        transform.Translate(-speed_Ground * Time.deltaTime, 0, 0, Space.World);

        //����ɵذ壬�����µذ�
        if (transform.position.x <= -11f)
            CleanCurrentGround();

        if (transform.position.x <= -12f)
            DestoryOldGroundAndGenerateNew();

        //ʵʱ��ȡ�ٶ�
        speed_Ground = GameManager.Instance.gameSpeedData.ground_MoveSpeed;
    }


    private void CleanCurrentGround()
    {      
        //����ǰ�����ɵĵ��ˣ���һ���հ׵�prefeb
        for (int i = 0; i < summonPostions.Length; i++)
        {
            if (summonPostions[i].childCount > 0)
            {
                Destroy(summonPostions[i].GetChild(0).gameObject);
                groundPrefeb = gameObject;
            }
        }
    }


    private void DestoryOldGroundAndGenerateNew()
    {               
        GenerateNewGround();
        Destroy(gameObject);      
    }

    private void GenerateNewGround()
    {
        // ����newPosition������µؿ������λ�á�
        // ���Ե�����ֵ���������
        Vector2 summonPos = new Vector2(newPosition.position.x, newPosition.position.y);

        // �����µؿ�
        Instantiate(groundPrefeb, summonPos, newPosition.rotation, parentTransform);
    }

    
}
