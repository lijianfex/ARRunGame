using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controller基类
/// </summary>
public abstract class Controller
{
    public abstract void Execute(object data = null);

    //获取Model
    protected T GetModel<T>() where T : Model
    {
        return MVC.GetModle<T>() as T;
    }

    //获取View
    protected T GetView<T>() where T : View
    {
        return MVC.GetView<T>() as T;
    }

    //注册view
    protected void RegisterView(View view)
    {
        MVC.RegisterView(view);
    }

    //注册model
    protected void RegisterModel(Model model)
    {
        MVC.RegisterModel(model);
    }

    //注册controller
    protected void RegisterController(string eventName, Type controllerType)
    {
        MVC.RegisterController(eventName, controllerType);
    }

}
