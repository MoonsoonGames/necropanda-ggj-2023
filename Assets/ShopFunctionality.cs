using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopFunctionality : MonoBehaviour
{
    public Plant plant;
    public void Buy()
    {
        plant.numberOfPlants++;
    }
}
