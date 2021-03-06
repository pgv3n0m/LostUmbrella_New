﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour, IUpdateable
{

    public enum GameState { Tutorial, Started, Completed }

    public GameState gameState;

    public float timer;
    public UmbrellaScript _umbrella;
    public ParticleSystem _rain;
    public UIController _uicontroller;

    public float _distance;
    public Transform _endTrigger;

    public GameLogic gl;
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1.0f;
        gl.RegisterUpdateObject(this);

    }

    // Update is called once per frame


    public void StartGame() 
    {
        Time.timeScale = 1.0f;
        _uicontroller.TutorialPanel.SetActive(false);
        _uicontroller.InGameUIPanel.SetActive(true);
        gameState = GameState.Started;
    }

    public void GameCompleted() // Show the Game Complete Screen - is called by the Completed Trigger
    {
        Time.timeScale = 0.0f;
        _uicontroller.LevelCompletedPanel.SetActive(true);
        gameState = GameState.Completed;
    }

    public void ExitTutorial() // Starts the Timer & Game when you hits Exit Tutorial Trigger
    {
        gameState = GameState.Started;
        _uicontroller.TutorialPanel.SetActive(false);
    }

    public virtual void OnUpdate(float dt)
    {
    
            if (gameState == GameState.Started)
        {
            timer += dt;

            // Converts delta time to second and minutes
            string minutes = Mathf.Floor(timer / 60).ToString("00");
            string seconds = (timer % 60).ToString("00");

            // Shows the timer in string format on canvas Text Component
            _uicontroller.timer.text = string.Format("{0}:{1}", minutes, seconds);

            // Also updates the final_time text for the game complete screen
            _uicontroller.final_time.text = "Your Score: " + _uicontroller.timer.text;
        }
        else if (gameState == GameState.Completed && Input.GetKeyUp(KeyCode.R)) // When game is completed then it can be restarted by pressing R
            SceneManager.LoadScene(0);


        // Increase the Rain Particle Rate based on distance from the End Game Trigger
        _distance = Mathf.Abs((Vector3.Distance(_endTrigger.position, _umbrella.transform.position) - 315f));
        var emission = _rain.emission;
        emission.rateOverTime = 2.0f * _distance;

    }
}
