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
    public TMP_InputField playerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadName();
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
    }

    public void SaveName()
    {
        SaveData data = new SaveData();
        data.input = input;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "savefile.json", json);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            input = data.input;
        }
    }
}
