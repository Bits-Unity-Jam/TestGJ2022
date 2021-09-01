using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mechanics.Paths;

namespace Mechanics.Movement
{
public class CubeController : MonoBehaviour, IMovementController
    {
        [SerializeField]
        GameObject pathObject;

        [SerializeField]
        float speed;

        IPath path;

        public float Direction { get; set; }

       // Start is called before the first frame update
        void Start()
    {
            path = pathObject.GetComponent<IPath>();
    }

    // Update is called once per frame
    void Update()
    {
            Vector3 moving = path.DirectionOnPoint(transform.position) * speed;
            moving.x += Direction;
            moving -= Physics.gravity;
            

    }
}
}