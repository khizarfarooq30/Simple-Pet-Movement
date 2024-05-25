using UnityEngine;

public class PetRepelPetStrategy : BaseMoveStrategy
{
    public PetRepelPetStrategy(Leader leader, Transform followTransform, Transform currentTransform, int index) : base(leader, followTransform, currentTransform, index)
    {
    }

    public override void Move()
    {
        var normalized = (followTransform.transform.position - currentTransform.position).normalized;
        Vector3 targetPos = leader.transform.position - new Vector3(normalized.x, 0f, normalized.z) * leader.repelAmount;
        MoveTowardsTarget(targetPos);
    }
}