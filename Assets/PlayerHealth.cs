using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int StartingHP = 100;
    public float EnergyP = 50;
    public int CurrentHP;
    //public int EnemyDamage;
    public bool Invin;
    public Slider HealthBar;
    public Slider EnergyBar;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = StartingHP;
        Invin = false;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.value = CurrentHP;
        //CurrentHP -= EnemyDamage;
        EnergyBar.value = EnergyP;

        if (Invin == true)
        {
            //EnemyDamage = 0;
            Invin = false;
        }

        /*
        if (Input.GetButtonDown("Fire2"))
        {
            EnergyP--;
            //EnergyP -= Time.deltaTime;
            //Debug.Log("Shield");
            Invin = true;
        }
        */
    }

    public void EnemyDamage(int amount)
    {
        CurrentHP -= amount;
        if (CurrentHP <= 0f)
        {
            Destroy(gameObject);
        }
    }

}
