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
            int curMode = transform.GetComponent<PlayerWeaponsController>().WeaponMode; 
            if (curMode<4){
                curMode++;
            }
            transform.GetComponent<PlayerWeaponsController>().WeaponMode = curMode;
        }
    }
}
