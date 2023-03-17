using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = GameConst.Weapon_FileName, menuName = GameConst.Weapon_MenuName, order = GameConst.Weapon_Order)]
public class Weapon : Item
{
    public enum ShootType
    {
        Straight,
        Test,

    }

    public int damage;
    public float cooldown;

    public int projectilePerShoot;
    public float timeBtwShoot;
    public ShootType direction;
    public Projectile bullet;

    public IEnumerator Apply(BaseGameEntity target, BaseGameEntity caster, int damage)
    {
        int projectileCount = 0;

        while (projectileCount < projectilePerShoot)
        {
            Projectile projectile = Instantiate(bullet, caster.transform.position, Quaternion.identity);
            projectile.Setup(target, damage);
            projectileCount++;
            yield return new WaitForSeconds(timeBtwShoot);
        }
    }
}
