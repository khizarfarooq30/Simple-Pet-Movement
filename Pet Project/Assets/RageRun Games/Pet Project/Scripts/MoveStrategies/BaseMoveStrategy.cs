using UnityEngine;

public abstract class BaseMoveStrategy
{
    protected Leader leader;
    protected Transform followTransform;
    protected Transform currentTransform;
    protected Vector3 velocity;
    protected int index;

    public BaseMoveStrategy(Leader leader,  Transform followTransform, Transform currentTransform, int index)
    {
        this.leader = leader;
        this.followTransform = followTransform;
        this.currentTransform = currentTransform;
        this.index = index;
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
    
    public Vector3 GetCircularPosition(int index, float radius, float angle)
    {
        float x = radius * Mathf.Cos(angle * index * Mathf.Deg2Rad);
        float z = radius * Mathf.Sin(angle * index * Mathf.Deg2Rad);
        return new Vector3(x, 0f, z);
    }

}