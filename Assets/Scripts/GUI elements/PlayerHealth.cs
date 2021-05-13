using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PlayerHealth : Health
{
    public override int SetDamage()
    {
       return damage;
    }

    public override float SetHealth()
    {
        return unitHealth;
    }

    public override void TakeHealth()
    {
        Debug.Log(unitHealth);
        unitHealth = SetHealth() - SetDamage();
        healthBar.fillAmount = unitHealth / startHealth;
    }
}
