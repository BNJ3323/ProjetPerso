using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Initial Club (optional ScriptableObject)")]
    public ClubDataSO initialClub;

    [HideInInspector]
    public ClubDataSO CurrentClub;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (initialClub != null)
        {
            // create a runtime copy so we don't modify the original asset
            CurrentClub = Instantiate(initialClub);
        }

        // ensure SaveManager exists in scene
        if (SaveManager.Instance == null)
        {
            GameObject go = new GameObject("SaveManager");
            go.AddComponent<SaveManager>();
        }

        // try load
        if (CurrentClub == null)
        {
            // create a default club data SO instance at runtime
            CurrentClub = ScriptableObject.CreateInstance<ClubDataSO>();
            CurrentClub.clubName = "Mon Club";
            CurrentClub.money = 1000;
            CurrentClub.rank = "Débutant";
        }

        SaveManager.Instance.LoadAll(CurrentClub);
    }

    private void OnApplicationQuit()
    {
        if (CurrentClub != null && SaveManager.Instance != null)
            SaveManager.Instance.SaveAll(CurrentClub);
    }
}
