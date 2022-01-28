using Mechanics.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanics.Obstacles
{
    public class DeathObstacle : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            IDying dying = other.GetComponent<IDying>();
            if (dying != null)
            {
                dying.Die();
            }
        }


    }
}