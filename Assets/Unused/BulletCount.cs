using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCount : MonoBehaviour
{
    public int BullCount;
    public int ShellCount;
    public int CellCount;
    public int RockectCount;

    // Start is called before the first frame update
    void Start()
    {
        BullCount = 12;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Bullet(int BullCount)
    {
        return BullCount;
    }
}
