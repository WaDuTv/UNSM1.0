using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;

public class CloseDesktopMenu : MonoBehaviour
{
    [SerializeField]
    private UIView desktopView;

    public void CloseDesktop()
    {
        desktopView.Hide();
    }
}
