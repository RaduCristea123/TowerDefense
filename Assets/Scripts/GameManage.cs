using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    private bool gameEnded = false;
    [SerializeField] GameObject gameOver;

    void Update()
    {
        if (gameEnded)
        {
            return;
        }

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if (Stats.lives <= 0)
        {
            EndGame();
        }     
    }

    void EndGame ()
    {
        gameEnded = true;
        gameOver.SetActive(true);
        Time.timeScale = 0f;
        PauseMenu.isPaused = true;
    }
}
