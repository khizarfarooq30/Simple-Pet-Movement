using UnityEngine;

public class CrazyCircularStrategy : BaseMoveStrategy
{
    public CrazyCircularStrategy(Leader leader, Transform followTransform, Transform currentTransform, int index) 
        : base(leader, followTransform, currentTransform, index)
    {
    }
    
    public override void Move()
    {
        Vector3 targetPos = followTransform.position + GetAngularPosition(index, leader.goldenRatioRadius, leader.anglularSpeed);
        MoveTowardsTarget(targetPos);
        leader.anglularSpeed += leader.moveSpeed;
    }


}