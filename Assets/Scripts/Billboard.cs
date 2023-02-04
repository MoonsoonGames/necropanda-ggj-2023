using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public bool lockX = false;
    public bool lockY = false;
    public bool lockZ = false;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Setup", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main == null) return;

        //Rotate towards active camera
        Vector3 direction = Camera.main.transform.position - transform.position;
        Quaternion desiredRot = Quaternion.LookRotation(direction);

        if (lockX) desiredRot.x = transform.rotation.x;
        if (lockY) desiredRot.y = transform.rotation.y;
        if (lockZ) desiredRot.z = transform.rotation.z;

        transform.rotation = desiredRot;
    }
}