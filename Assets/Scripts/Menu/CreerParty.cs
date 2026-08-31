using TMPro;
using UnityEngine;

public class CreerParty : MonoBehaviour
{
    public TextMeshProUGUI clubName;

    void Start()
    {
        ChargerNomClub();
    }
    
    public void SauvegarderNomClub()
    {
        PlayerPrefs.SetString("Nom du club", clubName.text);
        PlayerPrefs.Save();
    }
    
    public void ChargerNomClub()
    {
        if (PlayerPrefs.HasKey("Nom du club"))
        {
            clubName.text = PlayerPrefs.GetString("Nom du club");
        }
    }
}
