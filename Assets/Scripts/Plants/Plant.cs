using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlant", menuName = "Plants", order = 0)]
public class Plant : ScriptableObject
{
    public string plantName;
    public int health = 10;
    public Sprite sprite;
    public List<E_Surfaces> buildSurfaces = new List<E_Surfaces>();

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
    Open, Slowed, Water, Closed, Null
}