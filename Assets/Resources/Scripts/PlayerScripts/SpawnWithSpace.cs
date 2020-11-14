using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWithSpace : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space)){
            GameObject e = Instantiate(Resources.Load("Prefabs/ChaseEnemy") as GameObject);
            e.transform.rotation = gameObject.transform.rotation;
            e.transform.position = gameObject.transform.position;
            e.transform.position += gameObject.transform.up*3f;
        }
        
    }
}
