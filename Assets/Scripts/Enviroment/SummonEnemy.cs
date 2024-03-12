using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonEnemy : MonoBehaviour
{
    public GameObject enemy;

    /// <summary>
    /// 能够生成怪物的格子
    /// </summary>
    public Transform[] summonPostions;

    /// <summary>
    /// 每个格子生成怪物的(平均)几率
    /// </summary>
    [Range(0, 1)] public float summonRange = 0.1f;

    /// <summary>
    /// 怪物间的最小间距。
    /// 如果生成怪物时在该范围内存在其它怪物，则该怪物无法被生成。
    /// </summary>
    public float minSummonSpace;

    [Range(-10,10)] public float heightOffset;

    /// <summary>
    /// 可生成怪物吗？
    /// （默认在游戏开始一段时间后才开始生成怪物）
    /// </summary>
    public static bool canSummonEnemy = false;


    private void Start()
    {
        for (int i = 0; i < summonPostions.Length; i++)
        {
            float random = Random.Range(0f, 1f);           

            if (random <= summonRange && canSummonEnemy)
            {               
                Vector3 summonPosition = new Vector3(summonPostions[i].position.x, summonPostions[i].position.y + heightOffset, summonPostions[i].position.z);

                Collider2D other = Physics2D.OverlapCircle(summonPosition, minSummonSpace, 1<<6);

                if (other == null)
                    Instantiate(enemy, summonPosition, summonPostions[i].rotation, summonPostions[i]);
            }
        }
    }

    /// <summary>
    /// 清除已生成的敌人
    /// </summary>
    public void DestoryEnemies()
    {
        for (int i = 0; i < summonPostions.Length; i++)
        {
            if (summonPostions[i].childCount > 0)
                Destroy(summonPostions[i].GetChild(0).gameObject);
        }
    }

}
