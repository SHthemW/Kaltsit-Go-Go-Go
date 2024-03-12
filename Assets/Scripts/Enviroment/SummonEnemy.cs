using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonEnemy : MonoBehaviour
{
    public GameObject enemy;

    /// <summary>
    /// �ܹ����ɹ���ĸ���
    /// </summary>
    public Transform[] summonPostions;

    /// <summary>
    /// ÿ���������ɹ����(ƽ��)����
    /// </summary>
    [Range(0, 1)] public float summonRange = 0.1f;

    /// <summary>
    /// ��������С��ࡣ
    /// ������ɹ���ʱ�ڸ÷�Χ�ڴ������������ù����޷������ɡ�
    /// </summary>
    public float minSummonSpace;

    [Range(-10,10)] public float heightOffset;

    /// <summary>
    /// �����ɹ�����
    /// ��Ĭ������Ϸ��ʼһ��ʱ���ſ�ʼ���ɹ��
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
    /// ��������ɵĵ���
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
