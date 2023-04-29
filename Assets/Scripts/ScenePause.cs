using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePause : MonoBehaviour
{
    public GameObject PausePanel;
    public void PauseButtonPressed()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ContinueButtonPressed()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void RestartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
    }
}
