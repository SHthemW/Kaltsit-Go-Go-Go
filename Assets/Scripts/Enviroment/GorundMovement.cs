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

        //清理旧地板，生成新地板
        if (transform.position.x <= -11f)
            CleanCurrentGround();

        if (transform.position.x <= -12f)
            DestoryOldGroundAndGenerateNew();

        //实时获取速度
        speed_Ground = GameManager.Instance.gameSpeedData.ground_MoveSpeed;
    }


    private void CleanCurrentGround()
    {      
        //清理当前已生成的敌人，留一个空白的prefeb
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
        // 根据newPosition，获得新地块的生成位置。
        // 可以调整数值来调整误差
        Vector2 summonPos = new Vector2(newPosition.position.x, newPosition.position.y);

        // 生成新地块
        Instantiate(groundPrefeb, summonPos, newPosition.rotation, parentTransform);
    }

    
}
