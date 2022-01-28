using Mechanics.Input;
using Mechanics.Interfaces;
using Mechanics.Paths;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mechanics.Movement.Human
{
    public enum HumanControllerState { Moving, Roll, Jump, Death}
    public class HumanController : MonoBehaviour, IMovementController, IDying
    {
        [SerializeField]
        ParticleSystem leftStep;

        [SerializeField]
        AudioSource step;




        [SerializeField]
        float boostTime;
        private int count;
        private const string speedParameterName = "Speed";
        [SerializeField]
        GameObject pathObject;

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

        [SerializeField]
        float jumpForce;

        [SerializeField]
        bool boostMode;

        [SerializeField]
        float turnSpeed;

        HumanControllerState state = HumanControllerState.Moving;
        bool isAlive = true;

        IPath path;

        float jumpVelocity = 0;

        public event EventHandler OnDied;

        public float Direction { get; set; }
        public HumanControllerState State { get => state; set => state = value; }
        public bool BoostMode { get => boostMode; set => boostMode = value; }

        void Start()
        {
            path = pathObject.GetComponent<IPath>();
        }

        void Update()
        {
            
            if (!isAlive)
            {
                animator.SetTrigger("Death");
                return;
            }

            
            speed = Mathf.Clamp(speed + acceleration * Time.deltaTime, 0, maxSpeed);

            if (boostMode)
                speed *= 1.5f;

            Vector3 moving = path.DirectionOnPoint(transform.position) * speed;
            moving.x += Direction * turnSpeed;
            moving += Physics.gravity;
            float animatorSpeed = speed / maxSpeed;
            animator.SetFloat(speedParameterName, animatorSpeed);


            if (jumpVelocity > 0)
            {
                jumpVelocity += Physics.gravity.y * Time.deltaTime;
                moving.y = jumpVelocity;
            }
            else
            {
                jumpVelocity = 0;
            }

            characterController.Move(moving * Time.deltaTime);

        }

        
       
        public void Slide()
        {
            if (state != HumanControllerState.Moving) return;
            if (isAlive && characterController.isGrounded && SimpleJoystick.instance.Direction.x < 0.5 && SimpleJoystick.instance.Direction.x > -0.5 && SimpleJoystick.instance.Direction.y < 0)
                animator.SetTrigger("Slide");
        }


        public void Jump()
        {
            if (isAlive && jumpVelocity <= 0 && characterController.isGrounded)
            {
                jumpVelocity = jumpForce;
                animator.SetTrigger("Jump");
            }

        }

        public void Die()
        {
            isAlive = false;
            OnDied?.Invoke(this, null);
        }

        public void NotifyAboutDeath(Action<object, EventArgs> deathAction)
        {
            OnDied += deathAction.Invoke;
        }



        public void DontNotifyAboutDeath(Action<object, EventArgs> deathAction)
        {
            OnDied -= deathAction.Invoke;
        }

        public void ActivateBoostMode()
        {
            StartCoroutine(BoostModeActivation());
        }
        IEnumerator BoostModeActivation()
        {
            boostMode = true;
            yield return new WaitForSeconds(boostTime);
            boostMode = false;
        }

        public void Step(int legID)
        {
            //Debug.Log(legID);
            leftStep.Play();
            step.Play();
            
        }
    }
}
