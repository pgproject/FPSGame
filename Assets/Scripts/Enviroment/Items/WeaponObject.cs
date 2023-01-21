using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponObject : ItemObject<Weapon>
{
    public abstract void Attack();
}
