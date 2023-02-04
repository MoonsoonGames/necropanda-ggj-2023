using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverrideParent : MonoBehaviour
{
    [ContextMenu("Set Surface - Water")]
    public void SetWater()
    {
        GridSpace space = GetComponentInParent<GridSpace>();
        space.SetupBaseSurface(E_Surfaces.Water);
    }

    [ContextMenu("Set Surface - Random")]
    public void SetRandom()
    {
        GridSpace space = GetComponentInParent<GridSpace>();
        int randInt = Random.Range(0, 3);

        switch (randInt)
        {
            case 0:
                space.SetupBaseSurface(E_Surfaces.Open);
                break;
            case 1:
                space.SetupBaseSurface(E_Surfaces.Marsh);
                break;
            case 2:
                space.SetupBaseSurface(E_Surfaces.Water);
                break;
        }
    }
}
