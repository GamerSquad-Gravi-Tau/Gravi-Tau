using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnAsteriodBelt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.childCount <= 50)
        {
            spawnAsteriodBelt();
        }
    }

    private void spawnAsteriodBelt()
    {
        GameObject NewAsteroid = Instantiate(Resources.Load("Prefabs/Asteriod") as GameObject);
        NewAsteroid.transform.parent = this.gameObject.transform;
        NewAsteroid.transform.position = GetRandomVectorOnCircle();
        NewAsteroid.GetComponent<OrbitMechanic>().randomStart = false;
    }

    private Vector2 GetRandomVectorOnCircle()
    {
        float radius = 50;
        float XPosition = radius * Mathf.Cos(UnityEngine.Random.RandomRange(0,360));
        float YPosition = radius * Mathf.Sin(UnityEngine.Random.RandomRange(0, 360));

        Vector2 newRandom = new Vector2(XPosition, YPosition);
        return newRandom;
    }
}
