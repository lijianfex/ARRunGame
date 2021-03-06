﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RodeChange))]
public class PlayerMove : View
{
    #region 常量
    #endregion
    const float m_SpeedAddDis = 200f;//加速距离
    const float m_SpeedAddRate = 2f;//每次加速值
    const float m_MaxRunSpeed = 40f;//最大速度

    #region 事件
    #endregion

    #region 字段
    GameModel gm;

    [SerializeField]
    private float runspeed = 20f;//前向移动速度

    public float MoveSpeed = 20f;//左右移动速度
    public float JumpValue = 5f;//跳跃高度
    public float Grivaty = 9.8f;//重力值

    public SkinnedMeshRenderer ClothRenderer;//衣服
    public MeshRenderer BallRenderer;//球

    private CharacterController m_cc;//角色控制器

    //输入
    InputDirection m_InputDir = InputDirection.NULL;
    bool activeInput = false;//是否激活手势输入
    Vector3 m_mousePos;//鼠标位置

    //跑道切换
    RunWay nowRunWay = RunWay.Middle;
    RunWay targetRunWay = RunWay.Middle;
    float m_xDistance = 0;

    //跳跃
    float m_yDistance = 0;//y轴移动距离   

    //防止一直滚动
    bool m_isSlide = false;
    float m_slideTime;

    //更新加速
    float m_SpeedAddCount;

    

    //撞击
    bool m_IsHit = false;    
    float m_MaskSpeed;//记录减速前速度    
    float m_AddSpeedRate = 10f;//恢复速度的速率

    //Item
    int m_SkillTime;//技能时长

    public int m_isDoubleTime = 1;//倍数    

    IEnumerator MutiplyCor; //双倍金币协程

    //吸铁石检测
    SphereCollider MagnetCollider;//吸铁石协程
    IEnumerator MagnetCor;

    //无敌
    bool m_IsInvincible = false;
    IEnumerator InvincibleCor;//无敌协程


    //射门相关
    GameObject m_Ball;//球
    GameObject m_ShotTrail;//射门的球

    Vector3 m_OldTrailPos;//特效原来的位置
    IEnumerator GoalCor;//射门协程
    bool m_isGoalBall = false;//是否进球

    #endregion

    #region 属性
    public override string Name { get { return Consts.V_PlayerMove; } }


    public float Runspeed
    {
        get
        {
            return runspeed;
        }

        set
        {
            runspeed = value;
            runspeed = runspeed >= m_MaxRunSpeed ? m_MaxRunSpeed : runspeed;
        }
    }
    #endregion

    #region 方法
    IEnumerator UpdateAction()
    {
        while (true)
        {
            if (gm.IsPlay && !gm.IsPause)
            {
                //更新UI
                UpdateDis();//更新距离

                m_yDistance -= Grivaty * Time.deltaTime;
                m_cc.Move((transform.forward * Runspeed + new Vector3(0, m_yDistance, 0)) * Time.deltaTime);
                UpdatePostion();
                UpdateRunSpeed();
            }
            yield return 0;
        }
    }

    //UI更新
    void UpdateDis()
    {
        DistanceArgs args = new DistanceArgs
        {
            Distance = (int)transform.position.z
        };
        SendEvent(Consts.E_UpdateDis, args);//通知UIBoard
    }

    void UpdatePostion()
    {
        GetInputDirection();
        MovePostion();
    }
    //获取输入
    void GetInputDirection()
    {
        m_InputDir = InputDirection.NULL;

        //手势识别
        if (Input.GetMouseButtonDown(0))
        {
            activeInput = true;
            m_mousePos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0) && activeInput)
        {
            Vector3 Dir = Input.mousePosition - m_mousePos;
            if (Dir.magnitude > 30f)
            {
                if (Mathf.Abs(Dir.x) > Mathf.Abs(Dir.y) && Dir.x > 0)
                {
                    m_InputDir = InputDirection.Right;
                }
                else if (Mathf.Abs(Dir.x) > Mathf.Abs(Dir.y) && Dir.x < 0)
                {
                    m_InputDir = InputDirection.Left;
                }
                else if (Mathf.Abs(Dir.x) < Mathf.Abs(Dir.y) && Dir.y > 0)
                {
                    m_InputDir = InputDirection.Up;
                }
                else if (Mathf.Abs(Dir.x) < Mathf.Abs(Dir.y) && Dir.y < 0)
                {
                    m_InputDir = InputDirection.Down;
                }
                activeInput = false;
            }

        }

