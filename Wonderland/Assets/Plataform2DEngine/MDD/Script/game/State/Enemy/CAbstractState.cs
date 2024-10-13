using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CAbstractState : ScriptableObject
{
  public enum ExecutionState
    {
        NONE,
        ACTIVE,
        COMPLETED,
        TERMINATED,
    };
   public ExecutionState ExecutationState { get; protected set; }

 
    public virtual void OnEnable()
    {
        ExecutationState = ExecutionState.NONE;
    }
    public virtual bool EnterState()
    {
        ExecutationState = ExecutionState.ACTIVE;
        return true;
    }

    public abstract void UpdateState();
    

    public virtual bool ExitState()
    {
        return true;
    }
    /*
    public ExecutionState ExecutionState
    {
        get
        {
            return _executationState;
        }
        protected set
        {
            _executationState = value;
        }
    }
    */

}
