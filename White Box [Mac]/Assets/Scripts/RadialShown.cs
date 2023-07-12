using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialShown : MonoBehaviour
{
    public GameObject RadialObject; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            RadialObject.SetActive(true);
            GameManager.instance.currentHackingValue = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            RadialObject.SetActive(false);
            GameManager.instance.currentHackingValue = 0f;
        }
    }




}
