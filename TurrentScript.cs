using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentScript : MonoBehaviour
{
    private Transform target;

    public float range = 15f;
    public float turnSpeed = 10f;
    public int Damage = 10;

    public string enemyTag = "Player";
    public AudioSource source;
    public ParticleSystem muzzleFlash;

    public Transform partToRotate;

    public float fireRate = 1f;
    private float fireCountdown = 0f;

    public PlayerHealth player;
    public GameObject bulletPrefab;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
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

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = /*lookRotation.eulerAngles*/ Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out hit, range))
        {
            //Debug.Log("Fire");
            //Target PlayerHealth = enemyTag = "Player";
            //Target.EnemyDamage(Damage);
            //Target target = hit.transform.GetComponent<Target>();
            //player.EnemyDamage(Damage);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(Damage);
            }
            source.Play();
        }
           
    }
}
