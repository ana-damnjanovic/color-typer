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
    float initialSpeed = 5.0f;

    public string GetColor()
    {
        return color;
    }

    public float GetInitialSpeed()
    {
        return initialSpeed;
    }
}

public class ColorBall
{
    string color;
    float speed;
    Material material;

    public ColorBall(string color, float speed, Material material)
    {
        this.color = color;
        this.speed = speed;
        this.material = material;
    }

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

    public Material GetMaterial()
    {
        return material;
    }
}
