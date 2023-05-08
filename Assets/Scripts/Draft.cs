using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draft : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*
    private bool IsBetweenPipes()
    {
        // Lấy tất cả các ống trong game
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");

        // Nếu không có ống nào thì trả về false
        if (pipes.Length == 0)
        {
            return false;
        }

        // Lấy tọa độ của chim
        Vector3 birdPos = transform.position;

        // Duyệt qua từng cặp ống để kiểm tra vị trí của chim
        for (int i = 0; i < pipes.Length - 1; i += 2)
        {
            // Lấy tọa độ của hai điểm đầu và cuối của ống
            Vector3 pipe1StartPos = pipes[i].transform.position + new Vector3(0, pipeOffset, 0);
            Vector3 pipe1EndPos = pipe1StartPos + new Vector3(0, pipeHeight, 0);
            Vector3 pipe2StartPos = pipes[i + 1].transform.position - new Vector3(0, pipeOffset, 0);
            Vector3 pipe2EndPos = pipe2StartPos - new Vector3(0, pipeHeight, 0);

            // Tính khoảng cách giữa chim và đầu ống thứ nhất
            float distance1 = Vector3.Distance(birdPos, pipe1StartPos);

            // Tính khoảng cách giữa chim và cuối ống thứ nhất
            float distance2 = Vector3.Distance(birdPos, pipe1EndPos);

            // Nếu chim nằm giữa hai ống thì trả về true
            if (distance1 < pipeRadius && distance2 < pipeRadius)
            {
                return true;
            }

            // Tính khoảng cách giữa chim và đầu ống thứ hai
            float distance3 = Vector3.Distance(birdPos, pipe2StartPos);

            // Tính khoảng cách giữa chim và cuối ống thứ hai
            float distance4 = Vector3.Distance(birdPos, pipe2EndPos);

            // Nếu chim nằm giữa hai ống thì trả về true
            if (distance3 < pipeRadius && distance4 < pipeRadius)
            {
                return true;
            }
        }

        // Không có vùng an toàn nào giữa các ống
        return false;
private bool CheckGap(GameObject pipe1, GameObject pipe2, float gapSize)
{
    float halfGapSize = gapSize / 2f;

    // Lấy tọa độ của đầu và cuối ống thứ nhất
    Vector3 pipe1StartPos = pipe1.transform.position + new Vector3(0, halfGapSize, 0);
    Vector3 pipe1EndPos = pipe1StartPos + new Vector3(0, -gapSize, 0);

    }*/
    }

    //------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        //private float topLimit = 5f;
        //private float bottomLimit = -5f;
        //transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, bottomLimit, topLimit), transform.position.z);


        /*    void CheckSafeZone()
            {
                GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");

                foreach (GameObject pipe1 in pipes)
                {
                    foreach (GameObject pipe2 in pipes)
                    {
                        if (pipe1 != pipe2)
                        {
                            float distancePipes = Vector3.Distance(pipe1.transform.position, pipe2.transform.position);

                            float radiusSum = pipe1.GetComponent<PipeMove>().radius + pipe2.GetComponent<PipeMove>().radius;

                            float safeDistance = 2 * radiusSum + distanceThreshold;

                            if (distancePipes < safeDistance)
                            {
                                Debug.Log("Complete");
                            }
                        }
                    }
                }

            }*/
    }
    //--------------------------------------------------------------------------
    /*    private bool IsBetweenPipes()
    {
        // Lấy tất cả các ống trong game
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");

        // Nếu không có ống nào thì trả về false
        if (pipes.Length == 0)
        {
            return false;
        }

        // Lấy tọa độ của chim
        Vector3 birdPos = transform.position;

        // Duyệt qua từng cặp ống để kiểm tra vị trí của chim
        for (int i = 0; i < pipes.Length - 1; i += 2)
        {
            // Lấy tọa độ của hai điểm đầu và cuối của ống
            Vector3 pipe1StartPos = pipes[i].transform.position + new Vector3(0, pipeOffset, 0);
            Vector3 pipe1EndPos = pipe1StartPos + new Vector3(0, pipeHeight, 0);
            Vector3 pipe2StartPos = pipes[i + 1].transform.position - new Vector3(0, pipeOffset, 0);
            Vector3 pipe2EndPos = pipe2StartPos - new Vector3(0, pipeHeight, 0);

            // Tính khoảng cách giữa chim và đầu ống thứ nhất
            float distance1 = Vector3.Distance(birdPos, pipe1StartPos);

            // Tính khoảng cách giữa chim và cuối ống thứ nhất
            float distance2 = Vector3.Distance(birdPos, pipe1EndPos);

            // Nếu chim nằm giữa hai ống thì trả về true
            if (distance1 < pipeRadius && distance2 < pipeRadius)
            {
                Debug.Log("Complete1");
                return true;
            }

            // Tính khoảng cách giữa chim và đầu ống thứ hai
            float distance3 = Vector3.Distance(birdPos, pipe2StartPos);

            // Tính khoảng cách giữa chim và cuối ống thứ hai
            float distance4 = Vector3.Distance(birdPos, pipe2EndPos);

            // Nếu chim nằm giữa hai ống thì trả về true
            if (distance3 < pipeRadius && distance4 < pipeRadius)
            {
                Debug.Log("Complete2");
                return true;
            }
        }

        // Không có vùng an toàn nào giữa các ống
        return false;
    }*/

    //--------------------------------------------------------------------------
    /*    void CheckSpace()
        {
            // check if bird has passed between pipes
            if (birdX > pipe1X + xThreshold && birdX < pipe2X - xThreshold)
            {
                // check if bird is within the y-axis threshold
                if (birdY > pipe1Y + yThreshold && birdY < pipe2Y - yThreshold)
                {
                    // bird has passed through pipes
                    Debug.Log("Passed through pipes!");
                }
            }
        }*/
}
