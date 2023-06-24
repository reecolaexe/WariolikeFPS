using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [Header("Variables")]
    public int maxHealth;
    public int currentHealth;
    public int maxPistolAmmo;
    public int currentPistolAmmo;
    public int maxShotgunAmmo;
    public int currentShotgunAmmo;

    public bool isDead;

    PlayerUI playerUI;


    void start()
    {
        currentHealth = maxHealth;
        currentPistolAmmo = maxPistolAmmo;
        currentShotgunAmmo = maxShotgunAmmo;
        playerUI = GetComponent<PlayerUI>();
        setStats();
    }

    void setStats()
    {
        playerUI.healthAmount.text = currentHealth.ToString();
        playerUI.pAmmoAmount.text = currentPistolAmmo.ToString();
        playerUI.sAmmoAmount.text = currentShotgunAmmo.ToString();
    }

    public void damagePlayer(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            isDead = true;
            SceneManager.LoadScene("realmap");
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