        //键盘输入
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            m_InputDir = InputDirection.Up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            m_InputDir = InputDirection.Down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            m_InputDir = InputDirection.Left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            m_InputDir = InputDirection.Right;
        }

    }

    //移动
    void MovePostion()
    {
        //判断切换跑道
        switch (m_InputDir)
        {
            case InputDirection.NULL:
                break;
            case InputDirection.Right:
                if (targetRunWay < RunWay.Right)
                {
                    targetRunWay++;
                    m_xDistance = 2;
                    SendMessage("AnimManager", m_InputDir);
                    Game.Instance.Sound.PlayEffect("Se_UI_Huadong");

                }
                break;
            case InputDirection.Left:
                if (targetRunWay > RunWay.Left)
                {
                    targetRunWay--;
                    m_xDistance = -2;
                    SendMessage("AnimManager", m_InputDir);
                    Game.Instance.Sound.PlayEffect("Se_UI_Huadong");

                }

                break;
            case InputDirection.Up:
                if (m_cc.isGrounded)
                {
                    m_yDistance = JumpValue;
                    SendMessage("AnimManager", m_InputDir);
                    Game.Instance.Sound.PlayEffect("Se_UI_Jump");
                }
                break;
            case InputDirection.Down:
                if (m_isSlide == false)
                {
                    m_isSlide = true;
                    m_slideTime = 0.773f;
                    SendMessage("AnimManager", m_InputDir);
                    Game.Instance.Sound.PlayEffect("Se_UI_Slide");
                }
                break;
        }
        //切换跑道
        if (targetRunWay != nowRunWay)
        {
            float move = Mathf.Lerp(0, m_xDistance, MoveSpeed * Time.deltaTime);
            transform.position += new Vector3(move, 0, 0);
            m_xDistance -= move;
            if (Mathf.Abs(m_xDistance) < 0.05)
            {
                m_xDistance = 0;
                nowRunWay = targetRunWay;
                switch (nowRunWay)
                {
                    case RunWay.Left:
                        transform.position = new Vector3(-2, transform.position.y, transform.position.z);
                        break;
                    case RunWay.Middle:
                        transform.position = new Vector3(0, transform.position.y, transform.position.z);
                        break;
                    case RunWay.Right:
                        transform.position = new Vector3(2, transform.position.y, transform.position.z);
                        break;
                }
            }
        }
        //roll滚动计时
        if (m_isSlide)
        {
            m_slideTime -= Time.deltaTime;
            if (m_slideTime <= 0)
            {
                m_slideTime = 0;
                m_isSlide = false;
            }
        }

    }

    //更新速度
    void UpdateRunSpeed()
    {
        m_SpeedAddCount += Runspeed * Time.deltaTime;
        if (m_SpeedAddCount >= m_SpeedAddDis)
        {
            m_SpeedAddCount = 0f;
            Runspeed += m_SpeedAddRate;
        }
    }

    //减速
    void HitObstacle()
    {
        if (m_IsHit)
            return;
        m_IsHit = true;
        m_MaskSpeed = Runspeed;
        Runspeed = 0f;
        StartCoroutine(DescreaseSpeed());
    }
    //恢复速度
    IEnumerator DescreaseSpeed()
    {
        while (Runspeed < m_MaskSpeed)
        {
            Runspeed += Time.deltaTime * m_AddSpeedRate;
            yield return 0;
        }
        m_IsHit = false;
    }

    //吃金币
    public void HitCoin()
    {
        //sendEvent 加金币数
        //print("Eat coin");
        CoinArgs args = new CoinArgs
        {
            CoinCount = m_isDoubleTime
        };
        SendEvent(Consts.E_UpdateCoin, args);
    }

    //处理碰到奖励物品
    public void HitItem(ItemType item)
    {
        ItemArgs e = new ItemArgs
        {
            hitCount = 0,
            itemtype = item
        };
        SendEvent(Consts.E_HitItem, e);//通知HitItemCtrl
    }

    //双倍金币
    public void HitMutiply()
    {
        if (MutiplyCor != null)
        {
            StopCoroutine(MutiplyCor);
        }
        MutiplyCor = MutiplyCoroTime();
        StartCoroutine(MutiplyCor);
    }

    IEnumerator MutiplyCoroTime()
    {
        m_isDoubleTime = 2;
        float timer = m_SkillTime;
        while (timer > 0)
        {
            if (gm.IsPlay && !gm.IsPause)
            {
                timer -= Time.deltaTime;
            }
            yield return 0;
        }
        //yield return new WaitForSeconds(m_SkillTime);
        m_isDoubleTime = 1;
    }

    //吸铁石
    public void HitMagnet()
    {
        if (MagnetCor != null)
        {
            StopCoroutine(MagnetCor);
        }
        MagnetCor = MagnetCoroTime();
        StartCoroutine(MagnetCor);
    }

    IEnumerator MagnetCoroTime()
    {
        MagnetCollider.enabled = true;
        float timer = m_SkillTime;
        while (timer > 0)
        {
            if (gm.IsPlay && !gm.IsPause)
            {
                timer -= Time.deltaTime;
            }
            yield return 0;
        }
        //yield return new WaitForSeconds(m_SkillTime);
        MagnetCollider.enabled = false;
    }

    //无敌状态
    public void HitInvincible()
    {
        if (InvincibleCor != null)
        {
            StopCoroutine(InvincibleCor);
        }
        InvincibleCor = InvincibleCoroutine();
        StartCoroutine(InvincibleCor);
    }

    IEnumerator InvincibleCoroutine()
    {
        m_IsInvincible = true;
        float timer = m_SkillTime;
        while (timer > 0)
        {
            if (gm.IsPlay && !gm.IsPause)
            {
                timer -= Time.deltaTime;
            }
            yield return 0;
        }
        //yield return new WaitForSeconds(m_SkillTime);
        m_IsInvincible = false;
    }

    //加时间
    public void HitAddTime()
    {
        //sendEvent 加时间
        //print("Add time");
        SendEvent(Consts.E_HitAddTime);//通知UIBoard
    }


    //------------------------
    //射门相关
    public void OnFootBallClick()
    {
        if (GoalCor != null)
        {
            StopCoroutine(GoalCor);
        }
        SendMessage("MessagePlayShot");//通知PlayAnim,播放射门动画
        m_ShotTrail.SetActive(true);
        m_Ball.SetActive(false);
        GoalCor = MoveBall();
        StartCoroutine(GoalCor);
    }

    IEnumerator MoveBall()
    {
        while (true)
        {
            if(gm.IsPlay&&!gm.IsPause)
            {
                m_ShotTrail.transform.Translate(transform.forward * 40 * Time.deltaTime);
            }            
            yield return 0;
        }
    }

    //球进了
    public void HitBallDoor()
    {
        //停止协程
        StopCoroutine(GoalCor);

        //把球归位
        m_ShotTrail.transform.localPosition = m_OldTrailPos;
        m_ShotTrail.SetActive(false);
        m_Ball.SetActive(true);

        //是否进球
        m_isGoalBall = true;

        //特效
        Game.Instance.Pool.Spawn("FX_GOAL", m_ShotTrail.transform.parent);

        //声音
        Game.Instance.Sound.PlayEffect("Se_UI_Goal");

        //发送进球事件--->UIBoard
        SendEvent(Consts.E_ShotGoal);

    }

    #endregion

    #region Unity回调
    private void Awake()
    {
        m_cc = GetComponent<CharacterController>();
        gm = GetModel<GameModel>();
        m_SkillTime = gm.SkillTime;

        //获取吸铁石检测器
        MagnetCollider = GetComponentInChildren<SphereCollider>();
        MagnetCollider.enabled = false;

        //射门
        m_Ball = transform.Find("Ball").gameObject;
        m_ShotTrail = transform.Find("Effect").transform.Find("ShotTrail").gameObject;
        m_OldTrailPos = m_ShotTrail.transform.localPosition;//记录球的原来的位置
        m_ShotTrail.SetActive(false);

        //更新显示皮肤与球
        ClothRenderer.material.mainTexture = Game.Instance.Data.GetCloseData(gm.EquipeClothIndex).texture;
        BallRenderer.material = Game.Instance.Data.GetFootballData(gm.EquipeBallIndex).material;

    }

    private void Start()
    {
        StartCoroutine(UpdateAction());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tag.smallFence)//小栅栏
        {
            if (m_IsInvincible)
                return;
            other.gameObject.SendMessage("HitPlayer", transform.position);//----->Obstacles
            //减速
            HitObstacle();
        }
        else if (other.gameObject.tag == Tag.bigFence)//大栅栏
        {
            if (m_IsInvincible)
                return;
            if (m_isSlide)
                return;
            other.gameObject.SendMessage("HitPlayer", transform.position); //---->Obstacles
            //减速
            HitObstacle();
        }
        else if (other.gameObject.tag == Tag.block) //撞到撞到集装箱，结束
        {

            other.gameObject.SendMessage("HitPlayer", transform.position);//---->Blocks

            //结束游戏 sendEvent
            SendEvent(Consts.E_EndGame);

        }
        else if (other.gameObject.tag == Tag.smallBlock) //撞到集装箱前部，结束
        {

            other.gameObject.transform.parent.parent.SendMessage("HitPlayer", transform.position);//---->Blocks

            //结束游戏 sendEvent
            SendEvent(Consts.E_EndGame);
        }
        else if (other.gameObject.tag == Tag.carBeforeTrigger) //撞到车前的触发器，车可以移动
        {

            other.transform.parent.SendMessage("HitTrigger", SendMessageOptions.RequireReceiver);//---->Car

        }
        else if (other.gameObject.tag == Tag.beforeGoalTrigger)//碰到球门前的触发器
        {
            //可以射球，并且开始倒计时
            SendEvent(Consts.E_HitGoalTrigger);//——>UIBoard
            //显示加速特效
            Game.Instance.Pool.Spawn("FX_JiaSu", m_ShotTrail.transform.parent);
        }
        else if (other.gameObject.tag == Tag.goalKeeper)//撞到守门员
        {
            //减速
            HitObstacle();           
            //守门员飞走
            other.transform.parent.parent.parent.SendMessage("HitGoalKeeper", SendMessageOptions.RequireReceiver);//--->ShotGoal
        }
        else if(other.gameObject.tag==Tag.ballDoor)
        {
            if(m_isGoalBall)
            {
                m_isGoalBall = false;
                return;
            }
            //减速
            HitObstacle();

            //球网特效粘在主角
            Game.Instance.Pool.Spawn("FX_QiuWang", m_ShotTrail.transform.parent);

            other.transform.parent.parent.SendMessage("HitDoor", nowRunWay);//--->ShotGoal
        }

    }


    #endregion

    #region 事件回调
    public override void RegisterAttentionEvent()
    {
        AttentionList.Add(Consts.E_FootShotClick);
    }

    public override void HandleEvent(string name, object data = null)
    {
        switch (name)
        {
            case Consts.E_FootShotClick:
                OnFootBallClick();
                break;
            default:
                break;
        }
    }
    #endregion

    #region 帮助方法
    #endregion

}








