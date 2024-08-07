using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationManager : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        ScoreManager.Instance.LoadHighScoreData();
    }

    public void LoadMain()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene(2);
    }

    public void Exit()
    {
        ScoreManager.Instance.SaveHighScoreData();
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
