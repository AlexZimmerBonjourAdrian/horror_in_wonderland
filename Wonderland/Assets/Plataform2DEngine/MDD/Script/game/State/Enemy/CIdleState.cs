using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asset.Code.FSM.States
{ 
public class CIdleState : CAbstractState
{
        // Start is called before the first frame update

        public override bool EnterState()
        {
           base.EnterState();
            return true;

        }
        public override void UpdateState()
        {
            
        }

        public override bool ExitState()
        {
             base.ExitState();

            return true;
        }
    }
}
