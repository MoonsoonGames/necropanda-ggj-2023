using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBeforePlay : MonoBehaviour
{
    public void PlayOnConnect()
    {
        AISpawner.instance.SpawnNextWave();
    }
}
