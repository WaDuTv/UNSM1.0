using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;

public class sendToReview : MonoBehaviour
{
    public UIView developmentSumaryView;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendToReviewButton()
    {
        developmentSumaryView.Hide();
        //Save values for this Game in instantiated GameObject with needed Stats-Script
        //Destroy this ProgressBar        
    }
}
