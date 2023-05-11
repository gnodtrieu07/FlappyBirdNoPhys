using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeMove : MonoBehaviour
{

    [SerializeField] float speedPipe;
    private bool isStart = false;
    public float pipeWidth;

    // Start is called before the first frame update
    void Start()
    {
/*        transform.position = new Vector3(6,0,0);
        isStart = false;*/
    }
    void Update()
    {
/*        if (isStart || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // Di chuyển ống sang trái với tốc độ 
            transform.position += Vector3.left * speedPipe * Time.deltaTime;
            //Debug.Log(Time.deltaTime);
        }*/
        transform.position += Vector3.left * speedPipe * Time.deltaTime;

        if (transform.localPosition.x <= -4.0f)
        {
            Vector2 vector2 = transform.localPosition;
            vector2.x = 8.0f;
            vector2.y = Random.Range(-2.5f,3.0f);
            transform.localPosition = vector2;
            //isStart = true;
        }
    }
}
