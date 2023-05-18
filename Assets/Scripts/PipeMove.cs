using UnityEngine;

public class PipeMove : MonoBehaviour
{

    [SerializeField] private float speedPipe;
    [SerializeField] private YellowBird yellowBird;
    [SerializeField] private RedBird redBird;
    [SerializeField] private BlueBird blueBird;

    void Start()
    {
        yellowBird.isStart = false;
        redBird.isStart = false;
        blueBird.isStart = false;
    }
    void Update()
    {
        if(yellowBird.isStart || redBird.isStart || blueBird.isStart)
        {
            transform.position += Vector3.left * speedPipe * Time.deltaTime;

            if (transform.localPosition.x <= -4.0f)
            {
                Vector2 vector2 = transform.localPosition;
                vector2.x = 8.0f;
                vector2.y = Random.Range(-2.5f, 3.0f);
                transform.localPosition = vector2;
            }
        }
    }
}
