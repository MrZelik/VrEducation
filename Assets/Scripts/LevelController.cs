using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private AudioClip winSound;

    AudioSource audioSource;

    public string lobbySceneName;

    [SerializeField] private string[] gameLevels;

    public static LevelController singleton;

    public static int currentLevel;

    private void Awake()
    {
        singleton = this;

        audioSource = GetComponent<AudioSource>();
    }

    public void FinishLevel(bool needNext)
    {
        StartCoroutine(EndLevel(needNext));
    }

    private IEnumerator EndLevel(bool needNext)
    {
        currentLevel++;

        yield return new WaitForSeconds(3f);

        winPanel.SetActive(true);

        audioSource.PlayOneShot(winSound);

        timerText.text = "3";
        yield return new WaitForSeconds(1f);
        timerText.text = "2";
        yield return new WaitForSeconds(1f);
        timerText.text = "1";
        yield return new WaitForSeconds(1f);
        timerText.text = "0";
        yield return new WaitForSeconds(1f);

        if (needNext)
        {
            SceneManager.LoadScene(lobbySceneName);
        }
        else
        {
            SelectScene();
        }
    }

    private IEnumerator StartLevelCur(string sceneName)
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneName);
    }

    public void StartLevel(string sceneName)
    {
        StartCoroutine(StartLevelCur(sceneName));
    }

    private void SelectScene()
    {
        if(currentLevel >= 3)
        {
            SceneManager.LoadScene(lobbySceneName);
        }

        SceneManager.LoadScene(gameLevels[currentLevel]);
    }
}
