using UnityEngine;

public class ChainedSnakeLikeStrategy : BaseMoveStrategy
{
    
    public ChainedSnakeLikeStrategy(Leader leader, Transform followTransform, Transform currentTransform, int index) : base(leader,  followTransform, currentTransform, index)
    {
    }
    
    public override void Move()
    {
        Vector3 targetPos = followTransform.position + new Vector3(leader.followOffset.x, leader.followOffset.y, leader.followOffset.z);
        MoveTowardsTarget(targetPos);
    }



}