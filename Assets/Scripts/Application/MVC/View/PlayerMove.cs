using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RodeChange))]
public class PlayerMove : View
{
    public float speed = 20f;

    private CharacterController m_cc;

    public override string Name{ get{ return Consts.V_PlayerMove;} }

    public override void HandleEvent(string name, object data = null)
    {
        
    }

    private void Awake()
    {
        m_cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        m_cc.Move(transform.forward * speed * Time.deltaTime);
    }
}
