using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Bullet : MonoBehaviour
{


    private Transform target;
    private float bulletSpeed = 60f;
    public GameObject bulletParticles;
    public static int waveSize;

    public void getTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;

        transform.Translate(dir.normalized * bulletSpeed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 1f)
        {
            Destroy(gameObject);
            Destroy(target.gameObject);
            waveSize -= 1;
            Stats.Money += 15;
            
            

            GameObject particles = (GameObject) Instantiate(bulletParticles, transform.position, transform.rotation);
            Destroy(particles, 3f);


            return;
        }

    }
}
