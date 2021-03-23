using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;

public class hideDesktopUI : MonoBehaviour
{
    public UIView desktopView;
    public UIView createNewGameView;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideDesktop()
    {
        desktopView.Hide();
        createNewGameView.Hide();
    }
}
