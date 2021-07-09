using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Debug.Log("exit");
        // SaveManager.Instance.SaveName();

#if UNITY_EDITOR
        Debug.Log("exit");
        EditorApplication.ExitPlaymode();
        SaveManager.Instance.SaveNameAndScore();
        Debug.Log("exit");
#else

        Application.Quit();
        // SaveManager.Instance.SaveName();
#endif
    }

}
