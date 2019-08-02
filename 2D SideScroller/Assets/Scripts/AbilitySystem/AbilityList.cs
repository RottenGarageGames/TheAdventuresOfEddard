using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static GlobalInputManager;

public class AbilityList : MonoBehaviour
{
    //List of All Available Abilites that can be bound
    public List<Ability> Abilities;

    //Stored Abilities for use
    public Ability EquippedAbility1;
    public Ability EquippedAbility2;
    public Ability EquippedAbility3;
    public Ability EquippedAbility4;

  
    public void DetermineAbility(InputAction inputAction)
    {
        switch(inputAction)
        {
            case InputAction.Ability1: EquippedAbility1.Use(gameObject); break;
            case InputAction.Ability2: EquippedAbility2.Use(gameObject); break;
            case InputAction.Attack1:  EquippedAbility3.Use(gameObject); break;
            case InputAction.Attack2:  EquippedAbility4.Use(gameObject); break;
        }
    }
}
