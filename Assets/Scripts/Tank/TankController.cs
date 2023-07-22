using DefaultNamespace;
using Entity;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;

public class TankController : intruct
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
    public GameObject PauseGame;
    public GameObject option1pause, close;

    [SerializeField] private AudioSource ShotSoundEffect;

    private void Start()
    {
        track = GameObject.FindGameObjectWithTag("Track");

        animator = GetComponent<Animator>();


        _tank = new Tank
        {
            Name = "Default",
            Direction = Direction.Down,
            Hp = 10,
            Point = 0,
            Position = new Vector3(3f, -3f, 0),
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
        if ((setUpMap.undying.isPlaying || GameStatus.isTankCreate) && GameStatus.isTankPlay == true)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                track.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                Move(Direction.Left);
                animator.SetFloat("moveLeft", 1);
                animator.SetFloat("moveRight", 0);
                animator.SetFloat("moveUp", 0);
                animator.SetFloat("moveDown", 0);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                track.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

                Move(Direction.Down);
                animator.SetFloat("moveLeft", 0);
                animator.SetFloat("moveRight", 0);
                animator.SetFloat("moveUp", 0);
                animator.SetFloat("moveDown", 1);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                track.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                Move(Direction.Right);
                animator.SetFloat("moveLeft", 0);
                animator.SetFloat("moveRight", 1);
                animator.SetFloat("moveUp", 0);
                animator.SetFloat("moveDown", 0);
            }
            else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                track.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

                Move(Direction.Up);
                animator.SetFloat("moveLeft", 0);
                animator.SetFloat("moveRight", 0);
                animator.SetFloat("moveUp", 1);
                animator.SetFloat("moveDown", 0);
            }
            else if(Input.GetKey(KeyCode.P))
            {
                Time.timeScale = 0;
                PauseGame.SetActive(true);
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(option1pause);
            }

            if (!GameStatus.isTankCreate)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    ShotSoundEffect.Play();
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
        GetComponent<TankFirer>().Fire(b);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bulletEnemy")
        {
            _tank.Hp -= 2;
            
            if (_tank.Hp == 0)
            {
                Destroy(gameObject);
                //intruct.GameStatus.isGameRunning = false;
                health.SetActive(false);
                Summary.SetActive(true);
                GameStatus.isTankPlay = false;
                Time.timeScale = 0;
                EventSystem.current.SetSelectedGameObject(null);
                // Choose a new selected object
                EventSystem.current.SetSelectedGameObject(close);
            }
        }
    }
}