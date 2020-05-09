using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstKey : MonoBehaviour
{
    public GameObject Key1;
    public GameObject Key2;
    public GameObject Wall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Key1 == null && Key2 == null)
        {
            Destroy(Wall);
        }
    }
}
