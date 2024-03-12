using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager instance;
    public static GameManager Instance { get => instance; }
    
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }
    #endregion

    [Header("Game Properties")]

    [Tooltip("��ʼ���ɹ�����ӳ�ʱ��")]
    public float delaySummonTime;

    [Tooltip("��Ϸ�ٶ�����")]
    public SpeedData gameSpeedData;

    

    private void Start()
    {
        Invoke("StartToSummonEnemy", delaySummonTime);
    }

    private void Update()
    {
        if (PlayerIsDead)
            Invoke("ShowRestartButton", 3.0f);
    }

    [Header("UI")]
    public TextMeshProUGUI scoreText;
    public int score = 0;
    public Button restartButton;

    [Header("Game State")]
    public bool PlayerIsDead = false;

    [Header("Player")]
    public Animator playerAnim;

    /// <summary>
    /// ������ҵ÷�
    /// </summary>
    public void UpdateScore()
    {
        if (PlayerIsDead)
            return;

        score++;
        scoreText.text = score.ToString();

        SetGameSpeed();
    }

    /// <summary>
    /// ��ʼ���ɹ���
    /// </summary>
    private void StartToSummonEnemy()
    {
        SummonEnemy.canSummonEnemy = true;
    }

    /// <summary>
    /// ������Ϸ���ٶ�
    /// </summary>
    private void SetGameSpeed()
    {
        //���ӵؿ��ƶ��ٶ�
        gameSpeedData.ground_MoveSpeed += gameSpeedData.ground_SpeedAddition;
        ///���������ٶȻ���ؿ��ٶȵı仯���������仯��

        //������Ҷ����ٶ�
        playerAnim.speed += gameSpeedData.ground_SpeedAddition * 0.1f;
    }

    private void ShowRestartButton()
    {
        restartButton.gameObject.SetActive(true);
    }

}
