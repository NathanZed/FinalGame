using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public int maxAmmo = 10;
    public int currentAmmo;
    public float reloadTime = 1f;
    private bool Reloading = false;

    public Camera fpsCam;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Reloading)
            return;

        if(currentAmmo <= 0)
        {
            Reloading = true;
            StartCoroutine(Reload());
            return;
        }

        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    IEnumerator Reload()
    {
        Debug.Log("Reloading....");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        Reloading = false;
    }

    void Shoot()
    {
        RaycastHit hit;
        currentAmmo--;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log("Hit");

            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
