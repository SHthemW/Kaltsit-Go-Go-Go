using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameBtn : MonoBehaviour
{
    public void RestartGame()
    {
        SummonEnemy.canSummonEnemy = false;
        SceneManager.LoadScene(0);
    }
}
