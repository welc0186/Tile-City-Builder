using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionType
{
    NONE,
    ATTACK_MAIN
}

public interface IInput
{
    Vector3 MoveVector { get; }
    ActionType ActionType { get; }
}

public interface IDamageable
{
    void TakeDamage(object source, float amt);
}