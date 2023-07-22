using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Sprite spriteRight;
    public Sprite spriteLeft;
    public Sprite spriteUp;
    public Sprite spriteDown;
    public int speed;
    public int maxRange;
    public float delay;
    public float lastFire = 0f;

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void Fire(Bullet c)
    {
        // Debug.Log("FIre: "+Time.time);
        if (lastFire + delay > Time.time)
        {
            return;
        }

        var bullet2 = Instantiate(bulletPrefab, c.InitialPosition, Quaternion.identity);
        var sr = bullet2.GetComponent<SpriteRenderer>();
        var rigidBody2d = bullet2.GetComponent<Rigidbody2D>();
        var bulletController2 = bullet2.GetComponent<Bullet2Controller>();
        bulletController2.Bullet2 = c;
        bulletController2.MaxRange = maxRange;
        Vector2 force;
        switch (c.Direction)
        {
            case Direction.Down:
                sr.sprite = spriteDown;
                force = new Vector2(0, -1 * speed);
                break;
            case Direction.Up:
                sr.sprite = spriteUp;
                force = new Vector2(0, speed);

                break;
            case Direction.Right:
                sr.sprite = spriteRight;
                force = new Vector2(speed, 0);

                break;
            case Direction.Left:
                sr.sprite = spriteLeft;
                force = new Vector2(-1 * speed, 0);

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        rigidBody2d.AddForce(force, ForceMode2D.Impulse);
        lastFire = Time.time;

        bulletController2.CheckCollision();
    }
}
