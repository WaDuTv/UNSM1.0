using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToolTipScreenSpaceUI : MonoBehaviour
{
    public static ToolTipScreenSpaceUI Instance { get; private set; }

    [SerializeField]
    private RectTransform canvasRectTransform;
    private RectTransform backgroundRectTransform;
    private TextMeshProUGUI textMeshPro;
    private RectTransform rectTransform;

    private System.Func<string> getTooltipTextFunc;

    private void Awake()
    {
        Instance = this;

        backgroundRectTransform = transform.Find("background").GetComponent<RectTransform>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        rectTransform = transform.GetComponent<RectTransform>();

        HideTooltip();
    }

    private void Update()
    {
        SetText(getTooltipTextFunc());

        Vector2 anchoredPosition = Input.mousePosition / canvasRectTransform.localScale.x;
        
        if(anchoredPosition.x + backgroundRectTransform.rect.width > canvasRectTransform.rect.width)
        {
            //has left right side
            anchoredPosition.x = canvasRectTransform.rect.width - backgroundRectTransform.rect.width;
        }
        if (anchoredPosition.x + backgroundRectTransform.rect.width < 0)
        {
            //has left left side
            anchoredPosition.x = 0;
        }
        if (anchoredPosition.y + backgroundRectTransform.rect.height > canvasRectTransform.rect.height)
        {
            //has left top side
            anchoredPosition.y = canvasRectTransform.rect.height - backgroundRectTransform.rect.height;
        }
        if (anchoredPosition.y + backgroundRectTransform.rect.height < 0)
        {
            //has left bottom side
            anchoredPosition.y = 0;
        }
        rectTransform.anchoredPosition = anchoredPosition;
    }

    private void SetText(string tooltipText)
    {
        textMeshPro.SetText(tooltipText);
        textMeshPro.ForceMeshUpdate();

        Vector2 textSize = textMeshPro.GetRenderedValues(false);
        Vector2 paddingSize = new Vector2(8, 8);

        backgroundRectTransform.sizeDelta = textSize + paddingSize;
    }

    private void ShowTooltip(string tooltipText)
    {
        gameObject.SetActive(true);
        SetText(tooltipText);
    }

    private void ShowTooltip(System.Func<string> getTooltipTextFunc)
    {
        this.getTooltipTextFunc = getTooltipTextFunc;
        gameObject.SetActive(true);
        SetText(getTooltipTextFunc());
    }

    private void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    public static void ShowTooltip_Static(string tooltipText)
    {
        Instance.ShowTooltip(tooltipText);
    }

    public static void ShowTooltip_Static(System.Func<string> getTooltipTextFunc)
    {
        Instance.ShowTooltip(getTooltipTextFunc);
    }

    public static void Hidetooltip_Static()
    {
        Instance.HideTooltip();
    }
}
