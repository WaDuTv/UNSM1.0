using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LivingTheDeal.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButtonScript> tabButtons;
    public Color tabIdle;
    public Color tabHovered;
    public Color tabActive;
    public TabButtonScript selectedTab;
    public List<GameObject> objectsToSwap;

    public PanelGroup panelGroup;

    public void Update()
    {
        
    }

    public void Subscribe (TabButtonScript button)
    {
        if(tabButtons == null)
        {
            tabButtons = new List<TabButtonScript>();
        }
        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButtonScript button)
    {
        ResetTabs();
        if (selectedTab == null || button != selectedTab)
        {
            button.background.color = tabHovered;
        }
    }

    public void OnTabExit(TabButtonScript button)
    {
        ResetTabs();        
    }

    public void OnTabSelected(TabButtonScript button)
    {
        if(selectedTab != null)
        {
            selectedTab.Deselect();
        }
        selectedTab = button;

        selectedTab.Select();

        ResetTabs();
        button.background.color = tabActive;
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < objectsToSwap.Count; i++)
        {
            if(i == index)
            {
                objectsToSwap[i].SetActive(true);
            }
            else
            {
                objectsToSwap[i].SetActive(false);
            }
        }

        if (panelGroup != null)
        {
            panelGroup.SetPageIndex(selectedTab.transform.GetSiblingIndex());
        }
    }

    public void ResetTabs()
    {
        foreach (TabButtonScript button in tabButtons)
        {
            if(selectedTab!=null && button == selectedTab) { continue; }
            button.background.color = tabIdle;
        }
    }


}
