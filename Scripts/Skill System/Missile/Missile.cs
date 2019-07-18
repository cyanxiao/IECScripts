using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(TrackSystem))]
public class Missile : MonoBehaviour
{
    public float HP { get; private set; }
    public float Damage { get; private set; }
    public bool IsAlive { get; private set; } = true;
    public LayerMask collidesWith = ~(1 << 10);
    public GameObject spawnEffect;
    public GameObject deathEffect;
    public ISkill Skill { get; private set; }
    public int ID { get; private set; } = -1;

    public Unit Caster { get; private set; }

    IMissileHitHandler missileHitHandler;
    IPhysicalEffectHandler physicalEffectHandler = new PhysicalEffectHandler();
    ISpecialEffectHandler specialEffectHandler;
    TrackSystem trackSystem;
    bool isInit = false;

    private void Awake()
    {
        trackSystem = GetComponent<TrackSystem>();
    }

    /// <summary>
    /// 对投掷物初始化。
    /// </summary>
    /// <param name="caster">投掷物的释放者</param>
    /// <param name="skill">释放投掷物的技能</param>
    public void Init(Unit caster, ISkill skill)
    {
        this.Caster = caster;
        this.Skill = skill;
        this.Damage = skill.Data.Damage;
        this.HP = skill.Data.MissileHP;
        this.missileHitHandler = new MissileHitBasicHandler();
        this.specialEffectHandler = new SpecialEffectHandler();
        ID = Gamef.MissileBirth(this);
        isInit = true;
    }

    /// <summary>
    /// 对投掷物初始化。
    /// </summary>
    /// <param name="caster">投掷物的释放者</param>
    /// <param name="skill">释放投掷物的技能</param>
    /// <param name="specialEffectHandler">特效创建</param>
    public void Init(Unit caster, ISkill skill, ISpecialEffectHandler specialEffectHandler)
    {
        this.Caster = caster;
        this.Skill = skill;
        this.Damage = skill.Data.Damage;
        this.HP = skill.Data.MissileHP;
        this.missileHitHandler = new MissileHitBasicHandler();
        this.specialEffectHandler = specialEffectHandler;
        ID = Gamef.MissileBirth(this);
        isInit = true;
    }

    /// <summary>
    /// 对投掷物初始化。
    /// </summary>
    /// <param name="caster">投掷物的释放者</param>
    /// <param name="skill">释放投掷物的技能</param>
    /// <param name="missileHitHandler">投掷物碰撞处理方式</param>
    /// <param name="specialEffectHandler">特效创建</param>
    public void Init(Unit caster, ISkill skill, IMissileHitHandler missileHitHandler, ISpecialEffectHandler specialEffectHandler)
    {
        this.Caster = caster;
        this.Skill = skill;
        this.Damage = skill.Data.Damage;
        this.HP = skill.Data.MissileHP;
        this.missileHitHandler = missileHitHandler;
        this.specialEffectHandler = specialEffectHandler;
        ID = Gamef.MissileBirth(this);
        isInit = true;
    }
    /// <summary>
    /// 设置对每个被AOE伤害波及的单位和投掷物的处理方式。
    /// </summary>
    /// <param name="unitHandler"></param>
    /// <param name="missileHandler"></param>
    public void SetBlastHandler(BlastUnitHandler unitHandler, BlastMissileHandler missileHandler)
    {
        this.unitHandler = unitHandler;
        this.missileHandler = missileHandler;
    }

    float timer = 0f;
    private void Update()
    {
        if (!isInit)
            return;
        if (!IsAlive)
        {
            return;
        }

        timer += Time.deltaTime;
        if (timer >= Skill.Data.LifeSpan)
        {
            missileHitHandler.Fade(this);
            Death();
        }
    }

    private void FixedUpdate()
    {
        if (!isInit)
            return;
        Track();
        Move(Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isInit)
            return;
        if ((collidesWith.value & (0x1 << gameObject.layer)) != 0)
        {
            Rigidbody otherRig = other.attachedRigidbody;
            // 只有地形没有刚体
            GameObject otherObj = otherRig == null ? other.gameObject : otherRig.gameObject;
            switch (otherObj.layer)
            {
                case Layer.Unit:
                    if (otherObj != Caster.gameObject)
                    {
                        missileHitHandler.HitUnit(this, otherObj.GetComponent<Unit>());
                        if (!Skill.Data.IsAOE && otherRig != null)
                        {
                            physicalEffectHandler.CreateImpulse(Skill.Data, transform.position, transform.forward, otherRig);
                        }
                    }
                    break;
                case Layer.Missile:
                    missileHitHandler.HitMissile(this, otherObj.GetComponent<Missile>());
                    break;
                default:
                    missileHitHandler.HitTerrain(this);
                    if (!Skill.Data.IsAOE && otherRig != null)
                    {
                        physicalEffectHandler.CreateImpulse(Skill.Data, transform.position, transform.forward, otherRig);
                    }
                    break;
            }
        }
    }

