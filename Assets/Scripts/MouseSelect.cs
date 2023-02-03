using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelect : MonoBehaviour
{
    public LayerMask mask;

    GridSpace selectedSpace;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse down");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 50, mask))
            {
                Debug.Log("Selected grid");
                GridSpace space = hit.collider.GetComponent<GridSpace>();

                if (space!= null)
                {
                    if (selectedSpace != null)
                        selectedSpace.Selected(false);
                    space.Selected(true);
                    selectedSpace = space;
                }
            }
            else
            {
                if (selectedSpace != null)
                    selectedSpace.Selected(false);
            }
        }
    }
}
