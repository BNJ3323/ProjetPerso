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
    public GameObject[] players;

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
    }
}
