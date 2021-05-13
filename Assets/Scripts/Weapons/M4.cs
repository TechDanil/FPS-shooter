using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4 : Weapon
{
    public override void Init()
    {
        magazineSize = 25;
        ammoHold = 200;
        ammo = 25;
        fireInterval = 0.5f;
        nextFire = 2f;
       
        SpawnWeapon();
    }

    public override void Fire()
    {
        directionToFire = Camera.main.transform.forward;

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
        model = Resources.Load("M4A1 Sopmod") as GameObject;
        SetPositionOfWeaponInOrderToSpawn();
       
        //m4.transform.parent = GameObject.Find("Spine2").transform;

        //m4.transform.localPosition = new Vector3(0.096f, 0.121f, -0.177f);
        //m4.transform.localEulerAngles = new Vector3(178.105f, 89.394f, 98.784f);
        Debug.Log("Spawn");
    }
   
    public override void SetPositionOfWeaponInOrderToSpawn()
    {
        var m4 = Instantiate(model, new Vector3(0f, 0f, 0f), model.transform.rotation);
        m4.transform.parent = GameObject.Find("transform").transform;

        m4.transform.localPosition = new Vector3(0.337f, -0.034f, -0.017f);
        m4.transform.localEulerAngles = new Vector3(-8.645f, -102.638f, -276.612f);
    }
}


