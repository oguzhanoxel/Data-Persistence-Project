using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;



#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public Text BestScoreText;
    public TMP_InputField NameText;

    private void Start()
    {
        SaveManager.Instance.Load();
        NameText.text = SaveManager.Instance.Name;
        BestScoreText.text = $"Score: {SaveManager.Instance.Name}: {SaveManager.Instance.Score}";
    }

    public void SetName(string name)
    {
        SaveManager.Instance.SetName(name);
    }

    public void StartNewGame()
    {
        SaveManager.Instance.Save();
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #endif
        Application.Quit();
    }
}