    object mutex = new object();
    public void TakeDamage(float damage)
    {
        HP -= damage;
        if (HP <= 1e-5f)
        {
            lock (mutex)
            {
                if (IsAlive)
                {
                    Death();
                }
            }
        }
    }

    void Death()
    {
        IsAlive = false;
        specialEffectHandler.CreateDestroyEffect(Caster, this, deathEffect);
        Gamef.MissileClear(ID);
        Gamef.Destroy(gameObject);
    }

    void Track()
    {

    }
    void Move(float dt)
    {
        transform.Translate(Vector3.forward * Skill.Data.Speed * dt);
    }

    /// <summary>
    /// Enable后重置参数
    /// </summary>
    private void OnEnable()
    {
        if (isInit)
        {
            this.Caster = null;
            this.Skill = null;
            this.missileHitHandler = null;
            this.specialEffectHandler = null;
            ID = -1;
            isInit = false;
        }
    }

    #region AOE爆炸
    public enum BlastType
    {
        Inner, Middle, Outer,
    }

    public delegate void BlastUnitHandler(Unit unit, BlastType blastType);
    public delegate void BlastMissileHandler(Missile missile, BlastType blastType);
    protected BlastUnitHandler unitHandler;
    protected BlastMissileHandler missileHandler;

    public void Blast(Missile exception)
    {
        float dis, damage = Skill.Data.Damage;
        BlastType type;

        // 制造爆炸力（物理效果）
        physicalEffectHandler.CreateExplosiveForce(Skill.Data, transform.position);

        //对单位造成AOE伤害
        GameDB.unitPool.Traversal(delegate (Unit other)
        {
            if (!other.attributes.isAlive)
                return;
            dis = (other.transform.position - transform.position).magnitude;
            if (dis > Skill.Data.OuterBlastRadius)
            {
                //do nothing
            }
            else
            {
                if (dis > Skill.Data.MiddleBlastRadius)
                {
                    //外圈伤害
                    damage = Skill.Data.Damage * Skill.Data.OuterDamageCoefficient;
                    type = BlastType.Outer;
                }
                else
                {
                    if (dis > Skill.Data.InnerBlastRadius)
                    {
                        //中圈伤害
                        damage = Skill.Data.Damage * Skill.Data.MiddleDamageCoefficient;
                        type = BlastType.Middle;
                    }
                    else
                    {
                        //内圈伤害
                        damage = Skill.Data.Damage * Skill.Data.InnerDamageCoefficient;
                        type = BlastType.Inner;
                    }
                }
                Gamef.Damage(damage, DamageType.unset, Caster, other);
                unitHandler?.Invoke(other, type);
            }
        });

        //对投掷物造成AOE伤害
        GameDB.missilePool.Traversal(delegate (Missile other)
        {
            if (!other.IsAlive)
                return;
            //忽略碰撞到的投掷物
            if (other == exception)
            {
                missileHandler?.Invoke(other, BlastType.Inner);
                return;
            }
            if (other == this)
            {
                return;
            }
            dis = (other.transform.position - transform.position).magnitude;
            if (dis > Skill.Data.OuterBlastRadius)
            {
                //do nothing
            }
            else
            {
                if (dis > Skill.Data.MiddleBlastRadius)
                {
                    //外圈伤害
                    damage = Skill.Data.Damage * Skill.Data.OuterDamageCoefficient;
                    type = BlastType.Outer;
                }
                else
                {
                    if (dis > Skill.Data.InnerBlastRadius)
                    {
                        //中圈伤害
                        damage = Skill.Data.Damage * Skill.Data.MiddleDamageCoefficient;
                        type = BlastType.Middle;
                    }
                    else
                    {
                        //内圈伤害
                        damage = Skill.Data.Damage * Skill.Data.InnerDamageCoefficient;
                        type = BlastType.Inner;
                    }
                }
                other.TakeDamage(damage);
                missileHandler?.Invoke(other, type);
            }
        });
    }

    #endregion

}


