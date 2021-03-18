using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTargetInRange : Leaf<Context>
{
    private UnitTargeting m_unitTargeting;
    public override Result Run(Context context) 
    {
        m_unitTargeting = context.transform.GetComponent<UnitTargeting>();
        
        if (m_unitTargeting == null) return Result.FAILURE;

        context.Target = m_unitTargeting.GetTarget()?.transform;

        if (context.Target == null)
            return Result.FAILURE;
        
        return Result.SUCCESS;
    }

}
