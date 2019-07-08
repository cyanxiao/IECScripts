using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 目前缺少初始化过程。
/// </summary>
public class Missile : MonoBehaviour
{
    ISkill skill;
    Unit caster;
    IMissileHitHandler skillEffectBase;
    public float hp;
    bool isAlive = true;
    public enum PhysicalEffectType
    {
        //作用力仅仅对目标起效
        TargetOnly,
        //有爆炸力
        Explosion,
        None,
    }
    [HideInInspector]
    public bool IsReusable = false;
    public float DisappearDelay = 0.1f;
    public enum PrefabAttachmentType
    {
        AttachedToMissile,
        AttachedToCaster,
        None,
    }
    public GameObject[] OnDeathDisable;
    public ParticleSystem[] onDeathStop;
    [Header("Special Effect")]
    public PrefabAttachmentType birthPrefabAttachmentType = PrefabAttachmentType.None;
    public PrefabAttachmentType deathPrefabAttachmentType = PrefabAttachmentType.None;
    public Transform birthEffectSpawnTransform;
    public Transform deathEffectSpawnTransform;
    public bool IsAlive
    {
        get { return isAlive; }
    }
    Transform target;
    [HideInInspector]
    public float damage;
    [HideInInspector]
    public int ID = -1;

    public GameObject BirthPrefab;
    public GameObject DeathPrefab;

    [Header("Physical Effect")]
    public LayerMask collidesWith = ~(1 << 10);
    public PhysicalEffectType physicalEffectOnDeath = PhysicalEffectType.None;
    public float explosionRadius = 1f;
    public float force = 1f;

    private void Awake()
    {
        if (birthEffectSpawnTransform == null)
            birthEffectSpawnTransform = transform;
        if (deathEffectSpawnTransform == null)
            deathEffectSpawnTransform = transform;
        IsReusable = GetComponent<ReusablePrefab>() != null;
        if (explosionRadius <= 0)
            explosionRadius = 1e-5f;
        if (force <= 0)
            force = 1e-5f;
    }

    private void OnEnable()
    {
        isAlive = true;
        timer = 0f;


        hp = skill.Data.MissileHP;
        damage = skill.Data.Damage;
        if (gameObject.tag != "Missile")
            gameObject.tag = "Missile";

        SetEffectStatus(true);

        Gamef.MissileBirth(this);
        if (BirthPrefab != null)
            switch (birthPrefabAttachmentType)
            {
                case PrefabAttachmentType.AttachedToCaster:
                    if (skill != null && caster != null)
                        Gamef.Instantiate(BirthPrefab, birthEffectSpawnTransform.position, birthEffectSpawnTransform.rotation, caster.gameObject.transform);
                    else
                        Gamef.Instantiate(BirthPrefab, birthEffectSpawnTransform.position, birthEffectSpawnTransform.rotation);
                    break;
                case PrefabAttachmentType.AttachedToMissile:
                    Gamef.Instantiate(BirthPrefab, birthEffectSpawnTransform.position, birthEffectSpawnTransform.rotation, transform);
                    break;
                default:
                    Gamef.Instantiate(BirthPrefab, birthEffectSpawnTransform.position, birthEffectSpawnTransform.rotation);
                    break;
            }
    }

    float timer = 0f;
    private void Update()
    {
        if (!isAlive)
            return;
        timer += Time.deltaTime;
        if (timer > skill.Data.LifeSpan)
        {
            skillEffectBase.Fade(this);
            TakeDamage(1e7f);
        }
        //if (target != null)
        //    switch (skill.data.TrackingType)
        //    {
        //        case TrackingType.NoTracking:
        //            break;
        //        case TrackingType.StrongTracking:
        //            break;
        //        case TrackingType.WeakTracking:
        //            break;
        //    }
    }

