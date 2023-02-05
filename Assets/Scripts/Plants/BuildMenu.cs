using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildMenu : MonoBehaviour
{
    public GameObject growMenu;
    public GameObject plantMenu;
    public PlantInfo plantInfo;
    public GameObject grid;
    public TextMeshProUGUI text;

    public List<Plant> allPlants;
    public Object plantOptionPrefab;
    List<GameObject> availablePlants = new List<GameObject>();

    public void SetOpen(E_Surfaces surface)
    {
        plantMenu.SetActive(false);

        if (surface != E_Surfaces.Null)
        {
            growMenu.SetActive(true);
            GetPlants(surface);
            text.text = surface.ToString();
        }
        else
        {
            growMenu.SetActive(false);
        }
    }

    public void SetOpen(Plant plant)
    {
        growMenu.SetActive(false);

        if (plant != null)
        {
            plantMenu.SetActive(true);
            plantInfo.SetupMenu(plant);
        }
        else
        {
            plantMenu.SetActive(false);
        }
    }

    void GetPlants(E_Surfaces surface)
    {
        RemoveOldPlants();

        foreach (var item in allPlants)
        {
            if (item.buildSurfaces.Contains(surface) && item.numberOfPlants > 0)
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
