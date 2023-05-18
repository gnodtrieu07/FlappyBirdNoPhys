using System.Collections;
using System;

using UnityEngine;
using UnityEngine.UI;

public class BlueBird : YellowBird
{
    [SerializeField] Image cooldownCircle2;
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
        ThroughSkill();
    }



    //Skill Through
    public void ThroughSkill()
    {
        if (Input.GetKeyDown(KeyCode.D) && PlayerPrefs.GetInt("Option") == 2)
        {
            if (!isSkillActive)
            {
                Debug.Log("brave");
                StartCoroutine(ActivateSkill());
                StartCoroutine(ShowCooldownThrough());
                SoundManager.instance.PlaySound(slowSound);
            }
        }
    }


    private IEnumerator ActivateSkill()
    {
        isSkillActive = true;

        // Lưu vị trí ban đầu của chim
        Vector3 initialPosition = transform.position;

        // Di chuyển chim qua cột trong một khoảng thời gian nhất định
        float movementDuration = 1.0f; // Thời gian di chuyển (đơn vị: giây)
        float elapsedTime = 0f;

        while (elapsedTime < movementDuration)
        {
            // Tính toán vị trí mới của chim
            float t = elapsedTime / movementDuration;
            //Vector3 targetPosition = new Vector3(initialPosition.x + 1.0f, initialPosition.y, initialPosition.z);
            Vector3 targetPosition = initialPosition + new Vector3(1.0f, 0.0f, 0.0f);
            transform.position = Vector3.Lerp(initialPosition, targetPosition, t);

            // Cập nhật thời gian trôi qua
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Đặt lại vị trí ban đầu của chim
        transform.position = initialPosition;

        // Chờ một khoảng thời gian hồi kỹ năng
        float skillCooldown = 5.0f; // Thời gian hồi kỹ năng (đơn vị: giây)
        yield return new WaitForSeconds(skillCooldown);
        isSkillActive = false;
        cooldownCircle2.fillAmount = 1;
    }
    private IEnumerator ShowCooldownThrough()
    {
        float duration = 5.0f;
        cooldownCircle2.gameObject.SetActive(true);
        float timer = duration;

        while (timer > 0f)
        {
            // Cập nhật UI hồi kỹ năng
            float fillAmount = timer / duration;
            cooldownCircle2.fillAmount = fillAmount;

            yield return null;
            timer -= Time.deltaTime;
        }
        cooldownCircle2.fillAmount = 0f;
    }
}
