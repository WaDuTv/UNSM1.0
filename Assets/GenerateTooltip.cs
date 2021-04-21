using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTooltip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        System.Func<string> getTooltipTextFunc = () =>
        {
            return "Text"; /* + whatever you may generate & desire */
        };
        ToolTipScreenSpaceUI.ShowTooltip_Static(getTooltipTextFunc);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
