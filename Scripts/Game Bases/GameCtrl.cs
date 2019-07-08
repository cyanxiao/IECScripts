using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class GameCtrl : MonoBehaviour
{
    #region 单例
    /// <summary>
    /// 游戏控制器单例
    /// </summary>
    public static GameCtrl Instance { get; private set; }
    /// <summary>
    /// 游戏控制组件是否初始化完成。在Controller的Start执行后为真。
    /// </summary>
    public static bool isInit = false;
    #endregion

    #region 实时公有信息
    //private UnitInfo _mainChara;
    public static Unit PlayerUnit;
    public Unit PlayerChara
    {
        get
        {
            return PlayerUnit;
        }
        set
        {
            PlayerUnit = value;
        }
    }

    public Transform PlayerCamera
    {
        get; set;
    }
    #endregion

    public bool BuildDataPath = false;

    #region 生命周期
    private void Awake()
    {
        Instance = this;
        EventMgr.initEvent.OnAwake();
        EventMgr.UpdateEvent.AddListener(InputMgr.CheckHotKey);
        //InputMgr.BindHotKey(TestHotKey, KeyCode.F);
        //InputMgr.BindHotKey(TestCasting, KeyCode.T);

        //BindHotKey4Skill();
    }

    private void Start()
    {
        EventMgr.initEvent.OnStart();
        DontDestroyOnLoad(gameObject);
        GameObjectCache.Init();
        isInit = true;//初始化完毕

        if (BuildDataPath)
        {
            string[] paths = GameDB.Instance.unitDataPath.paths = new string[(int)UnitName.MaxIndex];
            for (int i = 0; i < paths.Length; i++)
            {
                paths[i] = "Unit/" + ((UnitName)i).ToString() + "Data";
            }
            paths = GameDB.Instance.skillDataPath.paths = new string[GameDB.MAX_SKILL_INDEX];
            foreach (SkillName name in Enum.GetValues(typeof(SkillName)))
            {
                int i = (int)name;
                paths[i] = "Skill/" + name + "Data";
            }
        }

        //加载游戏场景
        SceneManager.LoadSceneAsync(GameDB.MyScene.GameScene);
    }

    private void Update()
    {
        CheckInputForSkillTable();

        EventMgr.UpdateEvent.OnTrigger();
    }

    #endregion

}

/// <summary>
/// 单位的全面信息
/// </summary>
public class UnitInfo
{
    public Unit UnitCtrl { get; private set; }
    public GameObject Obj { get; private set; }
    public Transform Transform { get; private set; }
    /// <summary>
    /// 构造单位全面信息
    /// </summary>
    /// <param name="unitCtrl">单位控制组件</param>
    public UnitInfo(Unit unitCtrl)
    {
        UnitCtrl = unitCtrl;
        Obj = unitCtrl.gameObject;
        Transform = Obj.transform;
    }
}

/// <summary>
/// 护甲类型
/// </summary>
public enum ArmorType
{
    //无敌的
    invincible = 0,
    //

    //

    //
}

/// <summary>
/// 伤害类型
/// </summary>
public enum DamageType
{
    unset,
}