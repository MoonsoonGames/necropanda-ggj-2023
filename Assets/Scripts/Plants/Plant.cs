using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlant", menuName = "Plants", order = 0)]
public class Plant : ScriptableObject
{
    public int health = 10;
    public Sprite image;
    public E_Surfaces[] buildSurfaces = new E_Surfaces[1];

    public int waterCost = 1;
    public E_Surfaces surfaceModifier = E_Surfaces.Closed;

    public void SpawnPlant(Vector2 position)
    {
        //check that the plant can be built on the specified surface
        //instantiate plant on position
        //reduce water cost
    }
}

public enum E_Surfaces
{
    Open, Slowed, Water, Closed
}