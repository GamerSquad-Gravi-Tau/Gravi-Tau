using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlliesManger : MonoBehaviour
{
    GameObject AlliesStationOne;
    GameObject AlliesStationTwo;
    GameObject AlliesStationThree;
    GameObject AlliesStationFour;
    // Start is called before the first frame update
    void Start()
    {
        AlliesStationOne = Instantiate(Resources.Load("Prefabs/AlliesSpaceStation") as GameObject);
        AlliesStationOne.transform.parent = this.gameObject.transform;
        AlliesStationOne.transform.position = new Vector3(0f, -65f, 0f);

        AlliesStationTwo = Instantiate(Resources.Load("Prefabs/AlliesSpaceStation") as GameObject);
        AlliesStationTwo.transform.parent = this.gameObject.transform;
        AlliesStationTwo.transform.position = new Vector3(0f, 125f, 0f);

        AlliesStationThree = Instantiate(Resources.Load("Prefabs/AlliesSpaceStation") as GameObject);
        AlliesStationThree.transform.parent = this.gameObject.transform;
        AlliesStationThree.transform.position = new Vector3(170f, 0f, 0f);

        AlliesStationFour = Instantiate(Resources.Load("Prefabs/AlliesSpaceStation") as GameObject);
        AlliesStationFour.transform.parent = this.gameObject.transform;
        AlliesStationFour.transform.position = new Vector3(-256f, 0f, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
