using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class RedBird : YellowBird
{

    private float cooldownDuration = 5f;
    private float cooldownTimer = 0f;
    private bool isCooldown = false;
    //private int option;
    [SerializeField] private Image cooldownCircle;
    [SerializeField] private AudioClip slowSound;

    protected override void Update()
    {
        base.Update();

        // Gọi hàm Update của BlueBird ở đây
        CustomUpdate();
    }

    private void CustomUpdate()
    {
        // Thêm code xử lý riêng cho BlueBird ở đây
        SlowMotion();
    }


    //Skill Slow
    public void SlowMotion()
    {

        if (isCooldown)
        {
            //giảm giá trị cT dựa trên thời gian trôi qua cùa 2 fr (đếm ngược)
            cooldownTimer -= Time.deltaTime;

            if (cooldownTimer <= 0f)
            {
                //kỹ năng off
                isCooldown = false;
                //vòng tròn hồi kỹ năng trống
                cooldownCircle.fillAmount = 0f;
            }
            else
            {
                //fillAmount là tỷ lệ thời gian còn lại trong cooldown so với tổng thời gian cooldown
                float fillAmount = cooldownTimer / cooldownDuration;
                //fillAmount cập nhật UI hồi kỹ năng với thời gian đã set
                cooldownCircle.fillAmount = fillAmount;
            }
        }

        if (Input.GetKeyDown(KeyCode.F) && PlayerPrefs.GetInt("Option") == 1 && !isCooldown)
        {
            Debug.Log("slow");
            StartCoroutine(ActivateSlowMotion());
            SoundManager.instance.PlaySound(slowSound);
        }
    }

    private IEnumerator ActivateSlowMotion()
    {
        isCooldown = true;
        cooldownTimer = cooldownDuration;

        Time.timeScale = 0.2f; // Điều chỉnh timeScale để làm chậm

        // Chờ 5 giây để kỹ năng làm chậm kết thúc
        yield return new WaitForSeconds(5f);

        Time.timeScale = 1f; // Khôi phục lại timeScale bình thường

        isCooldown = false;
        cooldownCircle.fillAmount = 1f;
    }

}
