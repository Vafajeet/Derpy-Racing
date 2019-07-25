using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator3 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        float rotate = Input.GetAxisRaw("Rotate3");

        transform.Rotate(0, 0, rotate * 3);
    }
}
