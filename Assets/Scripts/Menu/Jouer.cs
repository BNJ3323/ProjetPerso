using UnityEngine;

public class Jouer : MonoBehaviour
{
    [SerializeField] private GameObject panelLancer;
    [SerializeField] private GameObject[] saveParty;
    [SerializeField] private GameObject noPartyExistingText;
    
    public void VerifyPartyExist()
    {
        panelLancer.SetActive(true);

        if (saveParty == null)
        {
            noPartyExistingText.SetActive(true);
        }
    }

    public void Reprendre()
    {
        
    }
}
