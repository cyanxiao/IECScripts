//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class RockMineMgr : SkillMgr
//{
//    protected RockMineMgr() : base(SkillName.岩石地雷)
//    {

//    }

//    public override void PlayerRelease(Skill skill)
//    {
//        base.PlayerRelease(skill);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        base.Release(skill, out skillEffectBase, Params);
//    }

//    public class RockMine : SkillEffectBase, IReusableClass
//    {
//        public Missile missile = null;
//        private Vector3 pos, dir;
//        private GameObject rockMine;
//        private GameObject Mesh;
//        private MeshRenderer meshRenderer;
//        public RockMine(Skill skill, Vector3 position, Vector3 direction)
//        {
//            this.skill = skill;
//            skill.IsCasting = true;
//            skill.skillEffectBase = this;

//            pos = position;
//            dir = direction;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            Skill skill;
//            Vector3 pos, dir;
//            if (Gamef.CheckObjects(Params, typeof(Skill), typeof(Vector3), typeof(Vector3)))
//            {
//                skill = Params[0] as Skill;
//                pos = (Vector3)Params[1];
//                dir = (Vector3)Params[2];
//            }
//            else return;

//            this.skill = skill;
//            skill.IsCasting = true;
//            skill.skillEffectBase = this;

//            this.pos = pos;
//            this.dir = dir;
//            Start();
//        }

//        public void Detonate()
//        {
//            timer = 0f;
//            skill.IsCasting = true;
//            EventMgr.UpdateEvent.AddListener(DetonateUpdate);
//        }
//        public void DetonateUpdate()
//        {
//            timer += Time.deltaTime;
//            if (timer >= skill.data.SpellTime)
//            {
//                EventMgr.UpdateEvent.RemoveListener(DetonateUpdate);
//                missile = rockMine.GetComponent<Missile>();
//                Blast(missile, null);
//                if (missile != null)
//                    missile.TakeDamage(1e6f);
//                skill.IsCasting = false;
//                skill.skillEffectBase = null;
//            }
//        }
//        #region Override Function
//        public override void Start()
//        {
//            Mesh = new GameObject("Mesh");
//            Mesh.AddComponent<MeshFilter>();
//            meshRenderer = Mesh.AddComponent<MeshRenderer>();
//            //meshRenderer.material
//            rockMine = Resources.Load<GameObject>("RockMineBlast");
//            EventMgr.UpdateEvent.AddListener(Update);
//        }

//        float timer = 0f;
//        public override void Update()
//        {
//            timer += Time.deltaTime;
//            pos = CameraCtrl.Instance.transform.position;
//            dir = CameraCtrl.Instance.transform.forward;
//            if (timer >= skill.data.SpellTime)
//            {
//                EventMgr.UpdateEvent.RemoveListener(Update);
//                pos = pos + dir * 1.2f;

//                lock (GameDB.skillBuffer)
//                {
//                    GameDB.skillBuffer.skill = skill;
//                    GameDB.skillBuffer.skillEffectBase = skill.skillEffectBase;
//                    rockMine = Object.Instantiate(rockMine, pos, Quaternion.LookRotation(dir));
//                }
//                skill.IsCasting = false;
//                //在此处不吧SkillEffectBase设置为null
//            }
//        }

//        public override void HitMissile(Missile self, Missile other)
//        {
//            self.TakeDamage(other.damage);
//            //爆炸        
//            if (self.hp <= 0)
//                Blast(self, other.gameObject);
//        }
//        #endregion

//        #region Null Override Function
//        public override void HitTerrain(Missile self)
//        {

//        }
//        public override void HitUnit(Missile self, Unit unit)
//        {

//        }


//        #endregion
//    }
//}

//public partial class Gamef
//{
//    public static bool CheckObjects(object[] Params, params System.Type[] types)
//    {
//        if (Params.Length != types.Length)
//        {
//            return false;
//        }
//        for (int i = 0; i < Params.Length; i++)
//        {
//            if (!types[i].IsInstanceOfType(Params[0]))
//            {
//                return false;
//            }
//        }
//        return true;
//    }
//}