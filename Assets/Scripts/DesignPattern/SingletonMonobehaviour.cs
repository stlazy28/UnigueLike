using UnityEngine;
using System;

public abstract class SingletonMonobehaviour<T> : MonoBehaviour where T: MonoBehaviour
{
    private static T _instance;
    public static T GetInstance
    {
        get
        {
            if (_instance == null)
            {
                Type t = typeof(T);

                _instance = (T)FindObjectOfType(t);
                if (_instance == null)
                {
                    Debug.LogError(t + " をアタッチしているGameObjectはありません");
                }
            }
            return _instance;
        }
    }

    virtual protected void Awake()
    {
        CheckInstance();
    }

    /// <summary>
    /// 他のゲームオブジェクトにアタッチされているか調べる
    /// アタッチされている場合は破棄する
    /// </summary>
    /// <returns>他のゲームオブジェクトにアタッチされている場合はfalse</returns>
    protected bool CheckInstance()
    {
        if(_instance == null)
        {
            _instance = this as T;
            return true;
        }
        else if (GetInstance == this)
        {
            return true;
        }
        Destroy(this);
        return false;
    }
}