using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RodeChange))]
public class PlayerMove : View
{
    #region 常量
    #endregion
    const float m_SpeedAddDis = 200f;//加速距离
    const float m_SpeedAddRate = 0.5f;//每次加速值
    const float m_MaxRunSpeed = 40f;//最大速度

    #region 事件
    #endregion

    #region 字段
    [SerializeField]
    private float runspeed = 20f;//前向移动速度

    public float MoveSpeed = 20f;//左右移动速度
    public float JumpValue = 5f;//跳跃高度
    public float Grivaty = 9.8f;//重力值

    private CharacterController m_cc;//角色控制器

    InputDirection m_InputDir = InputDirection.NULL;//输入
    bool activeInput = false;
    Vector3 m_mousePos;

    RunWay nowRunWay = RunWay.Middle;//跑道切换
    RunWay targetRunWay = RunWay.Middle;
    float m_xDistance = 0;

    float m_yDistance = 0;   //跳跃

    bool m_isSlide = false;//防止一直滚动
    float m_slideTime;

    float m_SpeedAddCount;//更新加速

    GameModel m_GM;

    //是否撞击
    bool m_IsHit = false;
    //记录减速前速度
    float m_MaskSpeed;
    //增加速度的速率
    float m_AddSpeedRate = 10f;

    //Item
    public int m_isDoubleTime = 1;
    int m_SkillTime;//双倍时长

    IEnumerator MutiplyCor; //双倍金币协程

    //吸铁石检测
    SphereCollider MagnetCollider;//吸铁石协程
    IEnumerator MagnetCor;

    //无敌
    bool m_IsInvincible = false;
    IEnumerator InvincibleCor;//无敌协程
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
            if (m_GM.IsPlay && !m_GM.IsPause)
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
        SendEvent(Consts.E_UpdateDis, args);
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

    IEnumerator DescreaseSpeed()
    {
        while (Runspeed < m_MaskSpeed)
        {
            Runspeed += Time.deltaTime * m_AddSpeedRate;
            yield return 0;
        }
        m_IsHit = true;
    }

    //吃金币
    public void HitCoin()
    {
        //sendEvent 加金币数
        print("Eat coin");
        CoinArgs args = new CoinArgs
        {
            CoinCount = m_isDoubleTime
        };
        SendEvent(Consts.E_UpdateCoin, args);
    }

    //处理碰到奖励物品
    public void HitItem(ItemType item)
    {
        switch (item)
        {
            case ItemType.ItemInvincible:
                HitInvincible();
                break;
            case ItemType.ItemMultiply:
                HitMutiply();
                break;
            case ItemType.ItemMagnet:
                HitMagnet();
                break;
            default:
                break;
        }
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
        yield return new WaitForSeconds(m_SkillTime);
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
        yield return new WaitForSeconds(m_SkillTime);
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
        yield return new WaitForSeconds(m_SkillTime);
        m_IsInvincible = false;
    }

    //加时间
    public void HitAddTime()
    {
        //sendEvent 加时间
        print("Add time");
        SendEvent(Consts.E_HitAddTime);
    }

    #endregion

    #region Unity回调
    private void Awake()
    {
        m_cc = GetComponent<CharacterController>();
        m_GM = GetModel<GameModel>();
        m_SkillTime = m_GM.SkillTime;

        MagnetCollider = GetComponentInChildren<SphereCollider>();
        MagnetCollider.enabled = false;
    }

    private void Start()
    {
        StartCoroutine(UpdateAction());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tag.smallFence)
        {
            if (m_IsInvincible)
                return;
            other.gameObject.SendMessage("HitPlayer", transform.position);
            //减速
            HitObstacle();
        }
        else if (other.gameObject.tag == Tag.bigFence)
        {
            if (m_IsInvincible)
                return;
            if (m_isSlide)
                return;
            other.gameObject.SendMessage("HitPlayer", transform.position);
            //减速
            HitObstacle();
        }
        else if (other.gameObject.tag == Tag.block) //撞到撞到集装箱，结束
        {

            other.gameObject.SendMessage("HitPlayer", transform.position);

            //结束游戏 sendEvent
            SendEvent(Consts.E_EndGame);

        }
        else if (other.gameObject.tag == Tag.smallBlock) //撞到集装箱前部，结束
        {

            other.gameObject.transform.parent.parent.SendMessage("HitPlayer", transform.position);

            //结束游戏 sendEvent
            SendEvent(Consts.E_EndGame);
        }
        else if (other.gameObject.tag == Tag.carBeforeTrigger) //撞到车前的触发器，车可以移动
        {

            other.transform.parent.SendMessage("HitTrigger", SendMessageOptions.RequireReceiver);

        }

    }


    #endregion

    #region 事件回调
    public override void HandleEvent(string name, object data = null)
    {

    }
    #endregion

    #region 帮助方法
    #endregion

}








