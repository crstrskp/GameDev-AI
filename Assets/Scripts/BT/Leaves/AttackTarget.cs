using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTarget : Leaf<Context>
{
    private UnitAttack m_unitAttack;
    public override Result Run(Context context) 
    {
        if (m_unitAttack == null)
            m_unitAttack = context.transform.GetComponent<UnitAttack>();

        if (m_unitAttack == null)
            return Result.FAILURE;

        if (m_unitAttack.CanAttack() == false)
            return Result.RUNNING;
            
        m_unitAttack.Attack(context.Target.gameObject);

        return Result.SUCCESS;
    }    
}
