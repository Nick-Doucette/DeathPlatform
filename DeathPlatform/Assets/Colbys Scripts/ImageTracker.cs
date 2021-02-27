using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTracker : MonoBehaviour
{

    public Image MechanicImage;

    public Sprite[] mechanicImages;

    private int currentImageIndex = 0;

    private int mechanicImageSize;


    // Start is called before the first frame update
    void Start()
    {
        mechanicImageSize = mechanicImages.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftButton()
    {
        if(currentImageIndex == 0)
        {
            currentImageIndex = mechanicImageSize - 1;
        }
        else
        {
            currentImageIndex--;
        }

        MechanicImage.sprite = mechanicImages[currentImageIndex];
    }

    public void RightButton()
    {
        if(currentImageIndex == mechanicImageSize - 1)
        {
            currentImageIndex = 0;
        }
        else
        {
            currentImageIndex++;
        }
        MechanicImage.sprite = mechanicImages[currentImageIndex];
    }
}
