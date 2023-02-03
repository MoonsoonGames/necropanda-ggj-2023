using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpace : MonoBehaviour
{
    public E_Surfaces surface = E_Surfaces.Open;
    public Vector3 size = new Vector3(1, 1, 1);

    public List<GridSpace> neighbours = new List<GridSpace>();

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.4f);
        Gizmos.DrawCube(transform.position, size);
    }

    public void Clicked()
    {
        //change color to green
    }
}
