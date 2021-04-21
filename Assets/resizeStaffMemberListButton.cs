using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class resizeStaffMemberListButton : MonoBehaviour
{
    [SerializeField]
    private RectTransform backgroundRectTransform;
    [SerializeField]
    private TextMeshProUGUI staffNameTMP;
    [SerializeField]
    private TextMeshProUGUI staffStatsTMP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 _staffNameTextSize = staffNameTMP.GetRenderedValues(false);
        Vector2 _staffStatsTextSize = staffStatsTMP.GetRenderedValues(false);
        Vector2 _textPadding = new Vector2 (8, 0);
        backgroundRectTransform.sizeDelta = _staffNameTextSize + _staffStatsTextSize + _textPadding;
    }
}
