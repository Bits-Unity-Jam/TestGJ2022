using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mechanics.Movement;

namespace Mechanics.Input
{
    


public class Player : MonoBehaviour
{
    IMovementController MovementController;
    // Start is called before the first frame update
    private void Start()
    {
            MovementController = gameObject.GetComponent<IMovementController>();
    }

    // Update is called once per frame
    private void Update()
    {
            float direction = UnityEngine.Input.GetAxis("Horizontal");
            MovementController.Direction = direction;
    }
}
}
