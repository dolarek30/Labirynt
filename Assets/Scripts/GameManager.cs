using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField] private int timeToEnd;

    private bool gamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager == null) gameManager = this;
        if (timeToEnd <= 0) timeToEnd = 100;
        InvokeRepeating("Stopper", 2, 1);
    }

    // Update is called once per frame
    void Update()
    {
        PauseCheck();
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log("Time: " + timeToEnd + "s");
        
        if (timeToEnd <= 0) //stop gra gdy czas minie
        {
            Debug.Log("Time's off");
            Time.timeScale = 0f;
            gamePaused = true;
        }
    }

    void PauseGame()
    {
        Debug.Log("Paused Game");
        Time.timeScale = 0f;
        gamePaused = true;
    }

    void ResumeGame()
    {
        Debug.Log("Resumed Game");
        Time.timeScale = 1f;
        gamePaused = false;
    }

    void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused) ResumeGame();
            else PauseGame();
        }
    }
}
