using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Turret : MonoBehaviour
{

    private Transform target;

    private float fireCountdown = 0f;
    private float fireRate = 1.5f;

    public float range = 15f;
    public Transform rotatePart;
    public string enemyTag = "Enemy";
    private float speed = 10f;

    public GameObject bulletObj;
    public Transform bulletSpawn;


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
       
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortest = Mathf.Infinity;
        GameObject closestEnemy = null;
        
        foreach (GameObject enemy in enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            
            if (dist < shortest)
            {
                shortest = dist;
                closestEnemy = enemy;
            }
        }


        
        if (closestEnemy != null && shortest <= range)
        {
            target = closestEnemy.transform;
        } 
        else
        {
            target = null;
        }

    }

    void Update()
    {

        if (target == null)
        {
            return;
        }

        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(rotatePart.rotation, lookRotation, Time.deltaTime * speed).eulerAngles;
        rotatePart.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = fireRate;
        }
        fireCountdown -= Time.deltaTime;

    }
  
    void Shoot()
    {
        GameObject bulletRef;

        bulletRef = (GameObject) Instantiate(bulletObj, bulletSpawn.position, bulletSpawn.rotation);
        Bullet bullet = bulletRef.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.getTarget(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
