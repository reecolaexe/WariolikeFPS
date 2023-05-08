using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [Header("Variables")]
    public float health;

    public void takeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            
        }
    }

    public void die()
    {
        Destroy(gameObject);
    }

    public void stagger()
    {

    }
}
