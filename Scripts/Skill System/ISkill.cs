using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkill
{
    SkillData Data { get; }
    void Trigger();
    void Init(Unit caster, Transform transform);
}
