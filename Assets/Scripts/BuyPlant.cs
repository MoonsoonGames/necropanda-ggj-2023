using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyPlant : MonoBehaviour
{
    public static BuyPlant instance;
    int water = 100;
    public TextMeshProUGUI text;
    public TextMeshProUGUI enemytext;

    private void Start()
    {
        instance = this;
        ChangeWater(0);
    }

    public void BuySeed(Plant plant)
    {
        Debug.Log("Buying plant");
        if (plant.waterCost <= water)
        {
            ChangeWater(-plant.waterCost);
            plant.numberOfPlants++;
        }
    }

    public void ChangeWater(int water)
    {
        this.water += water;
        text.text = this.water.ToString();
    }

    public void SetEnemyCount(int newCount)
    {
        enemytext.text = newCount.ToString();
    }
}
