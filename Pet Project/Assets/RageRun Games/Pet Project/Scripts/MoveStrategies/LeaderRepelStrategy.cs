using UnityEngine;

public class LeaderRepelStrategy : BaseMoveStrategy
{
    public Vector3 followOffset;
    
    public LeaderRepelStrategy(Leader leader, Transform followTransform, Transform currentTransform,int index) 
        : base(leader,  followTransform, currentTransform, index)
    {
        followOffset = currentTransform.GetComponent< PetMovement >().FollowOffset;
    }

    public override void Move()
    {
        var leaderTransform = leader.transform;
        Vector3 targetPos = leaderTransform.position + (leaderTransform.position - followTransform.position).normalized * leader.repelAmount;
        MoveTowardsTarget(targetPos);
    }

}