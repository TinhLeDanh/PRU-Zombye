using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = GameConst.Weapon_FileName, menuName = GameConst.Weapon_MenuName, order = GameConst.Weapon_Order)]
public class Weapon : Item
{
    public int damage;
    public float cooldown;

    public Projectile bullet;

    public void Apply(BaseGameEntity target, BaseGameEntity caster, int damage)
    {
        Projectile projectile = Instantiate(bullet, caster.transform.position, Quaternion.identity);
        projectile.Setup(target, damage);
    }
}
