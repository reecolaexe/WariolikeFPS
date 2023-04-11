using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private Transform[] weapons;
    [SerializeField] private KeyCode[] keys;
    [SerializeField] private float switchTime;

    private int selectedWeapon;
    private float remainingSwitchTime;

    void Start()
    {
        setWeapons();
        select(selectedWeapon);
        remainingSwitchTime = 0f;
    }

    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;
        for (int i = 0; i < keys.Length; i++)
        {
            if(Input.GetKeyDown(keys[i]) && remainingSwitchTime >= switchTime)
            {
                selectedWeapon = i;
            }
            if(previousSelectedWeapon != selectedWeapon)
            {
                select(selectedWeapon);
            }
            remainingSwitchTime += Time.deltaTime;
        }
    }

    private void setWeapons()
    {
        weapons = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            weapons[i] = transform.GetChild(i);
        }
        if (keys == null)
        {
            keys = new KeyCode[weapons.length];
        }

    }

    private void select(int weaponIndex)
    {
        for(int i = 0; i < weapons.length; i++)
        {
            weapons[i].gameObject.SetActive(i == weaponIndex);
        }
        remainingSwitchTime = 0f;
    }
}