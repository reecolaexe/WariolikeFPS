using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI healthAmount;
    public TextMeshProUGUI pAmmoAmount;
    public TextMeshProUGUI sAmmoAmount;

    PlayerStats playerStats;

    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        setStats();
    }

    void setStats()
    {
        healthAmount.text = playerStats.currentHealth.ToString();
        pAmmoAmount.text = playerStats.currentPistolAmmo.ToString();
        sAmmoAmount.text = playerStats.currentShotgunAmmo.ToString();
    }
}
