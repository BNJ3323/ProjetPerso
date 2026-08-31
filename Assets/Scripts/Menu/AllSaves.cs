using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class AllSaves : MonoBehaviour
{
    
    [SerializeField] private GameObject savePrefab; 
    [SerializeField] private Transform parentSavePrefab;

    private int countPrefab = 0;
    
    [SerializeField] private GameObject logoHomeInGame;
    [SerializeField] private GameObject logoExterieurInGame;
    
    [SerializeField] private TextMeshProUGUI textNameClub;
    [SerializeField] private TextMeshProUGUI textNomClubExterieur;

    public void UpdateSave()
    {
        Image image = savePrefab.GetComponentInChildren<Image>();
        
        TextMeshProUGUI text = savePrefab.GetComponentInChildren<TextMeshProUGUI>();
        
       string chemin = Path.Combine(LogoSelection.Instance.savePath);
       if (File.Exists(chemin))
       {
           string json = File.ReadAllText(chemin);
           SaveData data = JsonUtility.FromJson<SaveData>(json);
           data.selectedIconIndex = LogoSelection.Instance.currentIconIndex;
           image.sprite = LogoSelection.Instance.availableIcons[LogoSelection.Instance.currentIconIndex];

           logoHomeInGame.GetComponent<Image>().sprite = image.sprite;
       }

       textNameClub.text = PlayerPrefs.GetString("Nom du club");
       text.text = textNameClub.text;

       if (countPrefab < 3)
       {
           countPrefab++;
           GameObject instSavePrefab = Instantiate(savePrefab, parentSavePrefab);
       }
       
       UpdateLogoExterieur();
       UpdateNomClubExterieur();
    }

    public void UpdateLogoExterieur()
    {
        logoExterieurInGame.GetComponent<Image>().sprite = LogoSelection.Instance.availableIcons[Random.Range(0, LogoSelection.Instance.availableIcons.Length)];
    }

    public void UpdateNomClubExterieur()
    {
        TextAsset nomsFictifs = Resources.Load<TextAsset>("NomsClubFictifs");

        if (nomsFictifs == null)
        {
            Debug.LogError("NomsClubFictifs introuvable dans Resources.");
            return;
        }

        string[] noms = nomsFictifs.text.Split('\n');

        int index = Random.Range(0, noms.Length);
        textNomClubExterieur.text = noms[index].Trim();
    }
}
