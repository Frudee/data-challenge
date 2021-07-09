using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public string input;
    public string highScoreName;
    public int highScore;
    public TMP_InputField playerName;
    // public bool firstStart = true;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadName();
        LoadHighScoreName();
        ShowPlayerName();
    }

    public void ShowPlayerName()
    {
        playerName.text = input;
        // playerName = GetComponent<InputField>();
        // playerName.text = input;
        // playerName.value = input;
    }

    public void GetPlayerName(string s)
    {
        input = s;

        // playerName = inputField.GetComponent<Text>().text;
        Debug.Log(input);
    }

    [System.Serializable]
    class SaveData
    {
        public string input;
        public string highScoreName;
        public int highScore;

    }

    public void SaveName()
    {
        SaveData data = new SaveData();
        data.input = input;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "savefile.json", json);
        // firstStart = false;
    }
    public void SaveNameAndScore()
    {
        SaveData data = new SaveData();
        data.highScoreName = highScoreName;
        data.input = input;
        data.highScore = highScore;
        Debug.Log(highScoreName);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "savefile1.json", json);
        // firstStart = false;
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            input = data.input;
            highScore = data.highScore;
            highScoreName = data.highScoreName;
            Debug.Log(highScore + " hs");
        }
    }
    public void LoadHighScoreName()
    {
        string path = Application.persistentDataPath + "savefile1.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);


            highScore = data.highScore;
            highScoreName = data.highScoreName;
            Debug.Log(highScore + " hs");
        }
    }
}
