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
            if(m_GM.IsPlay&&!m_GM.IsPause)
            {
                m_yDistance -= Grivaty * Time.deltaTime;
                m_cc.Move((transform.forward * Runspeed + new Vector3(0, m_yDistance, 0)) * Time.deltaTime);
                UpdatePostion();
                UpdateRunSpeed();
            }            
            yield return 0;
        }
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

        print(m_InputDir);
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
                }
                SendMessage("AnimManager", m_InputDir);
                break;
            case InputDirection.Left:
                if (targetRunWay > RunWay.Left)
                {
                    targetRunWay--;
                    m_xDistance = -2;
                }
                SendMessage("AnimManager", m_InputDir);
                break;
            case InputDirection.Up:
                if (m_cc.isGrounded)
                {
                    m_yDistance = JumpValue;
                    SendMessage("AnimManager", m_InputDir);
                }

                break;
            case InputDirection.Down:
                if (m_isSlide == false)
                {
                    m_isSlide = true;
                    m_slideTime = 0.773f;
                    SendMessage("AnimManager", m_InputDir);
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
    #endregion

    #region Unity回调
    private void Awake()
    {
        m_cc = GetComponent<CharacterController>();
        m_GM = GetModel<GameModel>();
    }

    private void Start()
    {
        StartCoroutine(UpdateAction());
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








