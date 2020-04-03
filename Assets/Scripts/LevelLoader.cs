using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

    }
    public void LoadPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex - 1);
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(6);
    }
    public void CreditsScene()
    {
        SceneManager.LoadScene("Credit");
    }
    public void LevelsScene()
    {
        SceneManager.LoadScene("Levels");
    }
    public void PlayScene()
    {
        SceneManager.LoadScene(2);
    }
    public void AchievementScene()
    {
        SceneManager.LoadScene(0);
    }
    public void SettingsScene()
    {
        SceneManager.LoadScene("Settings");
    }
    public void HelpScene()
    {
        SceneManager.LoadScene("HELP");
    }
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitScreen()
    {
        Application.Quit();
    }
}
