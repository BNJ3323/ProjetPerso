using UnityEngine;
using UnityEngine.UI;

public class IconButton : MonoBehaviour
{
    public int iconIndex;
    public LogoSelection profileSelector;
    public Sprite buttonImage;

    void Start()
    {
        if (buttonImage != null && profileSelector != null && profileSelector.availableIcons.Length > iconIndex)
        {
            buttonImage = profileSelector.availableIcons[iconIndex];
        }
    }

    public void OnClick()
    {
        profileSelector.OnSelectIcon(iconIndex);
    }
}