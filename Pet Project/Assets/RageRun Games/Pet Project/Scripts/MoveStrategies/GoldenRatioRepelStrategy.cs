using UnityEngine;

public class GoldenRatioRepelStrategy : BaseMoveStrategy
{

    private Vector3 followOffset;
    
   public GoldenRatioRepelStrategy(Leader leader, Transform followTransform, Transform currentTransform, int index) 
        : base(leader, followTransform, currentTransform,  index)
    {
        followOffset = currentTransform.GetComponent<PetMovement>().FollowOffset;
    }
   
    public override void Move()
    {
        var leaderTransform = leader.transform;
        
        Vector3 targetPos = leaderTransform.position - (leaderTransform.position - followTransform.position).normalized * leader.repelAmount + followOffset
                    + GetAngularPosition(index, leader.goldenRatioRadius, leader.goldenRatioAngle);
        MoveTowardsTarget(targetPos);
    }


}