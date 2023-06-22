using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Variables")]
    public int maxHealth;
    public int currentHealth;
    public int maxArmor;
    public int currentArmor;
    public int maxPistolAmmo;
    public int currentPistolAmmo;
    public int maxShotgunAmmo;
    public int currentShotgunAmmo;

    void start()
    {
        currentArmor = maxArmor;
        currentHealth = maxHealth;
        currentPistolAmmo = maxPistolAmmo;
        currentShotgunAmmo = maxShotgunAmmo;
    }

    public void damagePlayer(int damage)
    {
        if(currentArmor > 0)
        {
            if(currentArmor >= damage)
            {
                currentArmor -= damage;
            }
            else if(currentArmor <= damage)
            {
                int remainingDamage;
                remainingDamage = damage - currentArmor;
                currentArmor = 0;
            }
        }
        else
        {
            currentHealth -= damage;
        }
        
        if(currentHealth <= 0)
        {
            //Add death code here
        }
    }

    public void giveHealth(int amount)
    {
        currentHealth += amount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void giveArmor(int amount)
    {
        currentArmor += amount;
        if (currentArmor > maxArmor)
        {
            currentArmor = maxArmor;
        }
    }

    public void givePistolAmmo(int amount)
    {
        currentPistolAmmo += amount;
        if (currentPistolAmmo > maxPistolAmmo)
        {
            currentPistolAmmo = maxPistolAmmo;
        }
    }

    public void giveShotgunAmmo(int amount)
    {
        currentShotgunAmmo += amount;
        if (currentShotgunAmmo > maxShotgunAmmo)
        {
            currentShotgunAmmo = maxShotgunAmmo;
        }
    }
}
