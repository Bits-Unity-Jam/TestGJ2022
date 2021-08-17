using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mycomponent : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        print("Start");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(transform.position.x + Time.deltaTime*speed,transform.position.y,transform.position.z);
    }
}
