using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static Vector2 bottomLeft;
    public static bool gameOver;
    public GameObject gameOverPanel;
    public static bool gameStarted;
    public GameObject GetReady;
    public static int gameScore;
    public GameObject score;

    private void Awake()
    {
        bottomLeft = Camera.main.ScreenToViewportPoint(new Vector2(0, 0));
    }
    private void Start()
    {
        gameOver = false;
        gameStarted = false;
    }
    public void RessartButon()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameHasStarted()
    {
        gameStarted = true;
        GetReady.SetActive(false);
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        score.SetActive(false);
        gameScore = score.GetComponent<Score>().GetScore();
    }
}
