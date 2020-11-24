using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetAsteriod : MonoBehaviour
{
    private bool SpawnBool;
    GameObject MyAsteriod;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++) {
            SpawnAsteriod();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SpawnAsteriod()
    {
        MyAsteriod = Instantiate(Resources.Load("Prefabs/Asteriod 2.0") as GameObject);
        MyAsteriod.transform.parent = this.gameObject.transform;
        if (this.transform.localScale.x <= 1)
        {
            float radius = Random.Range(2, 7);
            MyAsteriod.transform.position = this.transform.position + new Vector3(radius, 0, 0);
        }
        else if (this.transform.localScale.x >= 3)
        {
            float radius = Random.Range(6, 11);
            MyAsteriod.transform.position = this.transform.position + new Vector3(radius, 0, 0);
        }
    }
}