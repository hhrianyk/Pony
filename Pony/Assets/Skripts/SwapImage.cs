using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapImage : MonoBehaviour
{
    [SerializeField] private Image Image;
    [SerializeField] private Image back;

    public void newImage(Image image)
    {
        Image.sprite = image.sprite;
        back.sprite = image.sprite;
    }
}
