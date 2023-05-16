using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class YellowBird : MonoBehaviour
{
    //jumpForce để tạo hiệu ứng nhảy lên
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float gravity = 9.8f;
    //verticalVelocity để lưu trữ vận tốc theo chiều dọc
    [SerializeField] float verticalVelocity = 0f;

    [SerializeField] GameManager gameManager;
    [SerializeField] TextMeshProUGUI scorePro;


    [SerializeField] Transform[] pipesPos;
    Transform temp;

    [SerializeField] RuntimeAnimatorController[] birds;
    [SerializeField] Animator animatorControllers;

    private bool isCooldown = false;
    private bool isSkillActive = false;
    private float cooldownDuration = 5f;
    private float cooldownTimer = 0f;

    [SerializeField] Image cooldownCircle;
    [SerializeField] Image cooldownCircle2;

    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip gameOverSound;
    [SerializeField] AudioClip scoreSound;
    [SerializeField] AudioClip slowSound;

    public int index { get; set; }

    private bool isDead = false;
    public bool isStart { get; set; }

    private void Awake()
    {
        index = 0;
        ConvertBird();
    }

    private void Start()
    {
        temp = pipesPos[index];
        transform.position = Vector2.zero;
        isStart = false;

        Debug.Log(PlayerPrefs.GetInt("Option"));
    } 

    void Update()
    {
        // Nếu đã chết thì ko cập nhật nữa
        if (isDead)
        {
            scorePro.text = " ";
            scorePro.gameObject.SetActive(false);
            cooldownCircle.gameObject.SetActive(false);
            return;
        }

        if (temp.localPosition.x <= -1.0f)
        {
            index += 1;
            temp = pipesPos[index % 4];
            SoundManager.instance.PlaySound(scoreSound);
            scorePro.text = "" + index.ToString();
        }

        BirdMove();
        SlowMotion();
        ThroughSkill();
        BirdCheckCollision();
    }

    void BirdMove()
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

    void BirdCheckCollision()
    {
        // Kiểm tra va chạm khi kỹ năng không hoạt động
        if (!isSkillActive)
        {
            if (temp.position.x <= 0.6f && temp.position.x >= -0.6f)
            {
                if (transform.position.y >= temp.position.y + 1.3f || transform.position.y <= temp.position.y - 1.3f)
                {
                    SoundManager.instance.PlaySound(gameOverSound);
                    gameManager.GameOver();
                }
            }
            if (transform.position.y < -3.5)
            {
                SoundManager.instance.PlaySound(gameOverSound);
                gameManager.GameOver();
            }
        }
    }

    private void ConvertBird()
    {
        int index = PlayerPrefs.GetInt("Option");
        switch (index)
        {
            case 0:
                animatorControllers.runtimeAnimatorController = birds[0];
                cooldownCircle2.gameObject.SetActive(false);
                cooldownCircle.gameObject.SetActive(false);
                break;
            case 1:
                animatorControllers.runtimeAnimatorController = birds[1];
                cooldownCircle2.gameObject.SetActive(false);
                cooldownCircle.gameObject.SetActive(true);
                break;
            case 2:
                animatorControllers.runtimeAnimatorController = birds[2];
                cooldownCircle2.gameObject.SetActive(true);
                cooldownCircle.gameObject.SetActive(false);
                break;
        }
    }

    //Skill Slow
    private void SlowMotion()
    {

        if (isCooldown)
        {
            //giảm giá trị cT dựa trên thời gian trôi qua cùa 2 fr (đếm ngược)
            cooldownTimer -= Time.deltaTime;

            if (cooldownTimer <= 0f)
            {
                //kỹ năng off
                isCooldown = false;
                //vòng tròn hồi kỹ năng trống
                cooldownCircle.fillAmount = 0f;
            }
            else
            {
                //fillAmount là tỷ lệ thời gian còn lại trong cooldown so với tổng thời gian cooldown
                float fillAmount = cooldownTimer / cooldownDuration;
                //fillAmount cập nhật UI hồi kỹ năng với thời gian đã set
                cooldownCircle.fillAmount = fillAmount;
            }
        }

        if (Input.GetKeyDown(KeyCode.F) && PlayerPrefs.GetInt("Option") == 1 && !isCooldown)
        {
            StartCoroutine(ActivateSlowMotion());
            SoundManager.instance.PlaySound(slowSound);
        }
    }

    //Skill Through
    public void ThroughSkill()
    {
        if (Input.GetKeyDown(KeyCode.D) && PlayerPrefs.GetInt("Option") == 2) 
        {
            if(!isSkillActive)
            {
                StartCoroutine(ActivateSkill());
                StartCoroutine(ShowCooldownThrough());
                SoundManager.instance.PlaySound(slowSound);
            }
        }
    }


    private IEnumerator ActivateSlowMotion()
    {
        isCooldown = true;
        cooldownTimer = cooldownDuration;

        Time.timeScale = 0.2f; // Điều chỉnh timeScale để làm chậm

        // Chờ 5 giây để kỹ năng làm chậm kết thúc
        yield return new WaitForSeconds(5f);

        Time.timeScale = 1f; // Khôi phục lại timeScale bình thường

        isCooldown = false;
        cooldownCircle.fillAmount = 1f;
    }

    private IEnumerator ActivateSkill()
    {
        isSkillActive = true;

        // Lưu vị trí ban đầu của chim
        Vector3 initialPosition = transform.position;

        // Di chuyển chim qua cột trong một khoảng thời gian nhất định
        float movementDuration = 1.0f; // Thời gian di chuyển (đơn vị: giây)
        float elapsedTime = 0;

        while (elapsedTime < movementDuration)
        {
            // Tính toán vị trí mới của chim
            float t = elapsedTime / movementDuration;
            Vector3 targetPosition = new Vector3(initialPosition.x + 1.0f, initialPosition.y, initialPosition.z);
            transform.position = Vector3.Lerp(initialPosition, targetPosition, t);

            // Cập nhật thời gian trôi qua
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Đặt lại vị trí ban đầu của chim
        transform.position = initialPosition;

        // Chờ một khoảng thời gian hồi kỹ năng
        float skillCooldown = 5.0f; // Thời gian hồi kỹ năng (đơn vị: giây)
        yield return new WaitForSeconds(skillCooldown);
        isSkillActive = false;
        cooldownCircle2.fillAmount = 1;
    }
    private IEnumerator ShowCooldownThrough()
    {
        float duration = 5.0f;
        cooldownCircle2.gameObject.SetActive(true);
        float timer = duration;

        while (timer > 0)
        {
            // Cập nhật UI hồi kỹ năng
            float fillAmount = timer / duration;
            cooldownCircle2.fillAmount = fillAmount;

            yield return null;
            timer -= Time.deltaTime;
        }
        cooldownCircle2.fillAmount = 0;
    }
}


