using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public enum GameState { Tutorial, Started, Completed, Failed }

    public GameState gameState;

    public float timer;
    public UIController _uicontroller;
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame

    public void StartGame()
    {
        Time.timeScale = 1.0f;
        _uicontroller.TutorialPanel.SetActive(false);
        _uicontroller.InGameUIPanel.SetActive(true);
        gameState = GameState.Started;
    }

    public void GameCompleted()
    {
        Time.timeScale = 0.0f;
        _uicontroller.LevelCompletedPanel.SetActive(true);
    }

    public void ExitTutorial()
    {
        gameState = GameState.Started;
        _uicontroller.TutorialPanel.SetActive(false);
    }

    void Update()
    {
        if (gameState == GameState.Started)
        {
            timer += Time.deltaTime;

            string minutes = Mathf.Floor(timer / 60).ToString("00");
            string seconds = (timer % 60).ToString("00");


            _uicontroller.timer.text = string.Format("{0}:{1}", minutes, seconds);
            _uicontroller.final_time.text = "Your Score: " + _uicontroller.timer.text;
        }
        
    }
}