#region Old Version
/// <summary>
/// 目前缺少再初始化过程。即不可以回收利用。
/// 
/// 目前想要重写该类，作为父类。
/// </summary>
//public class Missile : MonoBehaviour
//{
//    ISkill skill;
//    Unit caster;
//    IMissileHitHandler missileHitHandler;
//    public float hp;
//    bool isAlive = true;
//    public enum PhysicalEffectType
//    {
//        //作用力仅仅对目标起效
//        TargetOnly,
//        //有爆炸力
//        Explosion,
//        None,
//    }
//    [HideInInspector]
//    public bool IsReusable = false;
//    public float DisappearDelay = 0.1f;
//    public enum PrefabAttachmentType
//    {
//        AttachedToMissile,
//        AttachedToCaster,
//        None,
//    }
//    public GameObject[] OnDeathDisable;
//    public ParticleSystem[] onDeathStop;
//    [Header("Special Effect")]
//    public PrefabAttachmentType birthPrefabAttachmentType = PrefabAttachmentType.None;
//    public PrefabAttachmentType deathPrefabAttachmentType = PrefabAttachmentType.None;
//    public Transform birthEffectSpawnTransform;
//    public Transform deathEffectSpawnTransform;
//    public bool IsAlive
//    {
//        get { return isAlive; }
//    }
//    Transform target;
//    [HideInInspector]
//    public float damage;
//    [HideInInspector]
//    public int ID = -1;

//    public GameObject BirthPrefab;
//    public GameObject DeathPrefab;

//    [Header("Physical Effect")]
//    public LayerMask collidesWith = ~(1 << 10);
//    public PhysicalEffectType physicalEffectOnDeath = PhysicalEffectType.None;
//    public float explosionRadius = 1f;
//    public float force = 1f;

//    private bool isInit = false;
//    private readonly object initMutex = new object();
//    public void Init(Unit caster, ISkill skill, IMissileHitHandler missileHitHandler)
//    {
//        lock (initMutex)
//        {
//            if (isInit)
//            {
//                return;
//            }
//            isInit = true;
//        }
//        this.caster = caster;
//        this.skill = skill;
//        this.missileHitHandler = missileHitHandler;
//        hp = skill.Data.MissileHP;
//        damage = skill.Data.Damage;
//    }

//    private void Awake()
//    {
//        if (birthEffectSpawnTransform == null)
//            birthEffectSpawnTransform = transform;
//        if (deathEffectSpawnTransform == null)
//            deathEffectSpawnTransform = transform;
//        IsReusable = GetComponent<ReusablePrefab>() != null;
//        if (explosionRadius <= 0)
//            explosionRadius = 1e-5f;
//        if (force <= 0)
//            force = 1e-5f;
//    }

//    private void OnEnable()
//    {
//        isAlive = true;
//        timer = 0f;



//        if (gameObject.tag != "Missile")
//            gameObject.tag = "Missile";

//        SetEffectStatus(true);

//        Gamef.MissileBirth(this);
//        if (BirthPrefab != null)
//            switch (birthPrefabAttachmentType)
//            {
//                case PrefabAttachmentType.AttachedToCaster:
//                    if (skill != null && caster != null)
//                        Gamef.Instantiate(BirthPrefab, birthEffectSpawnTransform.position, birthEffectSpawnTransform.rotation, caster.gameObject.transform);
//                    else
//                        Gamef.Instantiate(BirthPrefab, birthEffectSpawnTransform.position, birthEffectSpawnTransform.rotation);
//                    break;
//                case PrefabAttachmentType.AttachedToMissile:
//                    Gamef.Instantiate(BirthPrefab, birthEffectSpawnTransform.position, birthEffectSpawnTransform.rotation, transform);
//                    break;
//                default:
//                    Gamef.Instantiate(BirthPrefab, birthEffectSpawnTransform.position, birthEffectSpawnTransform.rotation);
//                    break;
//            }
//    }

//    float timer = 0f;
//    private void Update()
//    {
//        if (!isInit)
//            return;
//        if (!isAlive)
//            return;
//        timer += Time.deltaTime;
//        if (timer > skill.Data.LifeSpan)
//        {
//            missileHitHandler.Fade(this);
//            TakeDamage(1e7f);
//        }
//        //if (target != null)
//        //    switch (skill.data.TrackingType)
//        //    {
//        //        case TrackingType.NoTracking:
//        //            break;
//        //        case TrackingType.StrongTracking:
//        //            break;
//        //        case TrackingType.WeakTracking:
//        //            break;
//        //    }
//    }

//    private void FixedUpdate()
//    {
//        if (!isInit)
//            return;
//        if (isAlive)
//            transform.Translate(skill.Data.Speed * Vector3.forward * Time.fixedDeltaTime);
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (!isInit)
//            return;
//        if ((collidesWith.value & other.gameObject.layer) == 0)
//            CollisionHandler(other);
//        else
//        {
//            Debug.Log(string.Format("{0} cannot collide with layer {1}", gameObject.name, other.gameObject.layer));
//        }
//    }

