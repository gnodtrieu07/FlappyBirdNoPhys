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

/*
        //Đặt vị trí của các đối tượng top and bot để khớp với chiều rộng mới
        Transform upperPipe = transform.Find("UpperPipe");
        Transform lowerPipe = transform.Find("LowerPipe");

        //Di chuyển các đường ống đến các cạnh của đối tượng gốc ban đầu dựa trên chiều rộng mới
        upperPipe.localPosition = new Vector3(0, -width / 2, 0);
        lowerPipe.localPosition = new Vector3(0, width / 2, 0);*/
    }

    // Update is called once per frame
    void Update()
    {
        // Di chuyển ống sang trái với tốc độ 
        transform.position += Vector3.left * speedPipe * Time.deltaTime;
    }
/*    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, PipeRadius);
    }*/
}
