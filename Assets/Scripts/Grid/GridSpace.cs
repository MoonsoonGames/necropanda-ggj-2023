using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpace : MonoBehaviour
{
    public E_Surfaces surface = E_Surfaces.Open;
    public Vector3 size = new Vector3(1, 1, 1);

    public List<GridSpace> neighbours = new List<GridSpace>();

    bool selected = false;

    private void OnDrawGizmos()
    {
        switch (surface)
        {
            case E_Surfaces.Open:
                Gizmos.color = selected ? new Color(0, 1, 0, 0.5f) : new Color(0, 1, 0, 0.2f);
                break;
            case E_Surfaces.Slowed:
                Gizmos.color = selected ? new Color(1f, 0.4f, 0f, 0.5f) : new Color(1f, 0.4f, 0f, 0.2f);
                break;
            case E_Surfaces.Water:
                Gizmos.color = selected ? new Color(0, 0, 1, 0.5f) : new Color(0, 0, 1, 0.2f);
                break;
            case E_Surfaces.Closed:
                Gizmos.color = selected ? new Color(1, 0, 0, 0.5f) : new Color(1, 0, 0, 0.2f);
                break;
            case E_Surfaces.Null:
                Gizmos.color = selected ? new Color(0, 0, 0, 0.8f) : new Color(0, 0, 0, 0.4f);
                break;
        }
        
        Gizmos.DrawCube(transform.position, size);
    }

    public void Selected(bool selected, BuildMenu buildMenu)
    {
        this.selected = selected;

        if (selected)
        {
            buildMenu.SetOpen(surface);
        }
        else
        {
            buildMenu.SetOpen(E_Surfaces.Null);
        }
    }

    public void SetupSize(Vector3 size)
    {
        this.size = size;
        GetComponent<BoxCollider>().size = size;
    }

    public void GrowPlant(Plant plant)
    {
        //cost
        surface = plant.surfaceModifier;
        MouseSelect.instance.GetBuildMenu().SetOpen(surface);
    }
}