using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelect : MonoBehaviour
{
    public static MouseSelect instance;
    public LayerMask mask;

    GridSpace selectedSpace; public GridSpace GetCurrentSpace() { return selectedSpace; }

    BuildMenu buildMenu; public BuildMenu GetBuildMenu() { return buildMenu; }

    private void Start()
    {
        instance = this;
        SetupReferences();
    }

    void SetupReferences()
    {
        buildMenu = GetComponent<BuildMenu>();
        buildMenu.SetOpen(E_Surfaces.Null);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse down");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 500, mask))
            {
                Debug.Log("Selected grid");
                GridSpace space = hit.collider.GetComponent<GridSpace>();

                if (space!= null)
                {
                    if (selectedSpace != null)
                        selectedSpace.Selected(false, buildMenu);
                    space.Selected(true, buildMenu);
                    selectedSpace = space;
                }
            }
        }
    }
}
