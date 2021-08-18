using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColorBallDataWrapper
{
    public List<ColorBallData> dataset;
}

[System.Serializable]
public class ColorBallData
{
    [SerializeField]
    string color = "Red";
    [SerializeField]
    float speed = 5.0f;

    public string GetColor()
    {
        return color;
    }

    public float GetSpeed()
    {
        return speed;
    } 

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
