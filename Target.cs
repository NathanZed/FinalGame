using UnityEngine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public Slider HealthBar;
    public bool player = false;

    public void Start()
    {
        if(gameObject.tag == "Player")
        {
            player = true;
        }
    }

    public void Update()
    {
        if (player == true)
        {
            HealthBar.value = health;
        }

    }

    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        if (gameObject.tag == "Player")
        {
            //Debug.Log("Die");
            Application.LoadLevel(7);
        }

        Destroy(gameObject);
    }
}
