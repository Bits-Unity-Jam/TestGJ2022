using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanics.Paths
{



 public class StraightPaths : MonoBehaviour, IPath
  {
     public Vector3 DirectionOnPoint(Vector3 point)
     {
        return transform.forward;
     }
  }
}