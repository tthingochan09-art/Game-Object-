using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseMenuUI : MonoBehaviour
{
    [Header("Menu")]
    public GameObject pauseMenuPanel;

    [Header("Sound")]
    public Button soundOffButton;
    public Button soundOnButton;

    [Header("Music")]
    public Button musicOffButton;
    public Button musicOnButton;

    [Header("Tooltips")]
    public Button tooltipOffButton;
    public Button tooltipOnButton;

    [Header("Quality")]
    public Button lowButton;
    public Button midButton;
    public Button highButton;

    [Header("Auto Pause")]
    public Button autoPauseOffButton;
    public Button autoPauseOnButton;

    [Header("Main Buttons")]
    public Button resumeButton;
    public Button quitButton;
    public Button restartButton;

    [Header("Colors")]
    public Color selectedColor = Color.yellow;
    public Color unselectedColor = Color.gray;

    private bool soundOn = false;
    private bool musicOn = false;
    private bool tooltipOn = false;
    private bool autoPauseOn = false;
    private int quality = 2; // 0 = Low, 1 = Mid, 2 = High

    void Start()
    {
        pauseMenuPanel.SetActive(false);

        resumeButton.onClick.AddListener(ResumeGame);
        quitButton.onClick.AddListener(QuitGame);
        restartButton.onClick.AddListener(RestartGame);

        soundOffButton.onClick.AddListener(() => SetSound(false));
        soundOnButton.onClick.AddListener(() => SetSound(true));

        musicOffButton.onClick.AddListener(() => SetMusic(false));
        musicOnButton.onClick.AddListener(() => SetMusic(true));

        tooltipOffButton.onClick.AddListener(() => SetTooltip(false));
        tooltipOnButton.onClick.AddListener(() => SetTooltip(true));

        autoPauseOffButton.onClick.AddListener(() => SetAutoPause(false));
        autoPauseOnButton.onClick.AddListener(() => SetAutoPause(true));

        lowButton.onClick.AddListener(() => SetQuality(0));
        midButton.onClick.AddListener(() => SetQuality(1));
        highButton.onClick.AddListener(() => SetQuality(2));

        UpdateAllButtons();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuPanel.activeSelf)
                ResumeGame();
            else
                OpenMenu();
        }
    }

    public void OpenMenu()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    void SetSound(bool value)
    {
        soundOn = value;
        UpdateAllButtons();
    }

    void SetMusic(bool value)
    {
        musicOn = value;
        AudioListener.volume = musicOn ? 1f : 0f;
        UpdateAllButtons();
    }

    void SetTooltip(bool value)
    {
        tooltipOn = value;
        UpdateAllButtons();
    }

    void SetAutoPause(bool value)
    {
        autoPauseOn = value;
        UpdateAllButtons();
    }

    void SetQuality(int value)
    {
        quality = value;
        QualitySettings.SetQualityLevel(value);
        UpdateAllButtons();
    }

    void UpdateAllButtons()
    {
        SetButtonColor(soundOffButton, !soundOn);
        SetButtonColor(soundOnButton, soundOn);

        SetButtonColor(musicOffButton, !musicOn);
        SetButtonColor(musicOnButton, musicOn);

        SetButtonColor(tooltipOffButton, !tooltipOn);
        SetButtonColor(tooltipOnButton, tooltipOn);

        SetButtonColor(autoPauseOffButton, !autoPauseOn);
        SetButtonColor(autoPauseOnButton, autoPauseOn);

        SetButtonColor(lowButton, quality == 0);
        SetButtonColor(midButton, quality == 1);
        SetButtonColor(highButton, quality == 2);
    }

    void SetButtonColor(Button button, bool selected)
    {
        Image img = button.GetComponent<Image>();

        if (img != null)
        {
            img.color = selected ? selectedColor : unselectedColor;
        }
    }
}