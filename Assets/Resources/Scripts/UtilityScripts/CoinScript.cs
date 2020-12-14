using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    public static int PlayerWallet;
    public Text coinCount;

    private void Start()
    {
        coinCount.text = "" + PlayerWallet;
    }
    private void Update()
    {
        coinCount.text = "" + PlayerWallet;
    }

    public static void addCoins(int coins)
    {
        PlayerWallet += coins;
    }
}
