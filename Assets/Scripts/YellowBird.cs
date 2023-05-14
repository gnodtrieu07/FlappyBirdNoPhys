using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

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

    [SerializeField] RuntimeAnimatorController[] birds;
    [SerializeField] Animator animatorControllers;

    Transform temp;
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
            return;
        }
        
        if(temp.localPosition.x <= -1.0f)
        {
            index += 1;
            temp = pipesPos[index % 4];
            scorePro.text = "" + index.ToString();
        }
        BirdMove();
        BirdCheckCollision();
        
    }
    
    void BirdMove()
    {
        // Xử lý khi nhấn phím để chim nhảy lên
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            verticalVelocity = jumpForce;
            isStart = true;
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
        if(temp.position.x <= 0.6f && temp.position.x >= -0.6f)
        {
            if (transform.position.y >= temp.position.y + 1.3f || transform.position.y <= temp.position.y - 1.3f)
            {
                gameManager.GameOver();
            }
        }
        if(transform.position.y < -3.5)
        {
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

}


