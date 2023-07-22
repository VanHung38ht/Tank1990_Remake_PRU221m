using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class bulletController : MonoBehaviour
{
    public enemyBullet Bullet { get; set; }

    public int MaxRange { get; set; }

    private bool isDestroyed = false;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        DestroyAfterRange();
        if (!isDestroyed)
        {
            DestroyAfterRange();
        }
    }

    private void DestroyAfterRange()
    {
        var currentPos = gameObject.transform.position;
        var initPos = Bullet.InitialPosition;

        var direction = Bullet.Direction;

        var distance = Vector3.Distance(initPos, currentPos);

        if (distance >= MaxRange)
        {
            DestroyBullet();
            return;
        }

        Vector3 movement = Vector3.zero;

        switch (Bullet.Direction)
        {
            case Direction.Down:
                if (initPos.y - MaxRange >= currentPos.y)
                {
                    Destroy(gameObject);
                }

                break;
            case Direction.Up:
                if (initPos.y + MaxRange <= currentPos.y)
                {
                    Destroy(gameObject);
                }

                break;
            case Direction.Left:
                if (initPos.x - MaxRange >= currentPos.x)
                {
                    Destroy(gameObject);
                }

                break;
            case Direction.Right:
                if (initPos.x + MaxRange <= currentPos.x)
                {
                    Destroy(gameObject);
                }

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        transform.position += movement * Time.deltaTime;
        CheckCollision();
    }

    public void CheckCollision()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("WallSteel")|| collider.CompareTag("wall"))
            {
                // Va chạm với "WallSteel", viên đạn biến mất
                Destroy(gameObject);
            }
            else if (collider.CompareTag("Tree"))
            {
                // Va chạm với "WaterTree", viên đạn đi xuyên qua
                return;
            }
            else if (collider.CompareTag("Brick"))
            {
                Tilemap tilemap = collider.GetComponent<Tilemap>();
                if (tilemap != null && tilemap.tag == "Brick")
                {
                    Vector3 hitPosition = transform.position;
                    Vector3Int cellPosition = tilemap.WorldToCell(hitPosition);

                    // Kiểm tra xem có WallBrick tại vị trí cell hay không
                    if (tilemap.GetTile(cellPosition) != null)
                    {
                        // Phá hủy WallBrick
                        tilemap.SetTile(cellPosition, null);

                        // Phá hủy viên đạn
                        Destroy(gameObject);
                        return; // Thoát khỏi hàm sau khi xử lý va chạm với WallBrick
                    }
                }
            }
        }
    }

    private void DestroyBullet()
    {
        isDestroyed = true;
        gameObject.SetActive(false);
    }
}
