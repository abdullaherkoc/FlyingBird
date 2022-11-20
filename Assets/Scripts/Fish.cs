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
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        FishSwim();
        FishRotation();


    }


    public void FishSwim()
    {
        transform.position = new Vector2(transform.position.x * Time.deltaTime, transform.position.y);
        if (Input.GetMouseButtonDown(0))
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
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }
}
