using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    public GameObject brain;

    // Update is called once per frame
    void Update()
    {
        if (CodeSafe.isSafeOpened == true)
        {
            brain = GameObject.Find("Brain");
            brain.transform.position = new Vector3(brain.transform.position.x, brain.transform.position.y - 1, brain.transform.position.z);
        }
    }
}
