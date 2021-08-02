using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] string gameSceneName;
    [SerializeField] GameObject MenuUI;
    [SerializeField] GameObject SettignsUI;
    [SerializeField] GameObject InstrutionsUI;

    public void ActivateMenuSectionUI(int sectionId)
    {
        // sectionId = 0 == Main Menu
        if(sectionId == 0)
        {
            MenuUI.SetActive(true);
            SettignsUI.SetActive(false);
            InstrutionsUI.SetActive(false);
        }
        // sectionId = 1 == Settings
        else if (sectionId == 1)
        {
            MenuUI.SetActive(false);
            SettignsUI.SetActive(true);
            InstrutionsUI.SetActive(false);
        }
        // sectionId = 2 == how to play
        else if (sectionId == 2)
        {
            MenuUI.SetActive(false);
            SettignsUI.SetActive(false);
            InstrutionsUI.SetActive(true);
        }

        LenguageAdministrator.sharedInstance.UpdateTexts();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
