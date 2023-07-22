using UnityEngine;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    public GameObject[] menuOptions; // Mảng chứa các tùy chọn trong menu
    private int currentIndex = 0;
    [SerializeField] private AudioSource ChooseSound;

    private void Start()
    {
        ChangeSelection(0);
    }

    void Update()
    {
        // Kiểm tra sự kiện bàn phím
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            ChangeSelection(-1); // Di chuyển lên trên
            ChooseSound.Play();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            ChangeSelection(1); // Di chuyển xuống dưới
            ChooseSound.Play();

        }
    }

    void ChangeSelection(int direction)
    {
        // Vô hiệu hóa tất cả các tùy chọn
        foreach (GameObject option in menuOptions)
        {
            option.SetActive(false);
        }

        // Cập nhật chỉ mục hiện tại
        currentIndex += direction;
        if (currentIndex < 0)
        {
            currentIndex = menuOptions.Length - 1;
        }
        else if (currentIndex >= menuOptions.Length)
        {
            currentIndex = 0;
        }

        // Kích hoạt tùy chọn mới
        menuOptions[currentIndex].SetActive(true);
    }
}
