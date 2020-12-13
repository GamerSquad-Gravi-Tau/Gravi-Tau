using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossBody : MonoBehaviour
{
    private int MyHealth = 50;
    
    public bool CanBeDamaged;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (MyHealth <= 0)
        {
            FinalBossGetAway();
            float distance = Vector3.Distance(this.transform.position, new Vector3(40f, 0f, 0f));
            if (distance >= 30)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void FinalBossGetAway()
    {
        this.transform.position += new Vector3(0f, 0.1f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "shot" || collision.gameObject.name == "shot(Clone)")
        {
            if (CanBeDamaged)
            {
                MyHealth -= 2;
            }
        }
    }
}
