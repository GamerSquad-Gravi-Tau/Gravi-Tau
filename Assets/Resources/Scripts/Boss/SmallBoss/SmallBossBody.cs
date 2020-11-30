using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBossBody : MonoBehaviour
{
    public int SmallBossHealth = 25;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "shot" || collision.gameObject.name == "shot(Clone)")
        {
            if (this.GetComponentInParent<SmallBossBehavoir>().transform.childCount <= 2)
            {
                SmallBossHealth--;
            }
        }
    }
}
