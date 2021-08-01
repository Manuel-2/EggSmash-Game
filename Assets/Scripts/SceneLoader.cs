using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Animator transitionAnim;
    [SerializeField] float transitionDuration;
    [SerializeField] string transitionTrigger;
    [SerializeField] int gameScene;
    [SerializeField] int menuScene;

    public void LoadScene()
    {
        StartCoroutine(LoadLevel(gameScene));
    }

    public void ReturnMenu()
    {
        StartCoroutine(LoadLevel(menuScene));
    }

    IEnumerator LoadLevel(int Scene)
    {
        transitionAnim.SetTrigger(transitionTrigger);
        yield return new WaitForSeconds(transitionDuration);
        SceneManager.LoadScene(Scene);
    }
}
