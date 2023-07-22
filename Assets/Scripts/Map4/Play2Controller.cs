using DefaultNamespace;
using Entity;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;

public class Play2Controller : intruct
{
    // Start is called before the first frame update
    private Tank _tank;

    public Sprite tankUp;
    public Sprite tankDown;
    public Sprite tankLeft;
    public Sprite tankRight;
    private TankMover _tankMover;
    /*private CameraController _cameraController;*/
    private SpriteRenderer _renderer;

    public GameObject Summary;
    public GameObject track;
    Animator animator;
    public GameObject health;

    private void Start()
    {
        track = GameObject.FindGameObjectWithTag("Track");

        animator = GetComponent<Animator>();
        _tank = new Tank
        {
            Name = "Default",
            Direction = Direction.Down,
            Position = new Vector3(-7.71f, 4.36f, 0),
            Guid = GUID.Generate()
        };
        gameObject.transform.position = _tank.Position;
        _tankMover = gameObject.GetComponent<TankMover>();
        _renderer = gameObject.GetComponent<SpriteRenderer>();
        Move(Direction.Down);
    }

    public static class Score
    {
        public static int score = 0;
        public static int countDestroy = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (setUpMap.undying.isPlaying || GameStatus.isTankCreate)
        {
            if (Input.GetKey(KeyCode.A))
            {
                track.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                Move(Direction.Left);
                animator.SetFloat("moveLeft", 1);
                animator.SetFloat("moveRight", 0);
                animator.SetFloat("moveUp", 0);
                animator.SetFloat("moveDown", 0);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                track.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

                Move(Direction.Down);
                animator.SetFloat("moveLeft", 0);
                animator.SetFloat("moveRight", 0);
                animator.SetFloat("moveUp", 0);
                animator.SetFloat("moveDown", 1);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                track.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                Move(Direction.Right);
                animator.SetFloat("moveLeft", 0);
                animator.SetFloat("moveRight", 1);
                animator.SetFloat("moveUp", 0);
                animator.SetFloat("moveDown", 0);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                track.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

                Move(Direction.Up);
                animator.SetFloat("moveLeft", 0);
                animator.SetFloat("moveRight", 0);
                animator.SetFloat("moveUp", 1);
                animator.SetFloat("moveDown", 0);
            }

            if (!GameStatus.isTankCreate)
            {
                if (Input.GetKey(KeyCode.J))
                {
                    Fire();
                }
            }
        }
    }

    private void Move(Direction direction)
    {
        _tank.Position = _tankMover.Move(direction);
        _tank.Direction = direction;
        _renderer.sprite = direction switch
        {
            Direction.Down => tankDown,
            Direction.Up => tankUp,
            Direction.Left => tankLeft,
            Direction.Right => tankRight,
            _ => _renderer.sprite
        };
    }

    private void Fire()
    {
        var b = new Bullet
        {
            Direction = _tank.Direction,
            Tank = _tank,
            InitialPosition = _tank.Position
        };
        GetComponent<TankFire>().Fire(b);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }*/
}
