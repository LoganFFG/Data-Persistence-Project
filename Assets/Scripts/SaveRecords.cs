using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SaveRecords : MonoBehaviour
{
    public static SaveRecords instance;

    public string namePlayer;
    public string namePlayerRecord;
    public int scoreRecord = 0;

    public Text textBestScore;
    public TMP_InputField textNamePlayer;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int score;
    }

    public void GetName()
    {
        namePlayer = textNamePlayer.text;
    }

    public void SavePoints(int score)
    {
        SaveData data = new SaveData();
        data.name = namePlayer;
        data.score = score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPoints()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            namePlayerRecord = data.name;
            scoreRecord = data.score;
        }
    }

    public void ResetRecords()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        File.Delete(path);

        textBestScore.text = "Best Score :  : 0";
    }
}
