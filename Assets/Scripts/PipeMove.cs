using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{

    [SerializeField] float speedPipe;
    public float pipeWidth;

    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        // Di chuyển ống sang trái với tốc độ 
        transform.position += Vector3.left * speedPipe * Time.deltaTime;
        //Debug.Log(Time.deltaTime);

        if(transform.localPosition.x <= -4.0f)
        {
            Vector2 vector2 = transform.localPosition;
            vector2.x = 8.0f;
            vector2.y = Random.Range(-2.5f,3.0f);
            transform.localPosition = vector2;
        }
    }
}
