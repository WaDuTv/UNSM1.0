using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] public Material highlightMaterial;
    [SerializeField] public Material defaultMaterial;

    private Transform _currentSelection;
    private Transform _newSelection;

    private bool selectionMade = false;
    private void Update()
    {
        if (_currentSelection != _newSelection)
        {            
            Destroy(_currentSelection.GetComponent<Outline>());
            //_currentSelection = null;
                    
        }
        if (_currentSelection == _newSelection)
        {
            //Destroy(_currentSelection.GetComponent<Outline>());
            //_currentSelection = null;
            
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var currentSelection = hit.collider.gameObject;
           
                if (currentSelection.CompareTag(selectableTag) && currentSelection.GetComponent<Outline>() == null)
                {

                    var outline = currentSelection.AddComponent<Outline>();
                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 5f;
                    _currentSelection = currentSelection.transform;                    
                    
                }
            if (currentSelection.CompareTag(selectableTag) && currentSelection.GetComponent<Outline>() != null)
            {
                
            }

        }
        var newray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit newhit;
        if (Physics.Raycast(newray, out newhit))
        {
            var newSelection = newhit.collider.gameObject;

            //if (newSelection.CompareTag(selectableTag) && newSelection.GetComponent<Outline>() == null)
            //{

            //    var outline = currentSelection.AddComponent<Outline>();
            //    outline.OutlineMode = Outline.Mode.OutlineAll;
            //    outline.OutlineColor = Color.yellow;
            //    outline.OutlineWidth = 5f;
            //    _currentSelection = currentSelection.transform;
            //    Debug.Log("Object Highlighted");
            //}

        }
    }
}
