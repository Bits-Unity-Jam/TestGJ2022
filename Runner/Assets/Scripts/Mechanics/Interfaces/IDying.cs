using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanics.Interfaces
{
    public interface IDying
    {
        public void Die();

        public void NotifyAboutDeath(System.Action<object, EventArgs> deathAction);
        public void DontNotifyAboutDeath(System.Action<object, EventArgs> deathAction);
    }
}