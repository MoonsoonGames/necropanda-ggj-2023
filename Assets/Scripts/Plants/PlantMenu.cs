using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantMenu : MonoBehaviour
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
}
