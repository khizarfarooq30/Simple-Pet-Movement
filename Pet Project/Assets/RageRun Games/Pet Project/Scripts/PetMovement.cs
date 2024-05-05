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

    private BaseMovementStrategies baseMovementStrategies;


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
        // UpdateTargetPosition();
        // MoveTowardsTarget();

        // assign strategies with number keys
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            baseMovementStrategies = new GoldenRatioMovementStrategy(leader, leaderTransform, followTransform,
                transform, followOffset, index, leader.goldenRatioRadius, leader.goldenRatioAngle);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            baseMovementStrategies = new GoldenRatioRepelMovemenStrategy(leader, leaderTransform, followTransform,
                transform, followOffset, index, leader.repelAmount);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            baseMovementStrategies = new BoxFormationPatternMovementStrategy(leader, leaderTransform, followTransform,
                transform, followOffset, index, leader.rowSize, leader.columnSize, leader.formationDistance);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            baseMovementStrategies = new LeaderRepelPetMovemenStrategy(leader, leaderTransform, followTransform,
                transform, followOffset, index, leader.repelAmount);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            baseMovementStrategies = new ChainedMovementStrategy(leader, leaderTransform, followTransform, transform,
                followOffset, index);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            baseMovementStrategies = new CircularCrazyMovementStrategy(leader, leaderTransform, followTransform,
                transform, followOffset, index, leader.goldenRatioRadius, leader.goldenRatioAngle, leader.moveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            baseMovementStrategies = new RowColumnAdaptiveFormation(leader, leaderTransform,
                followTransform, transform, followOffset, index, leader.rowSize, leader.columnSize,
                leader.formationDistance);
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            baseMovementStrategies = new BoxFormationPatternStrategy(leader, leaderTransform, followTransform,
                transform, followOffset, index, leader.rowSize, leader.columnSize, leader.formationDistance);
        }
        
        if (baseMovementStrategies != null)
        {
            baseMovementStrategies.Move();
        }
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
    
    public void SetMoveStrategy(BaseMovementStrategies movementStrategy)
    {
        baseMovementStrategies = movementStrategy;
    }
}