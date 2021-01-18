using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DeskUI : MonoBehaviour
{
    private Label counterLabel;
    private Button counterButton;

    private int count;

    private void OnEnable()
    {
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;

        counterLabel = rootVisualElement.Q<Label>("welcome-text");
        counterButton = rootVisualElement.Q<Button>("counter-button");

        counterButton.RegisterCallback<ClickEvent>(ev => IncrementCounter());
    }
    private void IncrementCounter()
    {
        count++;

        counterLabel.text = $"Count: {count}";
    }
}
