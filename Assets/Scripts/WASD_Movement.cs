 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD_Movement : MonoBehaviour
{
    [Range(0.0f, 5.0f)]
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(-1*Input.GetAxis("Horizontal"), 0, -1*Input.GetAxis("Vertical"));
        moveCharacter(direction);
    }

    void moveCharacter(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}


