using UnityEngine;

public class UnitTargeting : MonoBehaviour
{
    [SerializeField] private LayerMask m_layerMask = new LayerMask();
    private GameObject m_target;
    [SerializeField] private float m_aggroRange = 10.0f;

    private Unit m_unit;

    private void Awake() 
    {
        m_unit = GetComponent<Unit>();
    }

    public GameObject GetTarget() => FindClosestTargetInRange();

    private GameObject FindClosestTargetInRange()
    {
        var colliders = Physics.OverlapSphere(transform.position, m_aggroRange, m_layerMask);

        GameObject target = null;
        float distanceToTarget = float.MaxValue;

        foreach (Collider col in colliders)
        {
            var unit = col.GetComponent<Unit>();
            if (unit != null && unit.GetTeam() != m_unit.GetTeam()) // TODO: Store in var
            {
                float dist = (transform.position - unit.transform.position).magnitude;
                if (dist < distanceToTarget)    
                {
                    distanceToTarget = dist;
                    target = unit.gameObject;
                }
            }
        }

        return target;
    }
}