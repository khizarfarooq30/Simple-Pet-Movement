using UnityEngine;

public class CircularCrazyMovementStrategy : BaseMovementStrategies
{
    private float radius;
    private float angle;
    private float angularSpeed;

    public CircularCrazyMovementStrategy(Leader leader, Transform leaderTransform, Transform followTransform, Transform currentTransform, Vector3 followOffset, int index, float radius, float angle, float angularSpeed) 
        : base(leader, leaderTransform, followTransform, currentTransform, followOffset, index)
    {
        this.radius = radius;
        this.angle = angle;
        this.angularSpeed = angularSpeed;
    }
    
    public override void Move()
    {
        Vector3 targetPos = followTransform.position + GetAngularPosition(index, radius, angle);
        MoveTowardsTarget(targetPos);
        angle += angularSpeed;
    }
}