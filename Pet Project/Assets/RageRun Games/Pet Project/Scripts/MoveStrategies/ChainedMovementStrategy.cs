using UnityEngine;

public class ChainedMovementStrategy : BaseMovementStrategies
{
 
    public ChainedMovementStrategy(Leader leader, Transform leaderTransform, Transform followTransform, Transform currentTransform, Vector3 followOffset, int index) 
        : base(leader, leaderTransform, followTransform, currentTransform, followOffset, index)
    {
    }
    
    public override void Move()
    {
        Vector3 targetPos = followTransform.position + new Vector3(followOffset.x, leader.MoveVector.magnitude < 0.1f ? initialYPosition : followOffset.y, followOffset.z);
        MoveTowardsTarget(targetPos);
    }

 
}