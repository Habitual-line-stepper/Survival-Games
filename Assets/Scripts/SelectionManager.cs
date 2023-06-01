using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public GameObject interaction_info_UI;
    Text interaction_text;

    private void Start()
    {
        interaction_text = interaction_info_UI.GetComponent<Text>();
    }

     void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,5)) // lookie here for distance 
        {
            var selectionTransform = hit.transform;

            if (selectionTransform.GetComponent<InteractableObject>()) //) && selectionTransform.GetComponent<InteractableObject>().playerInRange)
            {
                interaction_text.text = selectionTransform.GetComponent<InteractableObject>().GetItemName();
                interaction_info_UI.SetActive(true);
            }
            else
            {
                interaction_info_UI.SetActive(false);
            }

        }
        else
        {
            interaction_info_UI.SetActive(false);
        }
    }
}
