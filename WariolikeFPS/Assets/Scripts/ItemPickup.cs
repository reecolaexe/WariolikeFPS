using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public bool isHealth;
    public bool isPistolAmmo;
    public bool isShotgunAmmo;

    public int amount;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(isHealth)
            {
                other.GetComponent<PlayerStats>().giveHealth(amount);
            }

            if (isPistolAmmo)
            {
                other.GetComponent<PlayerStats>().givePistolAmmo(amount);
            }

            if (isShotgunAmmo)
            {
                other.GetComponent<PlayerStats>().giveShotgunAmmo(amount);
            }
        }
        Destroy(gameObject);    
    }
}