//    Collider lastHitCollider = null;
//    public void CollisionHandler(Collider other)
//    {
//        ColliderAttachedMissileOrUnit missileOrUnit = GetComponent<ColliderAttachedMissileOrUnit>();
//        //如果已经特殊指定了UnitCtrl或者Missile组件
//        if (missileOrUnit != null)
//        {
//            if (missileOrUnit.isMissile)
//            {
//                Missile otherMissile = missileOrUnit.missile;
//                if (otherMissile == null)
//                    Debug.Log("Cannot Find Missile Component");
//                if (otherMissile.gameObject == caster.gameObject)
//                    return;
//                lastHitCollider = other;
//                missileHitHandler.HitMissile(this, otherMissile);
//            }
//            else
//            {
//                Unit otherUnit = missileOrUnit.unit;
//                if (otherUnit == null)
//                    Debug.Log("Cannot Find UnitCtrl Component");
//                if (otherUnit.gameObject == caster.gameObject)
//                    return;
//                lastHitCollider = other;
//                missileHitHandler.HitUnit(this, otherUnit);
//            }
//        }
//        //否则按常规处理
//        else
//        {
//            GameObject obj = other.attachedRigidbody != null ? other.attachedRigidbody.gameObject : other.gameObject;
//            //忽略施法者本身
//            if (obj == caster.gameObject)
//                return;
//            lastHitCollider = other;
//            Debug.Log(gameObject.name + " hits " + obj.name);
//            switch (obj.tag)
//            {
//                case "IgnoreMissile":
//                    break;
//                //撞到单位（或玩家）
//                case "Player":
//                case "Unit":
//                    Unit otherUnit = obj.GetComponent<Unit>();
//                    if (otherUnit == null)
//                        Debug.Log("Cannot Find UnitCtrl Component");
//                    missileHitHandler.HitUnit(this, otherUnit);
//                    break;
//                //撞到其他投掷物
//                case "Missile":
//                    Missile otherMissile = obj.GetComponent<Missile>();
//                    if (otherMissile == null)
//                        Debug.Log("Cannot Find Missile Component");
//                    missileHitHandler.HitMissile(this, otherMissile);
//                    break;
//                //撞到其他物体（地形）
//                default:
//                    missileHitHandler.HitTerrain(this);
//                    break;
//            }
//        }
//    }

//    private void OnDisable()
//    {
//        Gamef.MissileClear(ID);
//    }


//    public void TakeDamage(float damage)
//    {
//        if (!isInit)
//            return;
//        if (!isAlive)
//            return;
//        hp -= damage;
//        if (hp <= 0)
//        {
//            SetEffectStatus(false);
//            isAlive = false;
//            if (DisappearDelay < 1e-5f)
//                Gamef.Destroy(gameObject);
//            else
//                StartCoroutine(Destroy());

//            //物理效果
//            if (physicalEffectOnDeath == PhysicalEffectType.Explosion)
//            {
//                Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);
//                Rigidbody rb;
//                foreach (Collider hit in hits)
//                {
//                    rb = hit.attachedRigidbody;
//                    if (rb != null)
//                    {
//                        rb.AddExplosionForce(force, transform.position, explosionRadius, 0f, ForceMode.Impulse);
//                    }
//                }
//            }
//            else if (physicalEffectOnDeath == PhysicalEffectType.TargetOnly)
//            {
//                if (lastHitCollider != null && lastHitCollider.attachedRigidbody != null)
//                    lastHitCollider.attachedRigidbody.AddForceAtPosition(force * transform.forward, transform.position, ForceMode.Impulse);
//            }
//            //特效
//            if (DeathPrefab != null)
//                switch (deathPrefabAttachmentType)
//                {
//                    case PrefabAttachmentType.AttachedToCaster:
//                        if (skill != null && caster != null)
//                            Gamef.Instantiate(DeathPrefab, deathEffectSpawnTransform.position, deathEffectSpawnTransform.rotation, caster.gameObject.transform);
//                        else
//                            Gamef.Instantiate(DeathPrefab, deathEffectSpawnTransform.position, deathEffectSpawnTransform.rotation);
//                        break;
//                    case PrefabAttachmentType.AttachedToMissile:
//                        Gamef.Instantiate(DeathPrefab, deathEffectSpawnTransform.position, deathEffectSpawnTransform.rotation, transform);
//                        break;
//                    default:
//                        Gamef.Instantiate(DeathPrefab, deathEffectSpawnTransform.position, deathEffectSpawnTransform.rotation);
//                        break;
//                }



//            missileHitHandler.Fade(this);
//        }
//    }

//    void SetEffectStatus(bool value)
//    {
//        foreach (GameObject obj in OnDeathDisable)
//        {
//            if (obj != null)
//            {
//                if (obj.activeSelf ^ value)
//                    obj.SetActive(value);
//            }
//        }
//        foreach (ParticleSystem ps in onDeathStop)
//        {
//            if (ps != null)
//            {
//                if (!ps.isStopped ^ value)
//                {
//                    if (value)
//                        ps.Play();
//                    else ps.Stop();
//                }
//            }
//        }
//    }

//    IEnumerator Destroy()
//    {
//        yield return new WaitForSeconds(DisappearDelay);
//        Gamef.Destroy(gameObject);
//    }
//}
#endregion
