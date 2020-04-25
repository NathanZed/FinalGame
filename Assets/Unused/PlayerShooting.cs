using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform Firepoint;
    public GameObject BulletPrefab;

    public float bulletForce = 20f;

    BulletCount Count;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("mouse 0"))
        {
            GameObject Bullet = Instantiate(BulletPrefab, Firepoint.position, Firepoint.rotation);
            Rigidbody Rig = Bullet.GetComponent<Rigidbody>();

            Rig.AddForce(Firepoint.up * bulletForce, ForceMode.Impulse);
        }
    }
}
