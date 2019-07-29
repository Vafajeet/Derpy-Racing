using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    private void Update()
    {
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
        if (Players.Length == 1)
        {
            Debug.Log("LAST ONE DIPSHIT");
        }
    }
    
}
