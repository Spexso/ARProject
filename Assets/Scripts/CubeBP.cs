using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBP : MonoBehaviour
{
    // Initialize variable to store y coordinate value and times minus one y to 
    // Animate a movement
    float y;
    float Ry;

    // Start is called before the first frame update
    void Start()
    {
        // Assign values
        y = -1;
        Ry = +1;
    }

    // Update is called once per frame
    void Update()
    {
        // Set transform Repeatedly to animate movement
        transform.position.Set(transform.localPosition.x, y, transform.localPosition.z);
        transform.position.Set(transform.localPosition.x, Ry, transform.localPosition.z);
        transform.position = Vector3.right * Time.deltaTime;
    }
}
