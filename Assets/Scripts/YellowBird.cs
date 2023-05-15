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
    private float cooldownDuration = 5f;
    private float cooldownTimer = 0f;
    [SerializeField] Image cooldownCircle;

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
            scorePro.text = "";
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

    private void ConvertBird()
    {
        int index = PlayerPrefs.GetInt("Option");
        switch (index)
        {
            case 0:
                animatorControllers.runtimeAnimatorController = birds[0];
                break;
            case 1:
                animatorControllers.runtimeAnimatorController = birds[1];
                break;
            case 2:
                animatorControllers.runtimeAnimatorController = birds[2];
                break;
        }
    }

    private void SlowMotion()
    {
        if (isCooldown)
        {
            cooldownTimer -= Time.deltaTime;

            if (cooldownTimer <= 0f)
            {
                isCooldown = false;
                cooldownCircle.fillAmount = 0f;
            }
            else
            {
                float fillAmount = cooldownTimer / cooldownDuration;
                cooldownCircle.fillAmount = fillAmount;
            }
        }

        if (Input.GetKeyDown(KeyCode.F) && PlayerPrefs.GetInt("Option") == 1 && !isCooldown)
        {
            StartCoroutine(ActivateSlowMotion());
            SoundManager.instance.PlaySound(slowSound);
        }
    }

    public void ThroughSkill()
    {

    }


    private IEnumerator ActivateSlowMotion()
    {
        isCooldown = true;
        cooldownTimer = cooldownDuration;

        Time.timeScale = 0.2f; // Điều chỉnh timeScale để làm chậm

        // Chờ vài giây để kỹ năng làm chậm kết thúc
        yield return new WaitForSeconds(3f);

        Time.timeScale = 1f; // Khôi phục lại timeScale bình thường

        isCooldown = false;
        cooldownCircle.fillAmount = 1f;
    }
}


