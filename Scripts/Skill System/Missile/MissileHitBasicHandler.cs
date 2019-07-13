using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MissileHitBasicHandler : IMissileHitHandler
{
    public void Fade(Missile self)
    {
        if (self.Skill.Data.IsAOE)
        {
            self.Blast(null);
        }
    }

    public void HitMissile(Missile self, Missile other)
    {
        self.TakeDamage(other.Damage);
        if (!self.IsAlive)
        {
            if (self.Skill.Data.IsAOE)
            {
                self.Blast(other);
            }
        }
    }

    public void HitTerrain(Missile self)
    {
        if (self.Skill.Data.IsAOE)
        {
            self.Blast(null);
        }
        self.TakeDamage(1e7f);
    }

    public void HitUnit(Missile self, Unit unit)
    {
        if (self.Skill.Data.IsAOE)
        {
            self.Blast(null);
        }
        else
        {
            Gamef.Damage(self.Damage, DamageType.unset, self.Caster, unit);
        }
        self.TakeDamage(1e7f);
    }
}
