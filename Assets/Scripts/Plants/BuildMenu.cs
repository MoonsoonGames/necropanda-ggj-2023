using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject grid;
    public TextMeshProUGUI text;

    public List<Plant> allPlants;
    public Object plantOptionPrefab;
    List<GameObject> availablePlants = new List<GameObject>();

    public void SetOpen(E_Surfaces surface)
    {
        if (surface != E_Surfaces.Null)
        {
            menu.SetActive(true);
            GetPlants(surface);
            text.text = surface.ToString();
        }
        else
        {
            menu.SetActive(false);
        }
    }

    public void SetOpen(Plant plant)
    {
        if (plant != null)
        {
            menu.SetActive(true);
            //GetPlants(surface);
            //text.text = surface.ToString();
        }
        else
        {
            menu.SetActive(false);
        }
    }

    void GetPlants(E_Surfaces surface)
    {
        RemoveOldPlants();

        foreach (var item in allPlants)
        {
            if (item.buildSurfaces.Contains(surface))
            {
                GameObject plantOption = Instantiate(plantOptionPrefab, grid.transform) as GameObject;
                availablePlants.Add(plantOption);

                PlantMenu plantMenu = plantOption.GetComponent<PlantMenu>();
                plantMenu.SetupMenu(item);
            }
        }
    }

    void RemoveOldPlants()
    {
        foreach (var item in availablePlants)
        {
            DestroyImmediate(item.gameObject);
        }

        availablePlants.Clear();
    }
}
