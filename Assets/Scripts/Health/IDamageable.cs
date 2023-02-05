using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void Damage(int damage);
    void Heal(int healing);
    bool CheckKill();
    void Kill();
}