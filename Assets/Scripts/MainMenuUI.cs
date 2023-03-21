using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerInput;
    private DataManager dataManager;

    private string playerName;

    private void Start()
    {
        dataManager = DataManager.Instance;
        Debug.Log(Application.persistentDataPath);
        Debug.Log("Player: " + playerInput.text);
    }

    public void StartGame()
    {
        if (playerInput.text != "")
        {
            playerName = playerInput.text;
        }
        else
        {
            playerName = "Player";
        }

        dataManager.PlayerName = playerName;
        SceneManager.LoadScene("main");
    }

    public void EndGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
