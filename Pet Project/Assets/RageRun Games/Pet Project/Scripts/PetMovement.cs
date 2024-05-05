using UnityEngine;

public class PetMovement : MonoBehaviour
{
    private Leader leader;
    private Transform leaderTransform;

    private Transform followTransform;
    private Vector3 targetPos;
    private Vector3 velocity;
    
    private float initialYPosition;
    
    private Vector3 followOffset;
    
    private int index = 1;

    public bool EnableFollow { get; set; }

    private void Start()
    {
        initialYPosition = transform.position.y;
        leaderTransform = GameObject.FindGameObjectWithTag("Player").transform;
        leader = leaderTransform.GetComponent<Leader>();
        
        index = transform.GetSiblingIndex();
    }

    void Update()
    {
        if (!EnableFollow) return;

        UpdateTargetPosition();

        MoveTowardsTarget();
    }

    private void UpdateTargetPosition()
    {
        switch (leader.followMode)
        {
            case FollowMode.chainedMovement:
                targetPos = followTransform.position + new Vector3(followOffset.x, leader.MoveVector.magnitude < 0.1f ? initialYPosition : followOffset.y, followOffset.z);
                break;
            case FollowMode.goldenRatioMovement:
                targetPos = leaderTransform.position + GetAngularPosition(index, leader.goldenRatioRadius, leader.goldenRatioAngle);
                break;
            case FollowMode.rowColumnPatterMovement:
                targetPos = leaderTransform.position + new Vector3(leader.formationDistance * (index % leader.rowSize), 0, leader.formationDistance * (index / leader.columnSize));
                break;
            case FollowMode.leaderRepelPetMovement:
                targetPos = leaderTransform.position - (leaderTransform.position - transform.position).normalized * leader.repelAmount + followOffset;
                break;
            case FollowMode.boxFormationPatternMovement:
                targetPos = leaderTransform.position + followOffset;
                break;
            case FollowMode.None:
                targetPos = leaderTransform.position;
                break;
        }
    }

    private void MoveTowardsTarget()
    {
        Vector3 position = transform.position;
        float speedCap = (Mathf.Clamp(Vector3.Distance(position, targetPos), leader.stopDistance, leader.maxDistance) - leader.stopDistance) * leader.moveSpeed;
        Vector3 direction = (targetPos - position).normalized;

        velocity = Vector3.ClampMagnitude(velocity + direction, speedCap);
        position += velocity * Time.deltaTime;
        transform.position = position;

        transform.LookAt(targetPos);
    }

    public void SetFollowTarget(Transform target)
    {
        followTransform = target;
        EnableFollow = true;
    }

    public bool IsFollowingTarget()
    {
        return followTransform != null;
    }
    
    public void SetFollowOffset(Vector3 offset)
    {
        followOffset = offset;
    }


    public Vector3 GetAngularPosition(int index, float radius, float angle)
    {
        float x = Mathf.Sqrt(index) * radius * Mathf.Cos(angle * index * Mathf.Deg2Rad);
        float z = Mathf.Sqrt(index) * radius * Mathf.Sin(angle * index * Mathf.Deg2Rad);
        return new Vector3(x, 0f, z);
    }

}