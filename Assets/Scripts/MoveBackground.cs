using UnityEngine;
using UnityEngine.UI;

public class MoveBackground : MonoBehaviour
{
    public float speed = 0.5f; // Tốc độ di chuyển của background
    private RawImage rawImage; // Biến lưu trữ component Raw Image của GameObject
    private Rect rect; // Biến lưu trữ UV Rect của hình ảnh

    void Start()
    {
        // Lấy component Raw Image và gán hình ảnh vào Texture
        rawImage = GetComponent<RawImage>();
        rawImage.texture.wrapMode = TextureWrapMode.Repeat;

        // Khởi tạo giá trị UV Rect mặc định
        rect = new Rect(0, 0, 1, 1);
    }

    void Update()
    {
        // Thay đổi giá trị UV Rect để di chuyển hình ảnh
        rect.x += Time.deltaTime * speed;
        rawImage.uvRect = rect;
    }
}