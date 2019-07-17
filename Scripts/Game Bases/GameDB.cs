using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameDB
{
    #region 单例 & 自启动
    private static GameDB _instance = new GameDB();
    public static GameDB Instance
    {
        get
        {
            return _instance = _instance ?? new GameDB();
        }
    }

    private GameDB()
    {
        Init();
    }

    private void Init()
    {
        funcCurvePath = Resources.Load<DataPathIndex>("Curve/A_DataPath");
        unitDataPath = Resources.Load<DataPathIndex>("Unit/A_DataPath");
        skillDataPath = Resources.Load<DataPathIndex>("Skill/A_DataPath");
        buffDataPath = Resources.Load<DataPathIndex>("Buff/A_DataPath");
        prefabPath = Resources.Load<DataPathIndex>("A_DataPath");
    }
    #endregion

    #region 基础信息

    #region 游戏参数
    //最大速度加成上下限
    public const float MAX_BONUS_FOR_MAX_V = 1e7f;
    public const float MIN_BONUS_FOR_MAX_V = -1;
    //最大护盾值加成上下限
    public const float MAX_BONUS_FOR_MAX_SP = 1e7f;
    public const float MIN_BONUS_FOR_MAX_SP = -1;
    //最大转向速度加成上下限
    public const float MAX_BONUS_FOR_MAX_TURNING_V = 1e7f;
    public const float MIN_BONUS_FOR_MAX_TURNING_V = -1;
    //最大护盾值
    public const int MAX_SHEILD_POINT = (int)1e8;
    //最大魔法值
    public const float MAX_MANA_POINT = 1e7f;
    //最大速度
    public const int MAX_SPEED = (int)1e7;
    //最大转向速度
    public const float MAX_TURNING_V = (int)1e7;
    //拉升速度与最大转向速度比值
    public const float PULL_UP_CONST = 0.5f;
    public const float X_AXIS_BALANCING_CONST = 0.5f;
    //最大俯仰角
    public const float MAX_ROT_X = 75f;
    //最大俯仰角的倒数
    public const float RECIPROCAL_MAX_ROT_X = 1 / MAX_ROT_X;
    /// <summary>
    /// 单位移动阻尼
    /// </summary>
    public const float DAMPED_CONST = 2;
    /// <summary>
    /// 单位转向阻尼
    /// </summary>
    public const float ANGULAR_DAMPED_CONST = 3;
    /// <summary>
    /// 最大技能数量
    /// </summary>
    public const int MAX_SKILL_INDEX = 10;
    /// <summary>
    /// 最大瞄准角度
    /// </summary>
    public const float MAX_AIMING_ANGLE = 5f;
    /// <summary>
    /// 初始精确度相对于 Skill 精确度的比例
    /// </summary>
    public const float INITIAL_ACCURACY = 0.75f;

    /// <summary>
    /// 最小精确度加成。如果点射型技能未经过瞄准直接开火，其精确度加成即为该值。
    /// </summary>
    public const float MIN_ACCURACY_BONUS = -0.5f;
    /// <summary>
    /// 最大精确度加成。如果点射型技能经过足够长时间的瞄准，其精确度最大加成即为该值。
    /// </summary>
    public const float MAX_ACCURACY_BONUS = 1f;
    #endregion

    #region 单位字典
    /// <summary>
    /// 单位池，记录所有单位信息
    /// </summary>
    public static ObjectPool<Unit> unitPool = new ObjectPool<Unit>();
    /// <summary>
    /// 投掷物池，记录所有投掷物信息
    /// </summary>
    public static ObjectPool<Missile> missilePool = new ObjectPool<Missile>();

    /// <summary>
    /// 将单位加入单位池(请勿调用，该方法不会触发单位出生事件，请使用Gamef.UnitBirth()方法)
    /// </summary>
    /// <param name="unit">单位控制组件</param>
    /// <returns>单位ID。如果出生失败，返回-1</returns>
    public int UnitBirth(Unit unit)
    {
        //如果单位已经设置过了，那么不执行
        if (unit.attributes.ID != -1)
            return -1;
        return unitPool.IDAlloc(unit);
    }
    /// <summary>
    /// 将投掷物加入池（请调用Gamef.MissileBirth）
    /// </summary>
    /// <param name="missile">投掷物</param>
    public int MissileBirth(Missile missile)
    {
        if (missile.ID != -1)
            return missile.ID;
        return missilePool.IDAlloc(missile);
    }
    /// <summary>
    /// 将投掷物清除（请调用Gamef.MissileClear）
    /// </summary>
    /// <param name="id">投掷物ID</param>
    public void MissileClear(int id)
    {
        missilePool.RemoveObject(id);
    }

    /// <summary>
    /// 将单位移除单位字典(请勿调用，该方法不会触发单位清除事件，请使用Gamef.UnitClear()方法)
    /// </summary>
    /// <param name="unitID">单位ID</param>
    public void UnitClear(int unitID)
    {
        unitPool.RemoveObject(unitID);
    }

    /// <summary>
    /// 通过ID获得单位信息
    /// </summary>
    /// <param name="unitID">单位ID</param>
    /// <returns>单位信息</returns>
    public Unit GetUnit(int unitID)
    {
        return unitPool.GetObject(unitID);
    }
    #endregion

    #region 场景序号
    /// <summary>
    /// 游戏中的各场景的序号
    /// </summary>
    public static class MyScene
    {
        public readonly static int LoadingScene = 0;
        public readonly static int GameScene = 1;
    }
    #endregion

    #region 预制Prefabs
    private GameObject _emptyObject;
    /// <summary>
    /// 空物体（仅有Transform组件）
    /// </summary>
    public GameObject EmptyObject
    {
        get
        {
            return _emptyObject = _emptyObject ?? Resources.Load<GameObject>("EmptyObject");
        }
    }
    private GameObject _bullet;
    public GameObject Bullet
    {
        get
        {
            return _bullet = _bullet ?? Resources.Load<GameObject>("Bullet");
        }
    }
    #endregion

    #region 曲线
    public static AnimationCurve[] curves = new AnimationCurve[10];
    public static AnimationCurve AtanCurve
    {
        get { return curves[(int)FuncCurveName.Arctan]; }
    }
    public static AnimationCurve SinCurve;
    private class Signal
    {
        public bool isBuild = false;
    }
    Signal signal = new Signal();

    public void BuildCurve()
    {
        lock (signal)
        {
            if (signal.isBuild)
            {
                // do nothing
            }
            else
            {
                BuildAtanCurve();
                BuildSinCurve();
                signal.isBuild = true;
            }
        }
    }

    private void BuildAtanCurve()
    {
        float tmp;
        Keyframe[] keyframes = new Keyframe[80];
        int cnt = 0;
        // 0 to 1 by 0.05
        for (int i = 0; i < 20; i++)
        {
            tmp = i * 0.05f;
            keyframes[cnt++] = new Keyframe(tmp, Mathf.Atan(tmp) * Mathf.Rad2Deg)
            {
                tangentMode = 1,
            };
        }
        // 1.1 to 3 by 0.1
        for (int i = 0; i < 20; i++)
        {
            tmp = 1.1f + i * 0.1f;
            keyframes[cnt++] = new Keyframe(tmp, Mathf.Atan(tmp) * Mathf.Rad2Deg)
            {
                tangentMode = 1,
            };
        }
        // 3.5 to 13 by 0.5
        for (int i = 0; i < 20; i++)
        {
            tmp = 3.5f + i * 0.5f;
            keyframes[cnt++] = new Keyframe(tmp, Mathf.Atan(tmp) * Mathf.Rad2Deg)
            {
                tangentMode = 1,
            };
        }
        // 14 to 24 by 1
        for (int i = 0; i < 10; i++)
        {
            tmp = 14f + i;
            keyframes[cnt++] = new Keyframe(tmp, Mathf.Atan(tmp) * Mathf.Rad2Deg)
            {
                tangentMode = 1,
            };
        }
        // 25 to ? by 10 i * i
        for (int i = 0; i < 10; i++)
        {
            tmp = 25f + 10f * i * i;
            keyframes[cnt++] = new Keyframe(tmp, Mathf.Atan(tmp) * Mathf.Rad2Deg)
            {
                tangentMode = 1,
            };
        }

        curves[(int)FuncCurveName.Arctan] = Resources.Load<FunctionCurve>(funcCurvePath.paths[(int)FuncCurveName.Arctan]).Curve = new AnimationCurve(keyframes);
    }

    private void BuildSinCurve()
    {
        Keyframe[] keyframes = new Keyframe[81];
        float tmp;
        for (int i = 0; i <= 80; i++)
        {
            tmp = 180f * (i * 0.025f - 0.5f);
            keyframes[i] = new Keyframe(tmp, Mathf.Sin(tmp * Mathf.Deg2Rad));
        }
        SinCurve = new AnimationCurve(keyframes)
        {
            postWrapMode = WrapMode.Loop,
            preWrapMode = WrapMode.Loop
        };
    }
    #endregion
    //函数曲线索引
    public DataPathIndex funcCurvePath;
    //单位数据索引
    public DataPathIndex unitDataPath;
    //技能数据索引
    public DataPathIndex skillDataPath;

    public DataPathIndex buffDataPath;

    public DataPathIndex prefabPath;

    public class SkillBuffer
    {
        //public Skill skill;
        //public SkillMgr.SkillEffectBase skillEffectBase;
    }
    public static SkillBuffer skillBuffer = new SkillBuffer();
    #endregion
}
