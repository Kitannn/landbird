using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text PointDisplay;

    //public GameObject gameOverCanvas;
    public Button restartButton;
    public Button startButton;

    //private float Points;
    private float gameTime;
    private bool gameStart;
    GameObject PointsFromObstacle;
    public Move movescript;
    float pointCount;

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true); //is supposed to just turn on restartButton
        gameStart = false;
        //gameOverCanvas.SetActive(true); game stops
        Time.timeScale = 0; 
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        PointDisplay = PointDisplay.GetComponent<TMP_Text>();
        PointsFromObstacle = GameObject.Find("MainCharacter");
        gameStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Jump"))
        {
            PressStart();
        }
        else if(gameStart)
        {
            gameTime = Mathf.Floor(Time.timeSinceLevelLoad * 10);
            pointCount = movescript.Points;

            PointDisplay.SetText("Points: " + (gameTime + pointCount).ToString());

            //Debug.Log("Inside gamemanager: " + (pointCount + gameTime));
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void PressStart()
    {
        startButton.gameObject.SetActive(false);
        gameStart = true;
    }

    /*public bool GameStarted()
    {
        if (gameStart)
        {
            Debug.Log("called true");
            return true;
        }
        else
        {
            Debug.Log("called false");
            return false;
        }
    }*/
}
