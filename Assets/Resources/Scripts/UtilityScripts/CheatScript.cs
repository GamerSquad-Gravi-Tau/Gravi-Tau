using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.H) && Input.GetKeyDown(KeyCode.Return)){
            Debug.Log("Cheat Activated.");
            transform.GetComponent<PlayerWeaponsController>().WeaponMode += 1;
        }
    }
}
