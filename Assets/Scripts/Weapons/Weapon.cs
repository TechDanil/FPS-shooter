using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int ammo;
    public int ammoHold;
    public int magazineSize;
    public float fireInterval;
    public float nextFire;
    public GameObject model;
    [HideInInspector]public Transform fireTip;
    protected Vector3 directionToFire;
    protected float distanceToHit;
    protected RaycastHit raycastBullet;
    protected bool isShooting;

    public abstract void SetPositionOfWeaponInOrderToSpawn();
    public abstract void Init();
    public abstract void Fire();
    public abstract void SpawnWeapon();
}
