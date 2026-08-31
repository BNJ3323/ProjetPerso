using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class SaveData
{
    public int selectedIconIndex;
}

public class LogoSelection : MonoBehaviour
{
    public static LogoSelection Instance;

    public Image profilImage;
    public GameObject panelSelection;

    public Sprite[] availableIcons;

    [HideInInspector] public string savePath;
    public int currentIconIndex = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        savePath = Application.persistentDataPath + "/saveLogo.json";
    }

    void Start()
    {
        panelSelection.SetActive(false);
        LoadProfile();
        
        Debug.Log(savePath);
    }

    public void OnClickOpenSelection()
    {
        panelSelection.SetActive(true);
    }

    public void OnSelectIcon(int iconIndex)
    {
        if (iconIndex >= 0 && iconIndex < availableIcons.Length)
        {
            currentIconIndex = iconIndex;
            profilImage.sprite = availableIcons[iconIndex];
            SaveProfile(iconIndex);
        }
        panelSelection.SetActive(false);
    }

    private void SaveProfile(int iconIndex)
    {
        SaveData data = new SaveData();
        data.selectedIconIndex = iconIndex;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
    }

    private void LoadProfile()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            if (data.selectedIconIndex >= 0 && data.selectedIconIndex < availableIcons.Length)
            {
                currentIconIndex = data.selectedIconIndex;
                profilImage.sprite = availableIcons[data.selectedIconIndex];
            }
        }
        else
        {
            if (availableIcons.Length > 0)
            {
                profilImage.sprite = availableIcons[0];
                currentIconIndex = 0;
                SaveProfile(0);
            }
        }
    }

    public Sprite GetCurrentIcon()
    {
        return availableIcons[currentIconIndex];
    }
}
