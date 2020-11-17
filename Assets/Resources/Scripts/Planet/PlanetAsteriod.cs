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
        //SpawnBool = CheckSpawnSpaceStation();

        //if (SpawnBool)
        //{
        //    SpawnSpaceStation();
        //}

        SpawnSpaceStation();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private bool CheckSpawnSpaceStation()
    {
        return (Random.Range(0, 2) == 1);
    }

    private void SpawnSpaceStation()
    {
        MyAsteriod = Instantiate(Resources.Load("Prefabs/Asteriod") as GameObject);
        MyAsteriod.transform.parent = this.gameObject.transform;
        if (this.transform.localScale.x <= 1)
        {
            MyAsteriod.transform.position = this.transform.position + new Vector3(3, 0, 0);
        }
        else if (this.transform.localScale.x >= 3)
        {
            MyAsteriod.transform.position = this.transform.position + new Vector3(7, 0, 0);
        }
    }
}