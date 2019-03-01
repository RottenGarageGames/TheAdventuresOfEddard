using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable<T>
{
    T health { get; set; }
    void TakeDamage(T damageAmount);
}
