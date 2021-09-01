using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanics.Paths
{
    public class Segment : MonoBehaviour
    {
        [SerializeField]
        private Transform frontPoint, backPoint;

        public Transform BorderFront { get => frontPoint; }
        public Transform BorderBack { get =>  backPoint; }

    }
}
    