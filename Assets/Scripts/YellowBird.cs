using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class YellowBird : MonoBehaviour
{
    //jumpForce để tạo hiệu ứng nhảy lên
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float gravity = 9.8f;
    //verticalVelocity để lưu trữ vận tốc theo chiều dọc
    [SerializeField] float verticalVelocity = 0f;
    [SerializeField] GameActive gameActive;
    public GameObject yellow;
    //PipeSpawner pipeSpawner;
    private bool isDead = false;
    private float birdRadius = 0.25f;
    private float pipeRadius = 0.5f;

    public float pipeOffset = 2f;
    public float pipeHeight = 2f;

    //Ngưỡng khoảng cách cho phép giữa chim và ống trước khi xem như có va chạm.
    private float distanceThreshold = 0.1f;
/*
    float birdX = bird.position.x;
    float birdY = bird.position.y;
    float pipe1X = pipe1.position.x;
    float pipe1Y = pipe1.position.y;
    float pipe2X = pipe2.position.x;
    float pipe2Y = pipe2.position.y;*/



    void Update()
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

        // Nếu đã chết thì ko cập nhật nữa
        if (isDead)
        {
            return;
        }
        //CheckSafeZone();
        //IsBetweenPipes();
        CheckCollisionByDistance();
        DropGround();
       
    }


    void CheckCollisionByDistance()
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
                Debug.Log("Error");
            }
            else if(distance < totalDistance)
            {
                isDead = true;
                Debug.Log("Collision detected!");
                gameActive.GameOver();
            }
        }
    }
    void DropGround()
    {
        if(yellow.transform.position.y < 3.5)
        {
            Debug.Log("Dead");
            gameActive.GameOver();
            Time.timeScale = 0;
        }
    }
}


