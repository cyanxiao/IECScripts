using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class TestSkillTree : MonoBehaviour {

//	// Use this for initialization
//	void Start () {
		
//	}
	
//	// Update is called once per frame
//	void Update () {
		
//	}
//}

//#region

//public class TestSkill1Mgr : SkillMgr
//{
//    protected TestSkill1Mgr() : base(SkillName.TestSkill1)
//    {
//    }

//    public static TestSkill1Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill1Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill1>(skill);
//    }

//    public class TestSkill1 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill1(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill1");
//        }
//    }
//}

//public class TestSkill2Mgr : SkillMgr
//{
//    protected TestSkill2Mgr() : base(SkillName.TestSkill2)
//    {
//    }

//    public static TestSkill2Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill2Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill2>(skill);
//    }

//    public class TestSkill2 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill2(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill2");
//        }
//    }
//}

//public class TestSkill3Mgr : SkillMgr
//{
//    protected TestSkill3Mgr() : base(SkillName.TestSkill3)
//    {
//    }

//    public static TestSkill3Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill3Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill3>(skill);
//    }

//    public class TestSkill3 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill3(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill3");
//        }
//    }
//}

//public class TestSkill4Mgr : SkillMgr
//{
//    protected TestSkill4Mgr() : base(SkillName.TestSkill4)
//    {
//    }

//    public static TestSkill4Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill4Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill4>(skill);
//    }

//    public class TestSkill4 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill4(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill4");
//        }
//    }
//}

//public class TestSkill5Mgr : SkillMgr
//{
//    protected TestSkill5Mgr() : base(SkillName.TestSkill5)
//    {
//    }

//    public static TestSkill5Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill5Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill5>(skill);
//    }

//    public class TestSkill5 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill5(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill5");
//        }
//    }
//}

//public class TestSkill6Mgr : SkillMgr
//{
//    protected TestSkill6Mgr() : base(SkillName.TestSkill6)
//    {
//    }

//    public static TestSkill6Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill6Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill6>(skill);
//    }

//    public class TestSkill6 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill6(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill6");
//        }
//    }
//}

//public class TestSkill7Mgr : SkillMgr
//{
//    protected TestSkill7Mgr() : base(SkillName.TestSkill7)
//    {
//    }

//    public static TestSkill7Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill7Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill7>(skill);
//    }

//    public class TestSkill7 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill7(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill7");
//        }
//    }
//}

//public class TestSkill8Mgr : SkillMgr
//{
//    protected TestSkill8Mgr() : base(SkillName.TestSkill8)
//    {
//    }

//    public static TestSkill8Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill8Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill8>(skill);
//    }

//    public class TestSkill8 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill8(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill8");
//        }
//    }
//}

//public class TestSkill9Mgr : SkillMgr
//{
//    protected TestSkill9Mgr() : base(SkillName.TestSkill9)
//    {
//    }

//    public static TestSkill9Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill9Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill9>(skill);
//    }

//    public class TestSkill9 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill9(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill9");
//        }
//    }
//}

//public class TestSkill10Mgr : SkillMgr
//{
//    protected TestSkill10Mgr() : base(SkillName.TestSkill10)
//    {
//    }

//    public static TestSkill10Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill10Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill10>(skill);
//    }

//    public class TestSkill10 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill10(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill10");
//        }
//    }
//}

//public class TestSkill11Mgr : SkillMgr
//{
//    protected TestSkill11Mgr() : base(SkillName.TestSkill11)
//    {
//    }

//    public static TestSkill11Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill11Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill11>(skill);
//    }

//    public class TestSkill11 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill11(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill11");
//        }
//    }
//}

//public class TestSkill12Mgr : SkillMgr
//{
//    protected TestSkill12Mgr() : base(SkillName.TestSkill12)
//    {
//    }

//    public static TestSkill12Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill12Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill12>(skill);
//    }

//    public class TestSkill12 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill12(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill12");
//        }
//    }
//}

//public class TestSkill13Mgr : SkillMgr
//{
//    protected TestSkill13Mgr() : base(SkillName.TestSkill13)
//    {
//    }

//    public static TestSkill13Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill13Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill13>(skill);
//    }

//    public class TestSkill13 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill13(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill13");
//        }
//    }
//}

//public class TestSkill14Mgr : SkillMgr
//{
//    protected TestSkill14Mgr() : base(SkillName.TestSkill14)
//    {
//    }

//    public static TestSkill14Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill14Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill14>(skill);
//    }

//    public class TestSkill14 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill14(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill14");
//        }
//    }
//}

//public class TestSkill15Mgr : SkillMgr
//{
//    protected TestSkill15Mgr() : base(SkillName.TestSkill15)
//    {
//    }

//    public static TestSkill15Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill15Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill15>(skill);
//    }

//    public class TestSkill15 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill15(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill15");
//        }
//    }
//}

//public class TestSkill16Mgr : SkillMgr
//{
//    protected TestSkill16Mgr() : base(SkillName.TestSkill16)
//    {
//    }

//    public static TestSkill16Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill16Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill16>(skill);
//    }

//    public class TestSkill16 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill16(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill16");
//        }
//    }
//}

//public class TestSkill17Mgr : SkillMgr
//{
//    protected TestSkill17Mgr() : base(SkillName.TestSkill17)
//    {
//    }

//    public static TestSkill17Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill17Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill17>(skill);
//    }

//    public class TestSkill17 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill17(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill17");
//        }
//    }
//}

//public class TestSkill18Mgr : SkillMgr
//{
//    protected TestSkill18Mgr() : base(SkillName.TestSkill18)
//    {
//    }

//    public static TestSkill18Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill18Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill18>(skill);
//    }

//    public class TestSkill18 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill18(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill18");
//        }
//    }
//}

//public class TestSkill19Mgr : SkillMgr
//{
//    protected TestSkill19Mgr() : base(SkillName.TestSkill19)
//    {
//    }

//    public static TestSkill19Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill19Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill19>(skill);
//    }

//    public class TestSkill19 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill19(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill19");
//        }
//    }
//}

//public class TestSkill20Mgr : SkillMgr
//{
//    protected TestSkill20Mgr() : base(SkillName.TestSkill20)
//    {
//    }

//    public static TestSkill20Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill20Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill20>(skill);
//    }

//    public class TestSkill20 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill20(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill20");
//        }
//    }
//}

//public class TestSkill21Mgr : SkillMgr
//{
//    protected TestSkill21Mgr() : base(SkillName.TestSkill21)
//    {
//    }

//    public static TestSkill21Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill21Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill21>(skill);
//    }

//    public class TestSkill21 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill21(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill21");
//        }
//    }
//}

//public class TestSkill22Mgr : SkillMgr
//{
//    protected TestSkill22Mgr() : base(SkillName.TestSkill22)
//    {
//    }

//    public static TestSkill22Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill22Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill22>(skill);
//    }

//    public class TestSkill22 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill22(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill22");
//        }
//    }
//}

//public class TestSkill23Mgr : SkillMgr
//{
//    protected TestSkill23Mgr() : base(SkillName.TestSkill23)
//    {
//    }

//    public static TestSkill23Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill23Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill23>(skill);
//    }

//    public class TestSkill23 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill23(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill23");
//        }
//    }
//}

//public class TestSkill24Mgr : SkillMgr
//{
//    protected TestSkill24Mgr() : base(SkillName.TestSkill24)
//    {
//    }

//    public static TestSkill24Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill24Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill24>(skill);
//    }

//    public class TestSkill24 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill24(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill24");
//        }
//    }
//}

//public class TestSkill25Mgr : SkillMgr
//{
//    protected TestSkill25Mgr() : base(SkillName.TestSkill25)
//    {
//    }

//    public static TestSkill25Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill25Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill25>(skill);
//    }

//    public class TestSkill25 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill25(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill25");
//        }
//    }
//}

//public class TestSkill26Mgr : SkillMgr
//{
//    protected TestSkill26Mgr() : base(SkillName.TestSkill26)
//    {
//    }

//    public static TestSkill26Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill26Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill26>(skill);
//    }

//    public class TestSkill26 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill26(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill26");
//        }
//    }
//}

//public class TestSkill27Mgr : SkillMgr
//{
//    protected TestSkill27Mgr() : base(SkillName.TestSkill27)
//    {
//    }

//    public static TestSkill27Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill27Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill27>(skill);
//    }

//    public class TestSkill27 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill27(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill27");
//        }
//    }
//}

//public class TestSkill28Mgr : SkillMgr
//{
//    protected TestSkill28Mgr() : base(SkillName.TestSkill28)
//    {
//    }

//    public static TestSkill28Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill28Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill28>(skill);
//    }

//    public class TestSkill28 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill28(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill28");
//        }
//    }
//}

//public class TestSkill29Mgr : SkillMgr
//{
//    protected TestSkill29Mgr() : base(SkillName.TestSkill29)
//    {
//    }

//    public static TestSkill29Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill29Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill29>(skill);
//    }

//    public class TestSkill29 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill29(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill29");
//        }
//    }
//}

//public class TestSkill30Mgr : SkillMgr
//{
//    protected TestSkill30Mgr() : base(SkillName.TestSkill30)
//    {
//    }

//    public static TestSkill30Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill30Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill30>(skill);
//    }

//    public class TestSkill30 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill30(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill30");
//        }
//    }
//}

//public class TestSkill31Mgr : SkillMgr
//{
//    protected TestSkill31Mgr() : base(SkillName.TestSkill31)
//    {
//    }

//    public static TestSkill31Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill31Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill31>(skill);
//    }

//    public class TestSkill31 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill31(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill31");
//        }
//    }
//}

//public class TestSkill32Mgr : SkillMgr
//{
//    protected TestSkill32Mgr() : base(SkillName.TestSkill32)
//    {
//    }

//    public static TestSkill32Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill32Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill32>(skill);
//    }

//    public class TestSkill32 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill32(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill32");
//        }
//    }
//}

//public class TestSkill33Mgr : SkillMgr
//{
//    protected TestSkill33Mgr() : base(SkillName.TestSkill33)
//    {
//    }

//    public static TestSkill33Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill33Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill33>(skill);
//    }

//    public class TestSkill33 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill33(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill33");
//        }
//    }
//}

//public class TestSkill34Mgr : SkillMgr
//{
//    protected TestSkill34Mgr() : base(SkillName.TestSkill34)
//    {
//    }

//    public static TestSkill34Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill34Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill34>(skill);
//    }

//    public class TestSkill34 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill34(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill34");
//        }
//    }
//}

//public class TestSkill35Mgr : SkillMgr
//{
//    protected TestSkill35Mgr() : base(SkillName.TestSkill35)
//    {
//    }

//    public static TestSkill35Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill35Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill35>(skill);
//    }

//    public class TestSkill35 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill35(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill35");
//        }
//    }
//}

//public class TestSkill36Mgr : SkillMgr
//{
//    protected TestSkill36Mgr() : base(SkillName.TestSkill36)
//    {
//    }

//    public static TestSkill36Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill36Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill36>(skill);
//    }

//    public class TestSkill36 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill36(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill36");
//        }
//    }
//}

//public class TestSkill37Mgr : SkillMgr
//{
//    protected TestSkill37Mgr() : base(SkillName.TestSkill37)
//    {
//    }

//    public static TestSkill37Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill37Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill37>(skill);
//    }

//    public class TestSkill37 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill37(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill37");
//        }
//    }
//}

//public class TestSkill38Mgr : SkillMgr
//{
//    protected TestSkill38Mgr() : base(SkillName.TestSkill38)
//    {
//    }

//    public static TestSkill38Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill38Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill38>(skill);
//    }

//    public class TestSkill38 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill38(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill38");
//        }
//    }
//}

//public class TestSkill39Mgr : SkillMgr
//{
//    protected TestSkill39Mgr() : base(SkillName.TestSkill39)
//    {
//    }

//    public static TestSkill39Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill39Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill39>(skill);
//    }

//    public class TestSkill39 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill39(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill39");
//        }
//    }
//}

//public class TestSkill40Mgr : SkillMgr
//{
//    protected TestSkill40Mgr() : base(SkillName.TestSkill40)
//    {
//    }

//    public static TestSkill40Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill40Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill40>(skill);
//    }

//    public class TestSkill40 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill40(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill40");
//        }
//    }
//}

//public class TestSkill41Mgr : SkillMgr
//{
//    protected TestSkill41Mgr() : base(SkillName.TestSkill41)
//    {
//    }

//    public static TestSkill41Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill41Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill41>(skill);
//    }

//    public class TestSkill41 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill41(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill41");
//        }
//    }
//}

//public class TestSkill42Mgr : SkillMgr
//{
//    protected TestSkill42Mgr() : base(SkillName.TestSkill42)
//    {
//    }

//    public static TestSkill42Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill42Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill42>(skill);
//    }

//    public class TestSkill42 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill42(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill42");
//        }
//    }
//}

//public class TestSkill43Mgr : SkillMgr
//{
//    protected TestSkill43Mgr() : base(SkillName.TestSkill43)
//    {
//    }

//    public static TestSkill43Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill43Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill43>(skill);
//    }

//    public class TestSkill43 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill43(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill43");
//        }
//    }
//}

//public class TestSkill44Mgr : SkillMgr
//{
//    protected TestSkill44Mgr() : base(SkillName.TestSkill44)
//    {
//    }

//    public static TestSkill44Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill44Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill44>(skill);
//    }

//    public class TestSkill44 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill44(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill44");
//        }
//    }
//}

//public class TestSkill45Mgr : SkillMgr
//{
//    protected TestSkill45Mgr() : base(SkillName.TestSkill45)
//    {
//    }

//    public static TestSkill45Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill45Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill45>(skill);
//    }

//    public class TestSkill45 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill45(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill45");
//        }
//    }
//}

//public class TestSkill46Mgr : SkillMgr
//{
//    protected TestSkill46Mgr() : base(SkillName.TestSkill46)
//    {
//    }

//    public static TestSkill46Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill46Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill46>(skill);
//    }

//    public class TestSkill46 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill46(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill46");
//        }
//    }
//}

//public class TestSkill47Mgr : SkillMgr
//{
//    protected TestSkill47Mgr() : base(SkillName.TestSkill47)
//    {
//    }

//    public static TestSkill47Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill47Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill47>(skill);
//    }

//    public class TestSkill47 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill47(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill47");
//        }
//    }
//}

//public class TestSkill48Mgr : SkillMgr
//{
//    protected TestSkill48Mgr() : base(SkillName.TestSkill48)
//    {
//    }

//    public static TestSkill48Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill48Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill48>(skill);
//    }

//    public class TestSkill48 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill48(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill48");
//        }
//    }
//}

//public class TestSkill49Mgr : SkillMgr
//{
//    protected TestSkill49Mgr() : base(SkillName.TestSkill49)
//    {
//    }

//    public static TestSkill49Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill49Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill49>(skill);
//    }

//    public class TestSkill49 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill49(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill49");
//        }
//    }
//}

//public class TestSkill50Mgr : SkillMgr
//{
//    protected TestSkill50Mgr() : base(SkillName.TestSkill50)
//    {
//    }

//    public static TestSkill50Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill50Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill50>(skill);
//    }

//    public class TestSkill50 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill50(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill50");
//        }
//    }
//}

//public class TestSkill51Mgr : SkillMgr
//{
//    protected TestSkill51Mgr() : base(SkillName.TestSkill51)
//    {
//    }

//    public static TestSkill51Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill51Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill51>(skill);
//    }

//    public class TestSkill51 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill51(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill51");
//        }
//    }
//}

//public class TestSkill52Mgr : SkillMgr
//{
//    protected TestSkill52Mgr() : base(SkillName.TestSkill52)
//    {
//    }

//    public static TestSkill52Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill52Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill52>(skill);
//    }

//    public class TestSkill52 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill52(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill52");
//        }
//    }
//}

//public class TestSkill53Mgr : SkillMgr
//{
//    protected TestSkill53Mgr() : base(SkillName.TestSkill53)
//    {
//    }

//    public static TestSkill53Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill53Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill53>(skill);
//    }

//    public class TestSkill53 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill53(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill53");
//        }
//    }
//}

//public class TestSkill54Mgr : SkillMgr
//{
//    protected TestSkill54Mgr() : base(SkillName.TestSkill54)
//    {
//    }

//    public static TestSkill54Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill54Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill54>(skill);
//    }

//    public class TestSkill54 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill54(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill54");
//        }
//    }
//}

//public class TestSkill55Mgr : SkillMgr
//{
//    protected TestSkill55Mgr() : base(SkillName.TestSkill55)
//    {
//    }

//    public static TestSkill55Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill55Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill55>(skill);
//    }

//    public class TestSkill55 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill55(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill55");
//        }
//    }
//}

//public class TestSkill56Mgr : SkillMgr
//{
//    protected TestSkill56Mgr() : base(SkillName.TestSkill56)
//    {
//    }

//    public static TestSkill56Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill56Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill56>(skill);
//    }

//    public class TestSkill56 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill56(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill56");
//        }
//    }
//}

//public class TestSkill57Mgr : SkillMgr
//{
//    protected TestSkill57Mgr() : base(SkillName.TestSkill57)
//    {
//    }

//    public static TestSkill57Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill57Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill57>(skill);
//    }

//    public class TestSkill57 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill57(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill57");
//        }
//    }
//}

//public class TestSkill58Mgr : SkillMgr
//{
//    protected TestSkill58Mgr() : base(SkillName.TestSkill58)
//    {
//    }

//    public static TestSkill58Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill58Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill58>(skill);
//    }

//    public class TestSkill58 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill58(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill58");
//        }
//    }
//}

//public class TestSkill59Mgr : SkillMgr
//{
//    protected TestSkill59Mgr() : base(SkillName.TestSkill59)
//    {
//    }

//    public static TestSkill59Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill59Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill59>(skill);
//    }

//    public class TestSkill59 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill59(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill59");
//        }
//    }
//}

//public class TestSkill60Mgr : SkillMgr
//{
//    protected TestSkill60Mgr() : base(SkillName.TestSkill60)
//    {
//    }

//    public static TestSkill60Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill60Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill60>(skill);
//    }

//    public class TestSkill60 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill60(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill60");
//        }
//    }
//}

//public class TestSkill61Mgr : SkillMgr
//{
//    protected TestSkill61Mgr() : base(SkillName.TestSkill61)
//    {
//    }

//    public static TestSkill61Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill61Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill61>(skill);
//    }

//    public class TestSkill61 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill61(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill61");
//        }
//    }
//}

//public class TestSkill62Mgr : SkillMgr
//{
//    protected TestSkill62Mgr() : base(SkillName.TestSkill62)
//    {
//    }

//    public static TestSkill62Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill62Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill62>(skill);
//    }

//    public class TestSkill62 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill62(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill62");
//        }
//    }
//}

//public class TestSkill63Mgr : SkillMgr
//{
//    protected TestSkill63Mgr() : base(SkillName.TestSkill63)
//    {
//    }

//    public static TestSkill63Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill63Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill63>(skill);
//    }

//    public class TestSkill63 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill63(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill63");
//        }
//    }
//}

//public class TestSkill64Mgr : SkillMgr
//{
//    protected TestSkill64Mgr() : base(SkillName.TestSkill64)
//    {
//    }

//    public static TestSkill64Mgr Instance
//    {
//        get; private set;
//    }

//    public static void BuildInstance()
//    {
//        Instance = Instance ?? new TestSkill64Mgr();
//    }


//    public override void PlayerRelease(Skill skill)
//    {
//        Gamef.Command.UnitReleaseCurrentSkill(GameCtrl.PlayerUnit);
//    }

//    public override void Release(Skill skill, out SkillEffectBase skillEffectBase, params object[] Params)
//    {
//        skillEffectBase = null;
//        //收集信息
//        if (Params.Length == 0)
//            skillEffectBase = Gamef.CreateInstance<TestSkill64>(skill);
//    }

//    public class TestSkill64 : SkillEffectBase, IReusableClass
//    {
//        public TestSkill64(Skill skill)
//        {
//            this.skill = skill;
//            Start();
//        }

//        public void Reset(params object[] Params)
//        {
//            if (Gamef.CheckObjects(Params, typeof(Skill)))
//            {
//                this.skill = Params[0] as Skill;
//                Start();
//            }
//            else
//            {
//                Debug.LogError("释放失败");
//            }
//        }

//        public override void Start()
//        {
//            base.Start();
//            Debug.Log("你释放了TestSkill64");
//        }
//    }
//}

//#endregion