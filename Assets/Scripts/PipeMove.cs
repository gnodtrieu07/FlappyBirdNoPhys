using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{

    [SerializeField] float speedPipe;
    public float pipeOffset;
    public float pipeHeight;
    public float radius;
    public float pipeWidth;
    public float safeZoneWidth = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        SetWidth(pipeWidth);
        //pipeWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    public void SetWidth(float width)
    {
        pipeWidth = width;

        //Đặt tỷ lệ của đường ống để phù hợp với chiều rộng
        Vector3 scale = transform.localScale;
        scale.x = pipeWidth;
        transform.localScale = scale;

        // Update is called once per frame
        void Update()
        {
            // Di chuyển ống sang trái với tốc độ 
            transform.position += Vector3.left * speedPipe * Time.deltaTime;
        }
    }
}
