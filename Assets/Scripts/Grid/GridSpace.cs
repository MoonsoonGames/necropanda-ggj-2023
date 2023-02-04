using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpace : MonoBehaviour
{
    public E_Surfaces baseSurface = E_Surfaces.Open;
    E_Surfaces currentSurface;
    public Vector3 size = new Vector3(1, 1, 1);

    public List<GridSpace> neighbours = new List<GridSpace>();

    MeshRenderer meshRenderer;

    bool selected = false;

    private void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        currentSurface = baseSurface;
    }

    public void SetupBaseSurface(E_Surfaces surface)
    {
        baseSurface = surface;
        currentSurface = surface;
        UpdateMaterial();
    }

    public void Selected(bool selected, BuildMenu buildMenu)
    {
        this.selected = selected;

        if (selected)
        {
            buildMenu.SetOpen(currentSurface);
        }
        else
        {
            buildMenu.SetOpen(E_Surfaces.Null);
        }

        UpdateMaterial();
    }

    public void SetupSize(Vector3 cubeSize, Vector3 colliderSize)
    {
        this.size = cubeSize;
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        meshRenderer.gameObject.transform.localScale = cubeSize;
        UpdateMaterial();

        GetComponent<BoxCollider>().size = colliderSize;
    }

    public void GrowPlant(Plant plant)
    {
        currentSurface = plant.surfaceModifier == E_Surfaces.Null ? baseSurface : plant.surfaceModifier;
        MouseSelect.instance.GetBuildMenu().SetOpen(currentSurface);
        UpdateMaterial();
    }

    public void DestroyPlant()
    {
        currentSurface = baseSurface;
        UpdateMaterial();
    }

    public Material[] baseMats;
    public Material[] selectMats;

    public void UpdateMaterial()
    {
        switch (currentSurface)
        {
            case E_Surfaces.Open:
                meshRenderer.material = selected ? selectMats[0] : baseMats[0];
                break;
            case E_Surfaces.Marsh:
                meshRenderer.material = selected ? selectMats[1] : baseMats[1];
                break;
            case E_Surfaces.Water:
                meshRenderer.material = selected ? selectMats[2] : baseMats[2];
                break;
            case E_Surfaces.Closed:
                meshRenderer.material = selected ? selectMats[3] : baseMats[3];
                break;
            case E_Surfaces.Null:
                meshRenderer.material = selected ? selectMats[4] : baseMats[4];
                break;
        }
    }
}