using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField]
    private float _speed;
    int angle;
    int maxAngle = 20;
    int minAngle = -60;
    public Score score;
    bool touchGround;
    public GameManager gameManager;
    public Animator anim;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        FishSwim();

    }
    private void FixedUpdate()
    {
        FishRotation();
    }


    public void FishSwim()
    {
        transform.position = new Vector2(transform.position.x * Time.deltaTime, transform.position.y);
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
        {
            _rb.velocity = Vector2.zero;
            _rb.velocity = new Vector2(_rb.velocity.x, _speed);
        }
    }

    public void FishRotation()
    {
        if (_rb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }
        }
        else if (_rb.velocity.y < -1.2)
        {
            if (angle > minAngle)
            {
                angle = angle - 2;
            }
        }

        if (touchGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            score.Scored();
        }
        else if (collision.CompareTag("Column"))
        {
            gameManager.GameOver();
            GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (GameManager.gameOver == false)
            {
                gameManager.GameOver();
                anim.enabled = false;

            }
            else
            {

            }
        }
    }


    void GameOver()
    {
        touchGround = true;
        transform.rotation = Quaternion.Euler(0, 0, -90f);
        anim.enabled = false;
    }


}
