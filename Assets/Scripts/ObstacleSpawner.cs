using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public float maxTime;
    float timer;
    public float maxY;
    public float minY;
    float randomY;

    private void Start()
    {
        //InstantieObstacle();
    }

    private void Update()
    {
        if (GameManager.gameOver == false && GameManager.gameStarted == true)
        {
            timer += Time.deltaTime;
            if (timer >= maxTime)
            {
                randomY = Random.Range(minY, maxY);
                InstantieObstacle();
                timer = 0;
            }
        }

    }

    public void InstantieObstacle()
    {
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = new Vector2(transform.position.x, randomY);

    }

}
