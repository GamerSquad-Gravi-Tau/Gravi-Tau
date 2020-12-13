using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurveForAISpaceStation : MonoBehaviour
{
    [SerializeField]
    private float TParam;

    private Vector2 SpaceStationPosition;

    private float SpaceStationMoveSpeed;

    private bool CanICoroutine;

    private float LastTimeStamp;

    Vector2 Zero = new Vector2();
    Vector2 One = new Vector2();
    Vector2 Two = new Vector2();
    Vector2 Three = new Vector2();
    Vector2 Four = new Vector2();
    Vector2 Five = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        SpaceStationMoveSpeed = 0.0005f;
        TParam = 0;
        CanICoroutine = true;

        SetRandomBezierPoints();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(GoByTheRoute());

        LastTimeStamp = Time.realtimeSinceStartup;
    }

    private IEnumerator GoByTheRoute()
    {
        TParam += Time.smoothDeltaTime * 0.0005f;
        SpaceStationPosition = Mathf.Pow(1 - TParam, 5) * Zero +
            5 * Mathf.Pow(1 - TParam, 4) * TParam * One +
            10 * Mathf.Pow(TParam, 2) * Mathf.Pow(1 - TParam, 3) * Two +
            10 * Mathf.Pow(TParam, 3) * Mathf.Pow(1 - TParam, 2) * Three +
            5 * Mathf.Pow(TParam, 4) * (1 - TParam) * Four +
            Mathf.Pow(TParam, 5) * Five;

        this.transform.position = SpaceStationPosition;

        LastTimeStamp = Time.realtimeSinceStartup;
        yield return new WaitForEndOfFrame();
    }

    private void SetRandomBezierPoints()
    {
        Zero = GetRandomPosition();
        One = GetRandomPosition();
        Two = GetRandomPosition();
        Three = GetRandomPosition();
        Four = GetRandomPosition();
        Five = GetRandomPosition();
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 V = Random.insideUnitCircle * 280;
        V.z = 0;
        return V;
    }
}
