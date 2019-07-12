using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_TestStrafeSkill : AbstractStrafeSkill
{
    private GameObject fireballPrefab;
    private GameObject tmp;
    protected override void LoadData()
    {
        Data = Gamef.LoadSkillData(SkillName.TestStrafeSkill);
        fireballPrefab = Resources.Load<GameObject>("Fireball");
        if (fireballPrefab == null)
            Debug.LogError("未能找到Prefab名为：Fireball");
    }

    protected override void Shoot()
    {
        tmp = Gamef.Instantiate(fireballPrefab, SpawnTransform.position, Quaternion.LookRotation(Caster.transform.forward));
        tmp.GetComponent<Missile>().Init(Caster, this);
    }
}
