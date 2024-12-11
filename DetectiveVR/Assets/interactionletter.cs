using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaction : MonoBehaviour
{
    public float interactionDitance;
    public GameObject interactionText;
    public LayerMask interactionLayer;

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDitance, interactionLayer))
        {
            if (hit.collider.gameObject.GetComponent<letter>())
            {
                interactionText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.X))
                {
                    hit.collider.gameObject.GetComponent<letter>().openCloseLetter();
                }
            }
            else
            {
                interactionText.SetActive(false);
            }
        }
        else
        {
            interactionText.SetActive(false);
        }
    }
}