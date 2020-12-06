using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    public static int count;
    public Text coinCount;

    public GameObject player;

    private void Start()
    {
        player = GameObject.Find("PlayerShip");
        count = player.GetComponent<PlayerCoin>().PlayerWallet;
        coinCount.text = "" + count;
    }
    private void Update()
    {
        player = GameObject.Find("PlayerShip");
        count = player.GetComponent<PlayerCoin>().PlayerWallet;
        coinCount.text = "" + count;
    }
}
