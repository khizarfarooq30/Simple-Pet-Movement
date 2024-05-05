using UnityEngine;

public abstract class BaseMovementStrategies
{
    protected Leader leader;
    protected Transform leaderTransform;
    protected Transform followTransform;
    protected Transform currentTransform;
    protected Vector3 velocity;
    protected float initialYPosition;
    protected Vector3 followOffset;
    protected int index;

    public BaseMovementStrategies(Leader leader, Transform leaderTransform, Transform followTransform, Transform currentTransform, Vector3 followOffset, int index)
    {
        this.leader = leader;
        this.leaderTransform = leaderTransform;
        this.followTransform = followTransform;
        this.currentTransform = currentTransform;
        this.followOffset = followOffset;
        this.index = index;
        initialYPosition = followTransform.position.y;
    }

    public abstract void Move();
    
    protected void MoveTowardsTarget(Vector3 targetPos)
    {
        Vector3 position = currentTransform.position;
        float speedCap = (Mathf.Clamp(Vector3.Distance(position, targetPos), leader.stopDistance, leader.maxDistance) - leader.stopDistance) * leader.moveSpeed;
        Vector3 direction = (targetPos - position).normalized;

        velocity = Vector3.ClampMagnitude(velocity + direction, speedCap);
        position += velocity * Time.deltaTime;
        currentTransform.position = position;

        currentTransform.LookAt(targetPos);
    }
    
    public Vector3 GetAngularPosition(int index, float radius, float angle)
    {
        float x = Mathf.Sqrt(index) * radius * Mathf.Cos(angle * index * Mathf.Deg2Rad);
        float z = Mathf.Sqrt(index) * radius * Mathf.Sin(angle * index * Mathf.Deg2Rad);
        return new Vector3(x, 0f, z);
    }
}