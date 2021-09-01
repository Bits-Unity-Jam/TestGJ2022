using Mechanics.Paths;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanics.Movement.Human
{

    public class HumanController : MonoBehaviour, IMovementController
    {
        private const string speedParametrName = "Speed";
        [SerializeField]
        GameObject pathObject;

        [SerializeField]
        bool boostMode;

        [SerializeField]
        Animator animator;

        [SerializeField]
        CharacterController characterController;

        [SerializeField]
        float speed;

        [SerializeField]
        float maxSpeed = 5;

        [SerializeField]
        float acceleration = 0.1f;

        public float Direction { get; set; }

        IPath path;
        void Start()
        {
            path = pathObject.GetComponent<IPath>();
        }
        void Update()
        {
            speed = Mathf.Clamp(speed + acceleration * Time.deltaTime, 0, maxSpeed);
            if (boostMode)
                speed = speed * 1.5f;
            Vector3 moving = path.DirectionOnPoint(transform.position) * speed;
            moving.x += Direction;
            moving += Physics.gravity;
            float animatorSpeed = speed / maxSpeed;
            animator.SetFloat(speedParametrName, animatorSpeed);
            characterController.Move(moving * Time.deltaTime);
            characterController.enabled = false;
            transform.position = path.ClampPosition(transform.position);
            characterController.enabled = true;
        }
    }
}
