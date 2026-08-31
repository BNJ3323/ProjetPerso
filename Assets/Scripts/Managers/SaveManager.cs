using System;
using System.IO;
using UnityEngine;

[Serializable]
public class SaveFile
{
    public string clubName;
    public int money;
    public string rank;
    public TeamData team;
}

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    private string path;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        path = Path.Combine(Application.persistentDataPath, "savegame.json");
    }

    public void SaveAll(ClubDataSO club)
    {
        SaveFile file = new SaveFile();
        file.clubName = club.clubName;
        file.money = club.money;
        file.rank = club.rank;
        file.team = club.team;

        string json = JsonUtility.ToJson(file, true);
        try
        {
            File.WriteAllText(path, json);
#if UNITY_EDITOR
            Debug.Log("SaveManager: Saved to " + path);
#endif
        }
        catch (Exception e)
        {
            Debug.LogError("SaveManager: Failed to save - " + e.Message);
        }
    }

    public bool LoadAll(ClubDataSO club)
    {
        if (!File.Exists(path)) return false;
        try
        {
            string json = File.ReadAllText(path);
            SaveFile file = JsonUtility.FromJson<SaveFile>(json);
            club.clubName = file.clubName;
            club.money = file.money;
            club.rank = file.rank;
            club.team = file.team ?? new TeamData(club.clubName + " Team");
#if UNITY_EDITOR
            Debug.Log("SaveManager: Loaded save from " + path);
#endif
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError("SaveManager: Failed to load - " + e.Message);
            return false;
        }
    }
}
