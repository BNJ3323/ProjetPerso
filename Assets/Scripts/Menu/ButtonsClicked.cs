using UnityEngine;
using UnityEngine.UI;

public class ButtonsClicked : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject meshPlayer;
    
    [Header("Panels")]
    [SerializeField] private GameObject panelPrincipal;
    [SerializeField] private GameObject panelJouer;
    [SerializeField] private GameObject panelCasier;
    [SerializeField] private GameObject panelOptions;
    [SerializeField] private GameObject panelCredits;
    
    public void ButtonJouer() 
    {
        animator.SetBool("IsClickedJouer", true);
    }

    public void ButtonCasier()
    {
        animator.SetBool("IsClickedCasier", true);
    }

    public void ButtonOptions()
    {
        animator.SetBool("IsClickedOptions", true);
    }

    public void ButtonCredits()
    {
        animator.SetBool("IsClickedCredits", true);
    }

    public void ButtonQuitter()
    {
        animator.SetBool("IsClickedQuitter", true);
    }

    public void ModifyPanelsJouer()
    {
        panelPrincipal.SetActive(false);
        panelJouer.SetActive(true);
        animator.SetBool("IsClickedJouer", false);
        meshPlayer.SetActive(false);
    }

    public void ModifyPanelsCasier()
    {
        panelPrincipal.SetActive(false);
        panelCasier.SetActive(true);
        animator.SetBool("IsClickedCasier", false);
    }

    public void ModifyPanelsOptions()
    {
        panelPrincipal.SetActive(false);
        panelOptions.SetActive(true);
        animator.SetBool("IsClickedOptions", false);
        meshPlayer.SetActive(false);
    }

    public void ModifyPanelsCredits()
    {
        panelPrincipal.SetActive(false);
        panelCredits.SetActive(true);
        animator.SetBool("IsClickedCredits", false);
        meshPlayer.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        animator.SetBool("IsClickedQuitter", false);
    }

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
}
