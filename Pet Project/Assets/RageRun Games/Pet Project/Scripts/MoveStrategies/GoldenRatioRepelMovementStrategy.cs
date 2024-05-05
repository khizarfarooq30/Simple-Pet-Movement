using UnityEngine;

public class GoldenRatioRepelMovemenStrategy : BaseMovementStrategies
{
    private float repelAmount;

   public GoldenRatioRepelMovemenStrategy(Leader leader, Transform leaderTransform, Transform followTransform, Transform currentTransform, Vector3 followOffset, int index, float repelAmount) 
        : base(leader, leaderTransform, followTransform, currentTransform, followOffset, index)
    {
        this.repelAmount = repelAmount;
    }
   
    public override void Move()
    {
        Vector3 targetPos = leaderTransform.position - (leaderTransform.position - followTransform.position).normalized * repelAmount 
                    + GetAngularPosition(index, leader.goldenRatioRadius, leader.goldenRatioAngle);
        MoveTowardsTarget(targetPos);
    }
}