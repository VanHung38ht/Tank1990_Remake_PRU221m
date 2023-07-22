using DefaultNamespace;
using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class enemyController : MonoBehaviour
{
    private Enemy enemy;

    public Sprite enemyUp;
    public Sprite enemyDown;
    public Sprite enemyLeft;
    public Sprite enemyRight;

    private enemyMove enemyMove;
    private SpriteRenderer enemyRenderer;
    Animator animator;

    int randomDirection, random = 1;
    bool changeDirection = true;
    float timechangeDirection = 3;

    float timeShotter = 3f;

    [SerializeField] private AudioSource ShotEnemySoundEffect;


    private void Start()
    {
        animator = GetComponent<Animator>();

        enemy = new Enemy
        {
            Name = "Default",
            Direction = Direction.Down,
            Hp = 10,
            Point = 100,
            Position = gameObject.transform.position,
            Guid = GUID.Generate()
        };

        enemyMove = gameObject.GetComponent<enemyMove>();
        enemyRenderer = gameObject.GetComponent<SpriteRenderer>();
        
        Move(Direction.Down);
    }

    private void Update()
    {
        timeShotter += Time.deltaTime;
        timechangeDirection += Time.deltaTime;

        if (random == 1)
        {
            randomDirection = UnityEngine.Random.Range(0, 4);
            random = 0;
        }

        if (changeDirection & timechangeDirection > 0.5f)
        {
            randomDirection += 1;

            if (randomDirection > 3)
            {
                randomDirection = 0;
            }

            changeDirection = false;
        }

        switch (randomDirection)
        {
            case 0:
                Move(Direction.Up);
                animator.SetFloat("moveLeft", 0);
                animator.SetFloat("moveRight", 0);
                animator.SetFloat("moveUp", 1);
                animator.SetFloat("moveDown", 0);
                break;

            case 1:
                Move(Direction.Down);
                animator.SetFloat("moveLeft", 0);
                animator.SetFloat("moveRight", 0);
                animator.SetFloat("moveUp", 0);
                animator.SetFloat("moveDown", 1);
                break;

            case 2:
                Move(Direction.Left);
                animator.SetFloat("moveLeft", 1);
                animator.SetFloat("moveRight", 0);
                animator.SetFloat("moveUp", 0);
                animator.SetFloat("moveDown", 0);
                break;

            case 3:
                Move(Direction.Right);
                animator.SetFloat("moveLeft", 0);
                animator.SetFloat("moveRight", 1);
                animator.SetFloat("moveUp", 0);
                animator.SetFloat("moveDown", 0);
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }

        if (timeShotter > 3)
        {
            timeShotter = 0;
            ShotEnemySoundEffect.Play();
            Fire();
        }
    }

    private void Move(Direction direction)
    {
        enemy.Position = enemyMove.Move(direction);
        enemy.Direction = direction;
        enemyRenderer.sprite = direction switch
        {
            Direction.Down => enemyDown,
            Direction.Left => enemyLeft,
            Direction.Right => enemyRight,
            Direction.Up => enemyUp,
            _ => enemyRenderer.sprite
        };
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra va chạm với tường
        if (collision.gameObject.CompareTag("block") || collision.gameObject.CompareTag("rock") ||
            collision.gameObject.CompareTag("wall") || collision.gameObject.CompareTag("Enemy") ||
            collision.gameObject.CompareTag("water") || collision.gameObject.CompareTag("WallSteel") ||
            collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Water"))
        {
            changeDirection = true;
            timechangeDirection = 0f;
        }
    }

    private void Fire()
    {
        var b = new enemyBullet
        {
            
            Direction = enemy.Direction,
            enemy = enemy,
            InitialPosition = enemy.Position
        };
        GetComponent<enemyFirer>().Fire(b);
    }
}
