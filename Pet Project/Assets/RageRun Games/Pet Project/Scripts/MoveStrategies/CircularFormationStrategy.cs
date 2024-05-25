using UnityEngine;

public class CircularFormationStrategy : BaseMoveStrategy
{
    public CircularFormationStrategy(Leader leader, Transform followTransform, Transform currentTransform, int index) 
        : base(leader, followTransform, currentTransform, index)
    {
    }
    
    public override void Move()
    {
        // circular formation
        Vector3 targetPos = leader.transform.position + GetCircularPosition(index, leader.goldenRatioRadius, leader.goldenRatioAngle);
        MoveTowardsTarget(targetPos);
    }
}

