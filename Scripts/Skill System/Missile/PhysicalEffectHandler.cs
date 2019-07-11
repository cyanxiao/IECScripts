using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalEffectHandler : IPhysicalEffectHandler
{
    private float explosionRadius;

    public void CreateExplosiveForce(SkillData data, Vector3 position)
    {
        // 爆炸半径设置为 SkillData 中最大伤害半径
        explosionRadius = data.OuterBlastRadius;
        Collider[] hits = Physics.OverlapSphere(position, explosionRadius);

        // 对在爆炸半径内的 rigidbody 施加 SkillData 中的爆炸力
        Rigidbody rb;
        foreach (Collider hit in hits)
        {
            rb = hit.attachedRigidbody;
            if (rb != null)
            {
                rb.AddExplosionForce(data.Force, position, explosionRadius, 0f, ForceMode.Impulse);
            }
        }
    }

    public void CreateImpulse(SkillData data, Vector3 position, Vector3 direction, Rigidbody rigidbody)
    {
        rigidbody.AddForceAtPosition(direction, position, ForceMode.Impulse);
    }
}
