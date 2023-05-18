using UnityEngine;
using TMPro;

public class YellowBird : MonoBehaviour
{
    //jumpForce để tạo hiệu ứng nhảy lên
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float gravity = 9.8f;
    //verticalVelocity để lưu trữ vận tốc theo chiều dọc
    [SerializeField] private float verticalVelocity = 0f;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI scorePro;

    [SerializeField] Transform[] pipesPos;
    Transform temp;

    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private AudioClip scoreSound;

    public int index { get; set; }

    private bool isDead = false;
    public bool isStart { get; set; }

    public bool isSkillActive { get; set; }

    // Cache
    private int option;

    public void Awake()
    {
        index = 0;
        gameManager.ConvertBird();
    }

    public void Start()
    {
        temp = pipesPos[index];
        transform.position = Vector2.zero;
        isStart = false;

        option = PlayerPrefs.GetInt("Option");
        Debug.Log(option);
    }

    protected virtual void Update()
    {
        // Nếu đã chết thì ko cập nhật nữa
        if (isDead)
        {
            scorePro.text = " ";
            scorePro.gameObject.SetActive(false);
            return;
        }
        if (temp.localPosition.x <= -1.0f)
        {
            index += 1;
            temp = pipesPos[index % 4];
            SoundManager.instance.PlaySound(scoreSound);
            scorePro.text = index.ToString();
        }

        BirdMove();
        BirdCheckCollision();
    }
    public void BirdMove()
    {
        // Xử lý khi nhấn phím để chim nhảy lên
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            verticalVelocity = jumpForce;
            isStart = true;
            SoundManager.instance.PlaySound(jumpSound);
        }
        // Cập nhật vị trí của chim dựa trên Vertvelocity
        if (isStart)
        {
            Vector2 position = transform.position;
            position.y += verticalVelocity * Time.deltaTime;
            transform.position = position;
        }

        // Cập nhật gia tốc và vận tốc
        // Tính toán gia tốc bằng cách giảm verticalVelocity theo thời gian.
        verticalVelocity -= gravity * Time.deltaTime;
    }

    public void BirdCheckCollision()
    {
        if(!isSkillActive)
        {
            // Kiểm tra va chạm khi kỹ năng không hoạt động
            if (temp.position.x <= 0.6f && temp.position.x >= -0.6f)
            {
                if (transform.position.y >= temp.position.y + 1.3f || transform.position.y <= temp.position.y - 1.3f)
                {
                    SoundManager.instance.PlaySound(gameOverSound);
                    gameManager.GameOver();
                }
            }
            if (transform.position.y < -3.5f)
            {
                SoundManager.instance.PlaySound(gameOverSound);
                gameManager.GameOver();
            }
        }
    }
}


