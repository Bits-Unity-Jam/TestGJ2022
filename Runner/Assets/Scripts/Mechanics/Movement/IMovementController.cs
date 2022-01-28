using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanics.Movement
{
    //IMovementController - ���������, ����� ���� Player ��� ����-�� ���� ������� ��������� ������ ������������ ���������.
    //��� ��������� �� ���������� Direction, � �� ������������ ��������, ���� � �����������, �� ������ � ���� ����������.
    //��� ���� ���� �������� - CubeController, ��� �� ��� ����, Player-� �������. ���� �� ����������� � ����-���� � ��� �� � �����������, � ���������� ����� Direction
    public interface IMovementController
    {
        public float Direction { get; set; }
        public void Jump();
        public void Slide();

    }
}