using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Object space;

    public float gridSpacing = 1.2f;
    public Vector2Int gridSize = new Vector2Int(5, 5);
    public Vector3 spaceSize = new Vector3(1, 0.2f, 1);
    public List<GridSpace> spaces;

    [ContextMenu("Setup Grid")]
    public void SetupGrid()
    {
        ResetGrid();

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector3 spawnPos = new Vector3(x * gridSpacing, 0,  y * gridSpacing);
                GameObject spaceRef = Instantiate(space, transform) as GameObject;
                spaceRef.name += (" (" + x + "," + y + ")");
                spaceRef.transform.position = transform.position + spawnPos;

                GridSpace spaceScript = spaceRef.GetComponent<GridSpace>();
                spaces.Add(spaceScript);
                spaceScript.SetupSize(spaceSize, new Vector3(gridSpacing, spaceSize.y, gridSpacing));
            }
        }

        SetupNeighbours();
    }

    [ContextMenu("Reset Grid")]
    public void ResetGrid()
    {
        foreach(var item in spaces)
        {
            DestroyImmediate(item.gameObject);
        }

        spaces.Clear();
    }

    [ContextMenu("Cleanup Grid")]
    public void CleanupGrid()
    {
        GridSpace[] childSpaces = GetComponentsInChildren<GridSpace>(); 

        foreach (var item in childSpaces)
        {
            DestroyImmediate(item.gameObject);
        }

        spaces.Clear();
    }

    void SetupNeighbours()
    {
        //TODO: Check for edges
        for (int i = 0; i < spaces.Count; i++)
        {
            List<GridSpace> neighbours = new List<GridSpace>();

            if ((i+1)%gridSize.y != 0 && WithinArray(i + 1))
            {
                neighbours.Add(spaces[i + 1]);
            }

            if ((i) % gridSize.y != 0 && WithinArray(i - 1))
            {
                neighbours.Add(spaces[i - 1]);
            }

            if (WithinArray(i + gridSize.y))
            {
                neighbours.Add(spaces[i + gridSize.y]);
            }

            if (WithinArray(i - gridSize.y))
            {
                neighbours.Add(spaces[i - gridSize.y]);
            }

            spaces[i].neighbours = neighbours;
        }
    }

    bool WithinArray(int i)
    {
        return spaces.Count > i && i >= 0;
    }

    [ContextMenu("Randomize Grid Surfaces")]
    public void RandomizeGridSurfaces()
    {
        foreach (var item in spaces)
        {
            int randInt = Random.Range(0, 4);

            switch (randInt)
            {
                case 0:
                    item.SetupBaseSurface(E_Surfaces.Open);
                    break;
                case 1:
                    item.SetupBaseSurface(E_Surfaces.Marsh);
                    break;
                case 2:
                    item.SetupBaseSurface(E_Surfaces.Water);
                    break;
                case 3:
                    item.SetupBaseSurface(E_Surfaces.Closed);
                    break;
            }
        }
    }

    [ContextMenu("Randomize Grid Surfaces - No Close")]
    public void RandomizeGridSurfacesNoClose()
    {
        foreach (var item in spaces)
        {
            int randInt = Random.Range(0, 3);

            switch (randInt)
            {
                case 0:
                    item.SetupBaseSurface(E_Surfaces.Open);
                    break;
                case 1:
                    item.SetupBaseSurface(E_Surfaces.Marsh);
                    break;
                case 2:
                    item.SetupBaseSurface(E_Surfaces.Water);
                    break;
            }
        }
    }
}
