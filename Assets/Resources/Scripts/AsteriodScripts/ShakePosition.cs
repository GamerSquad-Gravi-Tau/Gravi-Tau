using System;
using UnityEngine;

public class ShakePosition
{
    private Vector2 MyShakeDelta;
    private float MyDuration;
    private float MyOmega;

    //Runtime
    private float MySecLeft = 0;
    private Vector3 MyOriginalPosition;

    public ShakePosition(float frequency, float durationInSec)
    {
        SetShakeParameters(frequency, durationInSec);
    }

    public void SetShakeParameters(float frequency, float durationInSec)
    {
        MyDuration = durationInSec;
        MyOmega = frequency * 2 * Mathf.PI;
    }

    public void SetShakeMagnitude(Vector2 magnitude, Vector3 OriginalPosition)
    {
        MyOriginalPosition = OriginalPosition;
        MyShakeDelta = magnitude;
        MySecLeft = MyDuration;
    }

    public void SetShakeMagnitude_ForShip(Vector2 magnitude, Vector3 OriginalPosition)
    {
        MyOriginalPosition = OriginalPosition;
        MyShakeDelta = magnitude;
    }

    public Vector3 UpdateShake()
    {
        MySecLeft -= Time.smoothDeltaTime;
        Vector3 P = MyOriginalPosition;

        if (!ShakeDone())
        {
            float v = NextDampeHarmonic();
            float fx = ((UnityEngine.Random.Range(0f, 1f) > 0.5f) ? (0f - v) : v);
            float fy = ((UnityEngine.Random.Range(0f, 1f) > 0.5f) ? (0f - v) : v);
            P.x += MyShakeDelta.x * fx;
            P.y += MyShakeDelta.y * fy;
        }

        //Debug.Log(P);
        return P;
    }

    public bool ShakeDone()
    {
        //Debug.Log(MySecLeft <= 0f);
        return MySecLeft <= 0f;
    }

    private float NextDampeHarmonic()
    {
        var frac = MySecLeft / MyDuration;
        return frac * frac * Mathf.Cos((1 - frac) * this.MyOmega);
    }
}
