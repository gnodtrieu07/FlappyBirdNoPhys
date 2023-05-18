using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{ 
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TextMeshProUGUI presentScore;
    [SerializeField] private TextMeshProUGUI bestScore;
    [SerializeField] private YellowBird bird1;
    [SerializeField] private RedBird bird2;
    [SerializeField] private BlueBird bird3;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private TextMeshProUGUI scorePro;
    [SerializeField] private Image cooldownCircle;
    [SerializeField] private Image cooldownCircle2;

    [SerializeField] private RuntimeAnimatorController[] birds;
    [SerializeField] private Animator animatorControllers;
    private int highestScore = 0;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    public void GameOver()
    {
        gameOverUI.SetActive(true);
        scorePro.text= string.Empty;
        Time.timeScale = 0f;

        int currentScore = 0;

        // Tính tổng điểm của các con chim trong màn hiện tại
        currentScore += bird1.index;
        currentScore += bird2.index;
        currentScore += bird3.index;

        // So sánh điểm của màn hiện tại với điểm cao nhất và cập nhật nếu cần
        if (currentScore > highestScore)
        {
            highestScore = currentScore;
        }

        // Lưu giá trị điểm cao nhất vào PlayerPrefs
        PlayerPrefs.SetInt("Best", highestScore);

        // Hiển thị điểm của màn hiện tại
        presentScore.text = currentScore.ToString();
        // Hiển thị điểm cao nhất từ PlayerPrefs
        bestScore.text = PlayerPrefs.GetInt("Best").ToString(); 

    }
    public void Replay()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void StartGame() {
        SceneManager.LoadScene("YellowScene");
        Time.timeScale = 1.0f;
    }
    public void ChooseBird(int index)
    {
        PlayerPrefs.SetInt("Option", index);
        ConvertBird();
    }
    public void ConvertBird()
    {
        Debug.Log("ready");
        //int index = option;
        int index = PlayerPrefs.GetInt("Option");
        //animatorControllers.runtimeAnimatorController = birds[index];
        switch (index)
        {
            case 0:
                animatorControllers.runtimeAnimatorController = birds[0];
                bird1.gameObject.SetActive(true);
                bird2.gameObject.SetActive(false);
                bird3.gameObject.SetActive(false);
                break;
            case 1:
                animatorControllers.runtimeAnimatorController = birds[1];
                bird1.gameObject.SetActive(false);
                bird2.gameObject.SetActive(true);
                bird3.gameObject.SetActive(false);
                cooldownCircle2.gameObject.SetActive(false);
                cooldownCircle.gameObject.SetActive(true);
                break;
            case 2:
                animatorControllers.runtimeAnimatorController = birds[2];
                bird1.gameObject.SetActive(false);
                bird2.gameObject.SetActive(false);
                bird3.gameObject.SetActive(true);
                cooldownCircle2.gameObject.SetActive(true);
                cooldownCircle.gameObject.SetActive(false);
                break;
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
}
