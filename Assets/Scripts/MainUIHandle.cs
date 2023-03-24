using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIHandle : MonoBehaviour
{
    public Text textBestScore;

    // Start is called before the first frame update
    void Start()
    {
        SaveRecords.instance.LoadPoints();
        textBestScore.text = "Best Score : " + SaveRecords.instance.namePlayerRecord + " : " + SaveRecords.instance.scoreRecord;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SaveRecords.instance.GetName();
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }

    public void EndGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        // Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("menu", LoadSceneMode.Single);
    }
}
