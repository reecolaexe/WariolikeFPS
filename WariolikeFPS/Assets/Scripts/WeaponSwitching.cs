using System;
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
    private float timeSinceLastSwitch;

    private void Start()
    {
        setWeapons();
        select(selectedWeapon);

        timeSinceLastSwitch = 0f;
    }

    private void setWeapons()
    {
        weapons = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            weapons[i] = transform.GetChild(i);

        if (keys == null) keys = new KeyCode[weapons.Length];
    }

    private void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        for (int i = 0; i < keys.Length; i++)
        {
            if (Input.GetKeyDown(keys[i]) && timeSinceLastSwitch >= switchTime)
            {
                selectedWeapon = i;
            }
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            select(selectedWeapon);
        }
        timeSinceLastSwitch += Time.deltaTime;
    }

    private void select(int weaponIndex)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].gameObject.SetActive(i == weaponIndex);
        }

        timeSinceLastSwitch = 0f;
        onWeaponSelected();
    }

    private void onWeaponSelected() { }
}