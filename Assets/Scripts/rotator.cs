using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        float rotate = Input.GetAxisRaw("Rotate");
 
        transform.Rotate(0, 0, rotate * 3);
    }
}
