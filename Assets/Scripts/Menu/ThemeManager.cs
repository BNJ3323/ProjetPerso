using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThemeManager : MonoBehaviour
{
    [SerializeField] Color clairBackground = Color.white;
    [SerializeField] Color clairTexte      = Color.black;
    [SerializeField] Color sombreBackground = Color.black;
    [SerializeField] Color sombreTexte      = Color.white;

    private bool sombre = false;

    public Image[] imagesAColorer;
    public TextMeshProUGUI[] textesAColorer;

    void Start()
    {
        AppliquerTheme();
    }

    public void BasculerTheme()
    {
        sombre = !sombre;
        AppliquerTheme();
    }

    void AppliquerTheme()
    {
        Color bg = sombre ? sombreBackground : clairBackground;
        Color fg = sombre ? sombreTexte      : clairTexte;

        foreach (var img in imagesAColorer)
            if (img != null) img.color = bg;

        foreach (var txt in textesAColorer)
            if (txt != null) txt.color = fg;
    }
}