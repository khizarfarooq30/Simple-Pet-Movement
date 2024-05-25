using UnityEngine;

public class LeaderRepelStrategy : BaseMoveStrategy
{
    
    public LeaderRepelStrategy(Leader leader, Transform followTransform, Transform currentTransform,int index) 
        : base(leader,  followTransform, currentTransform, index)
    {
    
    }

    public override void Move()
    {
        var leaderTransform = leader.transform;
        Vector3 targetPos = leaderTransform.position -
            (leaderTransform.position - followTransform.position).normalized * leader.repelAmount + leader.followOffset;
        MoveTowardsTarget(targetPos);
    }

}