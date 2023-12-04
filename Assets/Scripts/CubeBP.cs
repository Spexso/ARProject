using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBP : MonoBehaviour
{
    float y;
    float Ry;

    // Start is called before the first frame update
    void Start()
    {
        y = -1;
        Ry = +1;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position.Set(transform.localPosition.x, y, transform.localPosition.z);
        transform.position.Set(transform.localPosition.x, Ry, transform.localPosition.z);
        transform.position = Vector3.right * Time.deltaTime;
    }
}
