using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PauseSystem : MonoBehaviour
{
    public GameObject pausePanel;

    public Button[] buttonsWithContinue = new Button[0];

    public Button[] buttonsWithPause = new Button[0];

    private AudioSource[] audioSources;

    void Start()
    {
        pausePanel.SetActive(false);

        foreach (var button in buttonsWithContinue)
        {
            button.onClick.AddListener(ContinueGame);
        }

        foreach (var button in buttonsWithPause)
        {
            button.onClick.AddListener(PauseGame);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Cancel"))
        {
            if (!pausePanel.activeInHierarchy)
            {
                PauseGame();
            }
            else if (pausePanel.activeInHierarchy)
            {
                ContinueGame();
            }
        }
    }

    public void PauseGame()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        Time.timeScale = 0;
        pausePanel.SetActive(true);
        audioSources = FindObjectsOfType<AudioSource>().Where(aus => aus.isPlaying).ToArray();
        foreach (var item in audioSources)
        {
            item.Pause();
        }
        // Disable scripts that still work while timescale is set to 0
    }

    public void ContinueGame()
    {
        if (Time.timeScale == 1)
        {
            return;
        }

        Time.timeScale = 1;
        pausePanel.SetActive(false);
        foreach (var item in audioSources)
        {
            item.UnPause();
        }
    }
}
