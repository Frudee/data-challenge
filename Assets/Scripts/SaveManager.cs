using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    // public static SaveManager Instance;
    private string input;
    // public GameObject inputField;

    private void Awake()
    {
        // if (Instance != null)
        // {
        //     Destroy(gameObject);
        // }
        // Instance = this;
        // DontDestroyOnLoad(gameObject);
    }

    public void GetPlayerName(string s)
    {
        input = s;
        // playerName = inputField.GetComponent<Text>().text;
        Debug.Log(input);
    }
}
