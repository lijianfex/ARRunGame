using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RodeChange))]
public class PlayerMove : View
{
    #region 常量
    #endregion

    #region 事件
    #endregion

    #region 字段
    public float speed = 20f;

    private CharacterController m_cc;
    InputDirection m_InputDir = InputDirection.NULL;
    bool activeInput = false;
    Vector3 m_mousePos;
    #endregion

    #region 属性
    public override string Name { get { return Consts.V_PlayerMove; } }
    #endregion

    #region 方法
    IEnumerator UpdateAction()
    {
        while (true)
        {
            m_cc.Move(transform.forward * speed * Time.deltaTime);
            GetInputDirection();
            yield return 0;
        }
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
        else if(Input.GetKeyDown(KeyCode.S))
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

    #endregion

    #region Unity回调
    private void Awake()
    {
        m_cc = GetComponent<CharacterController>();
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
