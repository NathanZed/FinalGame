using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void menu()
    {
        Application.LoadLevel(0);
    }

    public void credit()
    {
        Application.LoadLevel(1);
    }

    public void controls()
    {
        Application.LoadLevel(2);
    }

    public void Level1()
    {
        Application.LoadLevel(3);
    }
    /*
    public void Vic1()
    {
        Application.LoadLevel(4);
    }
    */
    public void Level2()
    {
        Application.LoadLevel(5);
    }
    /*
    public void Vic2()
    {
        Application.LoadLevel(6);
    }

    /*
    public void Defeat()
    {
        Application.LoadLevel(7);
    }
    */
    public void Exit()
    {
        Application.LoadLevel(0);
    }

    public void no()
    {
        Application.Quit();
    }
}
