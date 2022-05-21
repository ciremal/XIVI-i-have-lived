using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shiftGreen : MonoBehaviour
{
    public void shift()
    {
        transform.position = new Vector3(transform.position.x, -2, transform.position.z);
    }
}
