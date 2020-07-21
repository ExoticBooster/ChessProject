using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraAroundParent : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 10.0f * Time.deltaTime, 0, Space.World);
    }
}
