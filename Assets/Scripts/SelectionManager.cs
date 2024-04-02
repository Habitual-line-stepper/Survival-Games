using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{

    public static SelectionManager Instance { get; set; }

    public bool onTarget;

    public GameObject interaction_info_UI;
    Text interaction_text;

    private void Start()
    {
        //onTarget = false;
        interaction_text = interaction_info_UI.GetComponent<Text>();
    }
    private void Awake()
    {
        if (Instance !=null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

    }
     void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,5)) // lookie here for distance 
        {
            
            var selectionTransform = hit.transform;

            if (selectionTransform.GetComponent<InteractableObject>()&& selectionTransform.GetComponent<InteractableObject>().playerInRange)// ignoring 1 collider to see if inrange
            {
                onTarget = true;
                interaction_text.text = selectionTransform.GetComponent<InteractableObject>().GetItemName();
                interaction_info_UI.SetActive(true);
            }
            else
            {
                onTarget = false;
                interaction_info_UI.SetActive(false);
            }

        }
        else
        {
            onTarget = false;
            interaction_info_UI.SetActive(false);
        }
    }
}
