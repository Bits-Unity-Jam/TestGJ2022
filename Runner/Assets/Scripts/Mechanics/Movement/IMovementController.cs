using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanics.Movement
{
    //IMovementController - інтерфейс, через який Player або будь-які інші скрипти керування будуть контролювати персонажа.
    //Цей інтерфейс має властивість Direction, і має реалізуватись скриптом, який і визначатиме, що робити з цією властивістю.
    //Але яким саме скриптом - CubeController, або ше там шось, Player-у байдуже. Адже він працюватиме з будь-яким з них як з інтерфейсом, і задаватиме тільки Direction
    public interface IMovementController
    {
        public float Direction { get; set; }
        public void Jump();
        public void Slide();

    }
}