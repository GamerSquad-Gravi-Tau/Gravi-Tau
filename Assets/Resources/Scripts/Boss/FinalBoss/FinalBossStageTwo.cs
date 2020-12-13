using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossStageTwo : MonoBehaviour
{
    public bool StartStageTwo = false;

    private GameObject TurretOne;
    private GameObject TurretTwo;
    private GameObject TurretThree;
    private GameObject TurretFour;
    private GameObject TurretFive;
    private GameObject TurretSix;

    private GameObject MyCamera;
    // Start is called before the first frame update
    void Start()
    {
        MyCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (StartStageTwo)
        {
            SpawnLongShootTurret();
            StartStageTwo = false;
        }
    }

    private void SpawnLongShootTurret()
    {
        TurretOne = Instantiate(Resources.Load("Prefabs/FinalBoss/FinalBossLongShootStageTwo") as GameObject);
        TurretOne.transform.parent = this.gameObject.transform;
        TurretOne.transform.position = new Vector3(MyCamera.transform.position.x, MyCamera.transform.position.y, 0f);

        TurretTwo = Instantiate(Resources.Load("Prefabs/FinalBoss/FinalBossLongShootStageTwo") as GameObject);
        TurretTwo.transform.parent = this.gameObject.transform;
        TurretTwo.transform.position = new Vector3(MyCamera.transform.position.x, MyCamera.transform.position.y, 0f);

        TurretThree = Instantiate(Resources.Load("Prefabs/FinalBoss/FinalBossLongShootStageTwo") as GameObject);
        TurretThree.transform.parent = this.gameObject.transform;
        TurretThree.transform.position = new Vector3(MyCamera.transform.position.x, MyCamera.transform.position.y, 0f);

        TurretFour = Instantiate(Resources.Load("Prefabs/FinalBoss/FinalBossLongShootStageTwo") as GameObject);
        TurretFour.transform.parent = this.gameObject.transform;
        TurretFour.transform.position = new Vector3(MyCamera.transform.position.x, MyCamera.transform.position.y, 0f);

        TurretFive = Instantiate(Resources.Load("Prefabs/FinalBoss/FinalBossLongShootStageTwo") as GameObject);
        TurretFive.transform.parent = this.gameObject.transform;
        TurretFive.transform.position = new Vector3(MyCamera.transform.position.x, MyCamera.transform.position.y, 0f);

        TurretSix = Instantiate(Resources.Load("Prefabs/FinalBoss/FinalBossLongShootStageTwo") as GameObject);
        TurretSix.transform.parent = this.gameObject.transform;
        TurretSix.transform.position = new Vector3(MyCamera.transform.position.x, MyCamera.transform.position.y, 0f);
    }
}
