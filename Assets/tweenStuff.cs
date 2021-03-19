using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class tweenStuff : MonoBehaviour
{
    public Transform objectToTween;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TweenBlurValue()
    {
        LeanTween.value(objectToTween.gameObject, 90, 0.1f, 0.3f).setEaseInElastic().setOnUpdate(setFocusDistance);
    }

    public void setFocusDistance(float value)
    {
        DepthOfField focusValue = objectToTween.gameObject.GetComponent<Volume>().GetComponent<DepthOfField>();
        focusValue.focusDistance.value = value;
    }
}
