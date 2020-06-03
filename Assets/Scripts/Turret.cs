using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Stats")]
    public float range = 15f;
    public float fireRate = 0.2f;
    private float fireCountdown = 0f;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    //for storing gameobject
    public Transform firePoint;


    [Header("Setup")]
    public string targetTag = "Enemy";
    public Transform partToRotate;

    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    //looks for target
    //idea : only look when no target
    void UpdateTarget()
    {
        //lock on target
        if (target != null && Vector3.Distance(transform.position, target.position) <= range)
        {
            return;
        }

        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestTarget = null;


        foreach (GameObject target in targets)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            if (distanceToTarget < shortestDistance)
            {
                shortestDistance = distanceToTarget;
                nearestTarget = target;
            }
        }
        //if in range, target enemy
        if (nearestTarget != null && shortestDistance <= range)
        {
            target = nearestTarget.transform;
        }
        else
        {
            target = null;
        }


    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        //rotate to target
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        // lerp - slow motion change from 1 to another
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }
    //unity function
    //range
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.grey;
        Gizmos.DrawWireSphere(transform.position,range);
    }

    void Shoot()
    {
       GameObject bulletGameObject = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGameObject.GetComponent<Bullet>();
        if (bullet != null)
            bullet.Seek(target);

    }

}
