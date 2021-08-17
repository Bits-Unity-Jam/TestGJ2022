using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanics.Paths

{
public interface IPath
   {
       Vector3 DirectionOnPoint(Vector3 point);
   }
}
