using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClubDatabase : MonoBehaviour
{
    public TextMeshProUGUI clubName;
    public Image clubImage;
    public string rank;
    public string money;
    
    public static ClubDatabase Instance;

    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // initialize UI from GameManager's current club
        if (GameManager.Instance != null && GameManager.Instance.CurrentClub != null)
        {
            UpdateFromClub(GameManager.Instance.CurrentClub);
        }
    }

    public void UpdateFromClub(ClubDataSO club)
    {
        if (clubName != null)
            clubName.text = club.clubName;
        if (clubImage != null && club.clubLogo != null)
            clubImage.sprite = club.clubLogo;
        rank = club.rank;
        money = club.money.ToString();
    }
}
