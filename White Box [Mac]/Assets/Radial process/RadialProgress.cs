using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class RadialProgress : MonoBehaviour
{
    [SerializeField] Text text;

    [SerializeField] Image image;

    [SerializeField] float speed;

    float currentValue; 
    
    void Update()
    {
        if (currentValue < 100 && GameManager.instance.startHacking)
        {
            currentValue += speed * Time.deltaTime;
            text.text = ((int)currentValue).ToString() + "%"; 
        }
        else
        {
            text.text = "Done";
        }
        image.fillAmount = currentValue / 100; 

    }
}
