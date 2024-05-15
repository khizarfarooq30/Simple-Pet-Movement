using UnityEngine;

public class TriangleRepelStrategy : BaseMoveStrategy
{
    public TriangleRepelStrategy(Leader leader, Transform followTransform, Transform currentTransform, int index) :
        base(leader, followTransform, currentTransform, index)
    {
        leader.formationDistance = 0.13f;
        leader.followOffset = new Vector3(0.1f, 0, 0.1f);
        leader.triangleBase = 2;
    }

    public override void Move()
    {
        var normalized = (leader.transform.position - followTransform.position).normalized;
        // triangle formation
        Vector3 targetPos = leader.transform.position - new Vector3(normalized.x, 0f, normalized.z) * leader.repelAmount +
                            GetTrianglePosition(index);
        MoveTowardsTarget(targetPos);
    }

    private Vector3 GetTrianglePosition(int index)
    {
        Vector3 position = Vector3.zero;
        switch (index % leader.triangleBase)
        {
            case 0:
                position = new Vector3(
                    leader.formationDistance - leader.followOffset.x * index, 0,
                    leader.formationDistance + leader.followOffset.z * index);
                break;
            case 1:
                position = new Vector3(
                    leader.formationDistance + leader.followOffset.x * index, 0,
                    leader.formationDistance + leader.followOffset.z * index);
                break;
            case 2:
                position = new Vector3(
                    leader.formationDistance - leader.followOffset.x * index, 0,
                    leader.formationDistance - leader.followOffset.z * index);
                break;
            case 3:
                position = new Vector3(
                    leader.formationDistance + leader.followOffset.x * index, 0,
                    leader.formationDistance - leader.followOffset.z * index);
                break;
            case 4:
                position = new Vector3(0, 0,
                    leader.formationDistance - leader.followOffset.z * index);
                break;
            case 5:
                position = new Vector3(
                    leader.formationDistance - leader.followOffset.x * index, 0,
                    leader.formationDistance + leader.followOffset.z * index);
                break;
            case 6:
                position = new Vector3(
                    leader.formationDistance + leader.followOffset.x * index, 0,
                    leader.formationDistance + leader.followOffset.z * index);
                break;
            case 7:
                position = new Vector3(
                    leader.formationDistance - leader.followOffset.x * index, 0,
                    leader.formationDistance - leader.followOffset.z * index);
                break;
            case 8:
                position = new Vector3(
                    leader.formationDistance + leader.followOffset.x * index, 0,
                    leader.formationDistance - leader.followOffset.z * index);
                break;
            case 9:
                position = new Vector3(0, 0,
                    leader.formationDistance + leader.followOffset.z * index);
                break;
            case 10:
                position = new Vector3(
                    leader.formationDistance - leader.followOffset.x * index, 0,
                    leader.formationDistance - leader.followOffset.z * index);
                break;
        }

        return position;
    }
}