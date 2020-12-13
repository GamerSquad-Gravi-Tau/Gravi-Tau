using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBehavior : MonoBehaviour
{
    public bool playerInBound = false;
    public int enemiesInRange = 0;

    public Text shopText;

    void Update(){
        if(playerInBound){
            shopText.enabled = true;
            if(enemiesInRange==0){
                shopText.text = "Press 'b' to shop";
                //Show Text allowing to buy
                if(Input.GetKey(KeyCode.B)){
                    //GameObject.Find("PlayerShip").GetComponent<PauseScript>().paused=true;
                    //Pause game
                    //Show buy menu
                }
                
            }else{
                shopText.text = "Cannot shop!\nThere are "+ enemiesInRange +" enemies in range!";
                //Show text showing how many enemies are in range
            }
        }else{
            shopText.enabled = false;
        }
    }

}
