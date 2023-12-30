using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private string _savePath = "/savefile.json";

    public static SaveManager Instance { get; private set; }

    public string Name { get; private set; }
    public int Score { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Load();
    }

    [Serializable]
    class SaveData
    {
        public string Name;
        public int Score;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.Name = Name;
        data.Score = Score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + _savePath, json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + _savePath;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Name = data.Name;
            Score = data.Score;
        }
    }

    public void SetName(string name)
    {
        Name = name;
        Save();
    }

    public void SetScore(int score)
    {
        if (score > Score)
        {
            Score = score;
        }

        Save();
    }
}
