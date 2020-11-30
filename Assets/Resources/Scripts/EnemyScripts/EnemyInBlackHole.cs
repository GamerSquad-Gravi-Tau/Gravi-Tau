using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInBlackHole : MonoBehaviour
{
    public bool DestroyThisGameObject = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DestroyThisGameObject)
        {
            Destroy(this.gameObject);
        }
    }
}
