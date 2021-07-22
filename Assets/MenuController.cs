using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] string gameSceneName;

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
