using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CGameEvent : MonoBehaviour
{

    public static CGameEvent current
    {
        get
        {
            if (_inst == null)
            {
                GameObject obj = new GameObject("GameEvent");

                return obj.AddComponent<CGameEvent>();
            }
            return _inst;
        }
    }
    private static CGameEvent _inst;
    // Start is called before the first frame update

    private void Awake()
    {
        _inst = this;
    }

    public event Action<int> OnChangeColor;

    public event Action OnLight;

    public event Action<int> OnSelected;

    public event Action OnMove;

    // public event Action<int> OnSelectedMove;
    //Remove
     public void TriggerChangeColor(int id)
    {
        OnChangeColor?.Invoke(id);
    }

    public void TriggerLight()
    {
        OnLight?.Invoke();
    }

    public void TriggerSelected(int id)
    {
        OnSelected?.Invoke(id);
    }

    public void TriggerMove()
    {
        OnMove?.Invoke();
    }
}
