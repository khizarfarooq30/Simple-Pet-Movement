using UnityEngine;

public class GoldenRatioMovementStrategy : BaseMovementStrategies
{
    private float goldenRatioRadius;
    private float goldenRatioAngle;

    public GoldenRatioMovementStrategy(Leader leader, Transform leaderTransform, Transform followTransform, Transform currentTransform, Vector3 followOffset, int index, float goldenRatioRadius, float goldenRatioAngle) 
        : base(leader, leaderTransform, followTransform,  currentTransform,followOffset, index)
    {
        this.goldenRatioRadius = goldenRatioRadius;
        this.goldenRatioAngle = goldenRatioAngle;
    }
    
    public override void Move()
    {
        Vector3 targetPos = leaderTransform.position + GetAngularPosition(index, goldenRatioRadius, goldenRatioAngle);
        MoveTowardsTarget(targetPos);
    }

 
}