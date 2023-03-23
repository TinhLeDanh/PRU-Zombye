using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = GameConst.Weapon_FileName, menuName = GameConst.Weapon_MenuName, order = GameConst.Weapon_Order)]
public class Weapon : Item
{
    public enum ShootType
    {
        Straight,
        Cone,

    }

    public int damage;
    public float cooldown;

    public int projectilePerShoot;
    public float delayBeforeShoot;
    public float timeBtwShoot;
    [Header("Line")]
    public float lineRange;
    public float lineLifeTime = 1f;
    public Material lineMaterial;
    public Color lineColor;
    [Header("Projectile")]
    public Projectile bullet;

    public void DrawLine(Vector2 originPosition, Vector2 endPosition)
    {
        GameObject line = new GameObject();
        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();

        lineRenderer.material = lineMaterial;
        lineRenderer.material.color = lineColor;
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        lineRenderer.SetPosition(0, new Vector3(originPosition.x, originPosition.y, 0));
        lineRenderer.SetPosition(1, new Vector3(endPosition.x, endPosition.y, 0));
        Destroy(line, lineLifeTime);
    }

    public IEnumerator Apply(BaseGameEntity target, BaseGameEntity caster, int damage)
    {
        int projectileCount = 0;
        if (lineRange > 0 && lineMaterial != null)
        {
            float distance = Vector2.Distance(target.transform.position, caster.transform.position);
            Vector2 endPosition = target.transform.position - caster.transform.position;
            DrawLine(caster.transform.position, target.transform.position);
        }

        Vector2 goalPosition = target.transform.position;

        yield return new WaitForSeconds(delayBeforeShoot);

        while (projectileCount < projectilePerShoot)
        {
            Projectile projectile = Instantiate(bullet, caster.transform.position, Quaternion.identity);
            projectile.Setup(target, damage, goalPosition);
            projectileCount++;
            yield return new WaitForSeconds(timeBtwShoot);
        }
    }
}
