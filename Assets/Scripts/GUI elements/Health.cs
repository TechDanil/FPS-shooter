using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Health : MonoBehaviour
{
    public int damage;
    public float unitHealth;
    public Image healthBar;
    public float startHealth;
    protected Quaternion rotation;

    public abstract void TakeHealth();
    public abstract float SetHealth();
    public abstract int SetDamage();
}
