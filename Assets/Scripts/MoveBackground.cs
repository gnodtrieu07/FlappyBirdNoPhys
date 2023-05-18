using UnityEngine;
using UnityEngine.UI;

public class MoveBackground : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f; // Tốc độ di chuyển của background
    private RawImage rawImage; 
    private Rect rect; 

    void Start()
    {
        // Lấy component Raw Image và gán hình ảnh vào Texture
        rawImage = GetComponent<RawImage>();
        rawImage.texture.wrapMode = TextureWrapMode.Repeat;

        // Khởi tạo giá trị UV Rect mặc định
        rect = new Rect(0f, 0f, 1.0f, 1.0f);
    }

    void Update()
    {
        // Thay đổi giá trị UV Rect để di chuyển hình ảnh
        rect.x += Time.deltaTime * speed;
        rawImage.uvRect = rect;
    }
}