using System;
using System.Collections;
using System.Collections.Generic;
using Entity;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class BulletController : MonoBehaviour
{
    public Bullet Bullet { get; set; }

    public int MaxRange { get; set; }

    private bool isDestroyed = false;
    int map;

    [SerializeField] private AudioSource blockCollisionSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        ChooseMap chooseMap = FindObjectOfType<ChooseMap>();
        map = chooseMap.map;
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
    private void DestroyBullet()
    {
        isDestroyed = true;
        gameObject.SetActive(false);
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
        switch (direction)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }*/

        /*if (collision.gameObject.tag == "king")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);           
        }*/

        if (collision.gameObject.tag == "Play2")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            SceneManager.LoadScene(7);
        }
    }

    public void CheckCollision()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        foreach (Collider2D collider in colliders)
        {
            /*if (collider.CompareTag("WallSteel") && map == 4)
            {
                Vector2 reflectionVector = Vector2.Reflect(transform.right, collider.transform.right);

                GetComponent<Rigidbody2D>().velocity = reflectionVector.normalized * 2;

                transform.Rotate(Vector3.forward, 45);

                break;
            }*/

            /*else if (collider.CompareTag("WallSteel")  && map != 4)
            {
                Destroy(gameObject);
            }*/


            if (collider.CompareTag("WallSteel"))
            {
                // Lấy reference tới scene hiện tại (nếu bạn chưa có reference này thì hãy thêm vào)
                Scene currentScene = SceneManager.GetActiveScene();
                int sceneIndex = currentScene.buildIndex;

                // Kiểm tra xem có đang ở scene 4 hay không
                if (sceneIndex == 6)
                {
                    Vector2 reflectionVector = Vector2.Reflect(transform.right, collider.transform.right);

                    GetComponent<Rigidbody2D>().velocity = reflectionVector.normalized * 2;

                    transform.Rotate(Vector3.forward, 45);

                    // Bỏ qua việc destroy objects ở Scene 4
                    return;
                }
                Destroy(gameObject);
            }

            // Tiếp tục phần còn lại của code để destroy objects ở các scene khác
            // (Dựa vào đoạn code bạn đã viết, mình giả định phần này có trong code của bạn)
            

            else if ( collider.CompareTag("wall"))
            {
                // Va chạm với "WallSteel", viên đạn biến mất
                blockCollisionSoundEffect.Play();
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
                        blockCollisionSoundEffect.Play();

                        // Phá hủy viên đạn
                        Destroy(gameObject);
                        return; // Thoát khỏi hàm sau khi xử lý va chạm với WallBrick
                    }
                }
            }
        }
    }
}