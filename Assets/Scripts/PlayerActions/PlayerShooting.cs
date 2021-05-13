using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    public Text ammoDisplay;
    public List<Weapon> weapons = new List<Weapon>();
    [SerializeField] private Animator animator;
    private bool isDead;
    private bool isRealodle;
    private bool isShootble;

    private void Start()
    {
        weapons.Add(new AK47());
        weapons.Add(new M4());
        
        foreach(Weapon weapon in weapons)
        {
            Debug.Log("init");
            weapon.Init();
        }
        isDead =  false;
        isRealodle = false;
        isShootble = false;
    }

    private void Update()
    {
        MakeShot();
    }
    
    private void LateUpdate()
    {
        ShowAmmoOnTheScreen();
    }

    private void MakeShot()
    {
        foreach (Weapon weapon in weapons)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && weapon.ammo > 0)
            {
                weapon.Fire();
                weapon.ammo--;
                animator.SetBool("Shoot", true);
                //Debug.Log("Firing");
            }

            else
            {
                IsReloaded();
                animator.SetBool("Shoot", false);
            }
        }
    }

    private void IsReloaded()
    {
        foreach (Weapon weapon in weapons)
        {
            if (Input.GetKey(KeyCode.R))
            {
                if (weapon.ammoHold > 0)
                {
                    DoRealoadGuns();
                }
            }
        }
    }

    private void ShowAmmoOnTheScreen()
    {
        foreach(Weapon weapon in weapons)
        {
           ammoDisplay.text = weapon.ammo + "/" + weapon.ammoHold;
        }
    }

    private void DoRealoadGuns()
    {
        foreach(Weapon weapon in weapons)
        {
            int bulletToRealod = weapon.magazineSize - weapon.ammo;

            if(bulletToRealod < weapon.ammoHold)
            {
                weapon.ammoHold = weapon.ammoHold - bulletToRealod;
                weapon.ammo = weapon.ammo + bulletToRealod;
            }

            else if (weapon.ammoHold < weapon.magazineSize)
            {
                weapon.ammo = weapon.ammoHold;
                weapon.ammoHold = 0;
            }

            else
            {
                weapon.ammo = weapon.ammo + bulletToRealod;
                weapon.ammoHold = 0;
            }
        }
    }
}

  
