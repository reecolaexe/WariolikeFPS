using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private Text healthText;
    [SerializeField] private Text armorText;
    [SerializeField] private Text pistolAmmoText;
    [SerializeField] private Text shotgunAmmoText;

    private PlayerStats stats;

    private void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        updateHealth(stats.currentHealth);
        updateArmor(stats.currentArmor);
        updatePistolAmmo(stats.currentPistolAmmo);
        updateShotgunAmmo(stats.currentShotgunAmmo);
    }

    public void updateHealth(int currentHealth)
    {
        healthText.text = currentHealth.ToString();
    }

    public void updateArmor(int currentArmor)
    {
        armorText.text = currentArmor.ToString();
    }

    public void updatePistolAmmo(int currentPistolAmmo)
    {
        pistolAmmoText.text = currentPistolAmmo.ToString();
    }

    public void updateShotgunAmmo(int currentShotgunAmmo)
    {
        shotgunAmmoText.text = currentShotgunAmmo.ToString();
    }
}
