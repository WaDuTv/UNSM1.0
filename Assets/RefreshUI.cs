using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefreshUI : MonoBehaviour
{
    public RectTransform layoutRoot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ForceUpdateCanvases()
    {
        Canvas.ForceUpdateCanvases();
    }
}
