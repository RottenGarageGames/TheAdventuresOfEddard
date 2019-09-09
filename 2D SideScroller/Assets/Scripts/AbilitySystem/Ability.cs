using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CalebPlayerController;

public abstract class Ability : ScriptableObject
{
    public string Name;
    public float CoolDownTime;
    public bool Unlocked;
    public Sprite UISprite;
    public PlayerID playerID;
    public abstract void Use(GameObject callingObject);
}
