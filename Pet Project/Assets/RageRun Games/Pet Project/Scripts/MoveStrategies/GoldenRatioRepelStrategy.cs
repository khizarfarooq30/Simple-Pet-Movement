using UnityEngine;

public class GoldenRatioRepelStrategy : BaseMoveStrategy
{

   public GoldenRatioRepelStrategy(Leader leader, Transform followTransform, Transform currentTransform, int index) 
        : base(leader, followTransform, currentTransform,  index)
    {
     
    }
   
    public override void Move()
    {
        var leaderTransform = leader.transform;
        
        Vector3 targetPos = leaderTransform.position - (leaderTransform.position - followTransform.position).normalized * leader.repelAmount 
                    + GetAngularPosition(index, leader.goldenRatioRadius, leader.goldenRatioAngle);
        MoveTowardsTarget(targetPos);
    }


}