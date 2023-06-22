using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public bool isRedKey, isBlueKey, isYellowKey;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isBlueKey)
            {
                other.GetComponent<PlayerInventory>().hasBlue = true;
            }
            else if (isRedKey)
            {
                other.GetComponent<PlayerInventory>().hasRed = true;
            }
            else if (isYellowKey)
            {
                other.GetComponent<PlayerInventory>().hasYellow = true;
            }
        }
    }
}
