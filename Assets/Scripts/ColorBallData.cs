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
    float velocity = 5.0f;

    public string getColor()
    {
        return color;
    }

    public float getVelocity()
    {
        return velocity;
    } 

    public void setVelocity(float newVelocity)
    {
        velocity = newVelocity;
    }
}
