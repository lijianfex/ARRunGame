using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 返回倒计时控制
/// </summary>
public class ResumeGameCtrl : Controller
{
    public override void Execute(object data = null)
    {
        UIResume resume = GetView<UIResume>();
        resume.StartCount();
    }
}
