using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 30f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f,0f,rotationSpeed*Time.smoothDeltaTime));
    }
}
