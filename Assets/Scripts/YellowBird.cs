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

    [SerializeField] GameActive gameActive;
    public TextMeshProUGUI scorePro;

    [SerializeField] Transform[] pipesPos;
    Transform temp;
    int index = 0;

    private int score = 0;
    public GameObject yellow;
    //PipeSpawner pipeSpawner;
    private bool isDead = false;
    

    private void Start()
    {
        temp = pipesPos[index];
    }

    void Update()
    {
        // Nếu đã chết thì ko cập nhật nữa
        if (isDead)
        {
            return;
        }

        if(temp.localPosition.x <= -1.0f)
        {
            index += 1;
            temp = pipesPos[index % 4];
            scorePro.text = "" + index.ToString();
        }
        Debug.Log(index);
        BirdMove();
        BirdCheckCollision();
    }

    void BirdMove()
    {
        // Xử lý khi nhấn phím để chim nhảy lên
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            verticalVelocity = jumpForce;
        }
        // Cập nhật vị trí của chim dựa trên Vertvelocity
        Vector2 position = transform.position;
        position.y += verticalVelocity * Time.deltaTime;
        transform.position = position;

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
                gameActive.GameOver();
            }
        }
        if(transform.position.y < -3.5)
        {
            gameActive.GameOver();
        }
    }



















    /*void CheckCollisionByDistance()
    {
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");

        foreach (GameObject pipe in pipes)
        {
            Vector3 birdPos = transform.position;
            Vector3 pipePos = pipe.transform.position;

            //lấy tọa độ của chim và ống sau đó tính khoảng cách giữa 2 cái bằng hàm Vector3.Distance
            float distance = Vector3.Distance(birdPos, pipePos);

            // tính tổng bán kính của chim và ống
            float radiusSum = birdRadius + pipeRadius;

            float totalDistance = radiusSum + distanceThreshold;

            //kiểm tra xem khoảng cách có bé hơn tổng bán kính cộng với distanceThreshold
            if (distance > totalDistance)
            {
                //Debug.Log("Error");
            }
            else if (distance < totalDistance)
            {
                isDead = true;
                Debug.Log("Collision detected!");
                gameActive.GameOver();
            }
        }

        if (yellow.transform.position.y < -3.5)
        {
            Debug.Log("Dead");
            gameActive.GameOver();
            Time.timeScale = 0;
        }
    }*/
}


