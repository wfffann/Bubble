using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>//指定传入的T是继承了Singleton的类
{
    private static T instance;

    public static T Instance => instance;
    //保证单例不重复创建
    protected virtual void Awake()
    {
        if ((Object)instance != (Object)null)
        {
            Object.Destroy(base.gameObject);
            return;
        }
        else
        {
            instance = (T)this;
        }
    }
}