using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArcheryMenu : MonoBehaviour
{
    public CanvasGroup menu;

    public void OnClick()
    {
        if(menu.blocksRaycasts == true)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    void Hide()
    {
        menu.alpha = 0f; //this makes everything transparent
        menu.blocksRaycasts = false; //this prevents the UI element to receive input events
    }

    void Show()
    {
        menu.alpha = 1f;
        menu.blocksRaycasts = true;
    }
}
