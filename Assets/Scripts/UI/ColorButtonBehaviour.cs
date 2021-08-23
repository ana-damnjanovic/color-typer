using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButtonBehaviour : MonoBehaviour
{
    string color;
    Material material;
    Texture texture;

    public delegate void OnClickHandler(string color);
    public static event OnClickHandler OnColorButtonClick;

    public void OnClick()
    {
        if (OnColorButtonClick != null)
        {
            OnColorButtonClick(color);
        }
    }

    public void SetColor(string newColor)
    {
        color = newColor;
    }

    public void SetMaterial(Material newMaterial)
    {
        material = newMaterial;
        RawImage image = gameObject.GetComponent<RawImage>();
        image.color = material.GetColor("_Color");
    }

    public void SetTexture(Texture newTexture)
    {
        texture = newTexture;
        RawImage image = gameObject.GetComponent<RawImage>();
        image.texture = texture;
    }
}
