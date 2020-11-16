using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpaceStation : MonoBehaviour
{
    private bool SpawnBool;
    GameObject MySpaceStation;
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
        MySpaceStation = Instantiate(Resources.Load("Prefabs/SpaceStationWithOrbit") as GameObject);
        MySpaceStation.transform.parent = this.gameObject.transform;
        if (this.transform.localScale.x <= 1)
        {
            MySpaceStation.transform.position = this.transform.position + new Vector3(3, 0, 0);
        }
        else if (this.transform.localScale.x >= 3)
        {
            MySpaceStation.transform.position = this.transform.position + new Vector3(7, 0, 0);
        }
    }
}