    private void FixedUpdate()
    {
        if (isAlive)
            transform.Translate(skill.Data.Speed * Vector3.forward * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((collidesWith.value & other.gameObject.layer) == 0)
            CollisionHandler(other);
        else
        {
            Debug.Log(string.Format("{0} cannot collide with layer {1}", gameObject.name, other.gameObject.layer));
        }
    }

    Collider lastHitCollider = null;
    public void CollisionHandler(Collider other)
    {
        ColliderAttachedMissileOrUnit missileOrUnit = GetComponent<ColliderAttachedMissileOrUnit>();
        //如果已经特殊指定了UnitCtrl或者Missile组件
        if (missileOrUnit != null)
        {
            if (missileOrUnit.isMissile)
            {
                Missile otherMissile = missileOrUnit.missile;
                if (otherMissile == null)
                    Debug.Log("Cannot Find Missile Component");
                if (otherMissile.gameObject == caster.gameObject)
                    return;
                lastHitCollider = other;
                skillEffectBase.HitMissile(this, otherMissile);
            }
            else
            {
                Unit otherUnit = missileOrUnit.unit;
                if (otherUnit == null)
                    Debug.Log("Cannot Find UnitCtrl Component");
                if (otherUnit.gameObject == caster.gameObject)
                    return;
                lastHitCollider = other;
                skillEffectBase.HitUnit(this, otherUnit);
            }
        }
        //否则按常规处理
        else
        {
            GameObject obj = other.attachedRigidbody != null ? other.attachedRigidbody.gameObject : other.gameObject;
            //忽略施法者本身
            if (obj == caster.gameObject)
                return;
            lastHitCollider = other;
            Debug.Log(gameObject.name + " hits " + obj.name);
            switch (obj.tag)
            {
                case "IgnoreMissile":
                    break;
                //撞到单位（或玩家）
                case "Player":
                case "Unit":
                    Unit otherUnit = obj.GetComponent<Unit>();
                    if (otherUnit == null)
                        Debug.Log("Cannot Find UnitCtrl Component");
                    skillEffectBase.HitUnit(this, otherUnit);
                    break;
                //撞到其他投掷物
                case "Missile":
                    Missile otherMissile = obj.GetComponent<Missile>();
                    if (otherMissile == null)
                        Debug.Log("Cannot Find Missile Component");
                    skillEffectBase.HitMissile(this, otherMissile);
                    break;
                //撞到其他物体（地形）
                default:
                    skillEffectBase.HitTerrain(this);
                    break;
            }
        }
    }

    private void OnDisable()
    {
        Gamef.MissileClear(ID);
    }


    public void TakeDamage(float damage)
    {
        if (!isAlive)
            return;
        hp -= damage;
        if (hp <= 0)
        {
            SetEffectStatus(false);
            isAlive = false;
            if (DisappearDelay < 1e-5f)
                Gamef.Destroy(gameObject);
            else
                StartCoroutine(Destroy());

            //物理效果
            if (physicalEffectOnDeath == PhysicalEffectType.Explosion)
            {
                Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);
                Rigidbody rb;
                foreach (Collider hit in hits)
                {
                    rb = hit.attachedRigidbody;
                    if (rb != null)
                    {
                        rb.AddExplosionForce(force, transform.position, explosionRadius, 0f, ForceMode.Impulse);
                    }
                }
            }
            else if (physicalEffectOnDeath == PhysicalEffectType.TargetOnly)
            {
                if (lastHitCollider != null && lastHitCollider.attachedRigidbody != null)
                    lastHitCollider.attachedRigidbody.AddForceAtPosition(force * transform.forward, transform.position, ForceMode.Impulse);
            }
            //特效
            if (DeathPrefab != null)
                switch (deathPrefabAttachmentType)
                {
                    case PrefabAttachmentType.AttachedToCaster:
                        if (skill != null && caster != null)
                            Gamef.Instantiate(DeathPrefab, deathEffectSpawnTransform.position, deathEffectSpawnTransform.rotation, caster.gameObject.transform);
                        else
                            Gamef.Instantiate(DeathPrefab, deathEffectSpawnTransform.position, deathEffectSpawnTransform.rotation);
                        break;
                    case PrefabAttachmentType.AttachedToMissile:
                        Gamef.Instantiate(DeathPrefab, deathEffectSpawnTransform.position, deathEffectSpawnTransform.rotation, transform);
                        break;
                    default:
                        Gamef.Instantiate(DeathPrefab, deathEffectSpawnTransform.position, deathEffectSpawnTransform.rotation);
                        break;
                }



            skillEffectBase.Fade(this);
        }
    }

    void SetEffectStatus(bool value)
    {
        foreach (GameObject obj in OnDeathDisable)
        {
            if (obj != null)
            {
                if (obj.activeSelf ^ value)
                    obj.SetActive(value);
            }
        }
        foreach (ParticleSystem ps in onDeathStop)
        {
            if (ps != null)
            {
                if (!ps.isStopped ^ value)
                {
                    if (value)
                        ps.Play();
                    else ps.Stop();
                }
            }
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(DisappearDelay);
        Gamef.Destroy(gameObject);
    }
}
