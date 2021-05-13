using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;

    private void Start()
    {
        ChooseWeapon();
    }

    private void Update()
    {
        int previousSelectedMethod = selectedWeapon;
        ChooseNextWeapon();
        ChoosePriviosWeapon();
       
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            selectedWeapon = 3;
        }

        if (previousSelectedMethod != selectedWeapon)
            ChooseWeapon();

    }

    private void ChooseWeapon()
    {
        int weaponIndex = 0;
        foreach (Transform weapon in transform)
        {
            if (weaponIndex == selectedWeapon)
            {
               weapon.gameObject.SetActive(true);
               //Debug.Log(weapon);
            }

            else
            {
              weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

    private int ChooseNextWeapon()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }
        return selectedWeapon;
    }

    private int ChoosePriviosWeapon()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }
        return selectedWeapon;
    }
}
