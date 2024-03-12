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

    [Tooltip("开始生成怪物的延迟时间")]
    public float delaySummonTime;

    [Tooltip("游戏速度属性")]
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
    /// 更新玩家得分
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
    /// 开始生成怪物
    /// </summary>
    private void StartToSummonEnemy()
    {
        SummonEnemy.canSummonEnemy = true;
    }

    /// <summary>
    /// 设置游戏的速度
    /// </summary>
    private void SetGameSpeed()
    {
        //增加地块移动速度
        gameSpeedData.ground_MoveSpeed += gameSpeedData.ground_SpeedAddition;
        ///（背景的速度会随地块速度的变化而按比例变化）

        //增加玩家动画速度
        playerAnim.speed += gameSpeedData.ground_SpeedAddition * 0.1f;
    }

    private void ShowRestartButton()
    {
        restartButton.gameObject.SetActive(true);
    }

}
