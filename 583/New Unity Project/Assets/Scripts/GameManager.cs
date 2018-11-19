using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int lives;
    public int score;
    public Text livesText;
    public Text scoreText;
    public bool gameOver;
    public GameObject gameOverPanel;
    public int numBricks;

	// Use this for initialization
	void Start () {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        numBricks = GameObject.FindGameObjectsWithTag("brick").Length;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateLives(int lifeChange){
        lives += lifeChange;
        if(lives <= 0){
            lives = 0;
            GameOver();
        }
        livesText.text = "Lives: " + lives;
    }

    public void UpdateScore(int points){
        score += points;

        scoreText.text = "Score: " + score;
    }

    void GameOver(){
        gameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain(){
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }

    public void UpdateNumBricks(){
        numBricks--;
        if(numBricks <= 0){
            GameOver();
        }
    }

}
