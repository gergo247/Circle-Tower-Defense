using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            //destroy takes time, so we return
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        //if bullet reached target ( distance smaller )
        if (dir.magnitude <= distanceThisFrame)
        {
            //hit
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void HitTarget()
    {
        //effect
       GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
       // Destroy effect
        Destroy(effectInstance, 2f);

        Destroy(target.gameObject);
        //destroy bullet
        Destroy(gameObject);
    }
}
