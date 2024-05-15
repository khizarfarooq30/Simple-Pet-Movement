using UnityEngine;

public class GoldenRatioStrategy : BaseMoveStrategy
{
    public GoldenRatioStrategy(Leader leader, Transform followTransform, Transform currentTransform, int index)
        : base(leader, followTransform, currentTransform, index)
    {
    }

    public override void Move()
    {
        Vector3 targetPos = leader.transform.position + GetAngularPosition(index, leader.goldenRatioRadius, leader.goldenRatioAngle);
        MoveTowardsTarget(targetPos);
    }

}