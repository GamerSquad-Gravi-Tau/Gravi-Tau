using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenToDropItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int a;
        a = Random.Range(0,2);
        Debug.Log(a);
    }

    private void FivePercentDropBoost()
    {
        int R = GetRandomNumberForDrop();

        if (R == 1)
        {
            GameObject DropBoost = Instantiate(Resources.Load("Prefabs") as GameObject);
            DropBoost.transform.position = this.transform.position + new Vector3(0.5f, 0f, 0f);
        }
    }

    private void TenPercentDropCoin()
    {

    }

    private int GetRandomNumberForDrop()
    {
        int R;
        R = Random.Range(0, 20);
        return R;
    }

    private int GetSecondRandomNumber()
    {
        int R;
        R = Random.Range(0, 2);
        return R;
    }
}
