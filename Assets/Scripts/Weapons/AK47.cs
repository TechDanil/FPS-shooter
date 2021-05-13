using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : Weapon
{
    public override void Init()
    {
        isShooting = false;
        fireInterval = 0.1f;
        nextFire = 0.5f;

        magazineSize = 25;
        ammoHold = 200;
        ammo = 25;

        distanceToHit = 100f;
        SpawnWeapon();
    }

    private void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 100, Color.green);
    }

    public override void Fire()
    {
        directionToFire =Camera.main.transform.forward;

        if (Physics.Raycast(Camera.main.transform.position, directionToFire, out raycastBullet, distanceToHit)
            && Time.time > fireInterval)
        {
            Debug.Log(raycastBullet.collider.name);

            if (raycastBullet.collider.tag == "Enemy")
            {
                EnemyController enemyController = raycastBullet.transform.GetComponent<EnemyController>();

                if (enemyController.zombieHealth != null)
                {
                    Debug.Log("Taking enemy's health");
                    enemyController.zombieHealth.TakeHealth();
                }
                Debug.Log("Hit");
            }

            nextFire = Time.time + fireInterval;
        }
    }

    public override void SpawnWeapon()
    {
        model = Resources.Load("Ak-47") as GameObject;
        SetPositionOfWeaponInOrderToSpawn();
        Debug.Log("Spawn");
    }

    public override void SetPositionOfWeaponInOrderToSpawn()
    {
        var ak47 = Instantiate(model, new Vector3(0f, 0f, 0f), model.transform.rotation);
        ak47.transform.parent = GameObject.Find("transform").transform;

        ak47.transform.localPosition = new Vector3(0.3660964f, 0.03980011f, -0.0906263f);
        ak47.transform.localEulerAngles = new Vector3(3.409f, 81.991f, -450.016f);
    }
}
