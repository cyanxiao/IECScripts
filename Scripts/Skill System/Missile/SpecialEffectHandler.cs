using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffectHandler : ISpecialEffectHandler
{
    public void CreateDestroyEffect(Unit caster, Missile missile, GameObject prefab)
    {
        if (prefab != null)
            Gamef.Instantiate(prefab, missile.transform.position, missile.transform.rotation);
    }

    public void CreateSpawnEffect(Unit caster, Missile missile, GameObject prefab)
    {
        if (prefab != null)
            Gamef.Instantiate(prefab, caster.transform.position, caster.transform.rotation);
    }
}
