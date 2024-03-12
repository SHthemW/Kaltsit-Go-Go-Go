using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public GameObject backgroundPrefeb;  

    [Header("Properties")]
    public float speed_percentage;  // 移动速度相对于speed_Ground的百分比
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
        //获取移动速度
        speed_backGround = GameManager.Instance.gameSpeedData.ground_MoveSpeed * speed_percentage;
    }

    private void Update()
    {
        ///MOVE
        transform.Translate(-speed_backGround * Time.deltaTime, 0, 0, Space.World);

        if (transform.position.x <= disappearPos_X)
            DestoryOldGroundAndGenerateNew();

        //获取移动速度
        speed_backGround = GameManager.Instance.gameSpeedData.ground_MoveSpeed * speed_percentage;
    }

    private void DestoryOldGroundAndGenerateNew()
    {
        GenerateNewGround();
        Destroy(gameObject);
    }


    private void GenerateNewGround()
    {
        // 根据newPosition，获得新背景块的生成位置。
        // 可以调整数值来调整误差
        Vector2 summonPos = new Vector2(newPositionTransfrom.position.x, newPositionTransfrom.position.y);

        Instantiate(backgroundPrefeb, summonPos, newPositionTransfrom.rotation, parentTransform);

    }

}
