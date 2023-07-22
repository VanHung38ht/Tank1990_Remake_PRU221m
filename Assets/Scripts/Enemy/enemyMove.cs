using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        speed = 1;
    }

    public Vector3 Move(Direction direction)
    {
        var currentPos  = gameObject.transform.position;

        switch (direction)
        {
            case Direction.Down:
                currentPos.y -= speed * Time.deltaTime;
                break;
            case Direction.Left:
                currentPos.x -= speed * Time.deltaTime;
                break;
            case Direction.Right:
                currentPos.x += speed * Time.deltaTime;
                break;
            case Direction.Up:
                currentPos.y += speed * Time.deltaTime;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }

        gameObject.transform.position = currentPos;
        return currentPos;
    }
}
