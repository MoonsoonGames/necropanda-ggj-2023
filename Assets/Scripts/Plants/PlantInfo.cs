using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantInfo : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image image;

    Plant plant;

    public void SetupMenu(Plant plant)
    {
        this.plant = plant;
        text.text = plant.plantName;
        image.sprite = plant.sprite;
    }

    public void ButtonPressed()
    {
        //Check if plant can be built (cost)
        MouseSelect.instance.canClick = false;
        MouseSelect.instance.GetCurrentSpace().GrowPlant(plant);
    }
}
