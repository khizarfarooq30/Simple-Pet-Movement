using UnityEngine;

public class PetMovement : MonoBehaviour
{
   
    public Transform leaderTransform; 

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float maxDistance = 3f;
    [SerializeField] private float stopDistance = 1f;

    [SerializeField] private Vector3 followOffset = new Vector3(1f, 0f, 1f);
    
    [SerializeField] private bool ignoreOffset;
    [SerializeField] private bool randomizeAutoOffset;
    [SerializeField] private bool enablePetMoveToGroundWhenIdle;
    [SerializeField] private bool alwaysStayOnGround;
    
    [SerializeField] private Animator animator;
    
     private Transform followTransform;

    private Vector3 targetPos;
    private Vector3 velocity;

    private float speedCap = 0;
    private float initialYPosition;
    
    private Leader leader;

    public bool EnableFollow { get; set; }
<<<<<<< Updated upstream

=======
    
    public BaseMoveStrategy baseMoveStrategy;

    private Vector3 followOffset;
    
    public Vector3 FollowOffset
    {
        get => followOffset;
        set => followOffset = value;
    }
    
>>>>>>> Stashed changes
    private void Start()
    {
        initialYPosition = transform.position.y;

        leaderTransform = GameObject.FindWithTag("Player").transform;
        
        leader = leaderTransform.GetComponent<Leader>();
        
        if (randomizeAutoOffset)
        {
            followOffset = new Vector3(Random.Range(-2f, 2f), 0f, Random.Range(-2f, 2f));
        }
    }

    void Update()
    {
        if (!EnableFollow) return;

        if (ignoreOffset)
        {
            targetPos = followTransform.position + new Vector3(0, enablePetMoveToGroundWhenIdle && leader.MoveVector.magnitude < 0.1f ? 0f : followOffset.y, 0);
        }
        else
        {
            targetPos = leaderTransform.position + new Vector3(followOffset.x, enablePetMoveToGroundWhenIdle && leader.MoveVector.magnitude < 0.1f ? initialYPosition : followOffset.y, followOffset.z);
        }
        
        Vector3 position = transform.position;
        float speedCap = (Mathf.Clamp(Vector3.Distance(position, targetPos), stopDistance, maxDistance) - stopDistance) * moveSpeed;
        Vector3 direction = (targetPos - position).normalized;

        velocity = Vector3.ClampMagnitude(velocity + direction, speedCap);
        position += velocity * Time.deltaTime;
        transform.position = position;

        transform.LookAt(targetPos);

        if (animator != null)
        {
            animator.SetBool("Moving", velocity.magnitude > 0.1f);
        }
    }
<<<<<<< Updated upstream

    public void SetFollowTarget(Transform target)
=======
    
    private void AssignStrategy()
    {
        // num keys assign strategies based on all number keys
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
             baseMoveStrategy = new BoxFormationStrategy(leader, followTransform, transform,  index);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            baseMoveStrategy = new ChainedSnakeLikeStrategy(leader, followTransform, transform,  index);
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            baseMoveStrategy = new CrazyCircularStrategy(leader, followTransform, transform,  index);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            baseMoveStrategy = new GoldenRatioStrategy(leader, followTransform, transform,  index);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            baseMoveStrategy = new GoldenRatioRepelStrategy(leader, followTransform, transform,  index);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            baseMoveStrategy = new LeaderRepelStrategy(leader, followTransform, transform,  index);
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            baseMoveStrategy = new RowColumnAdaptiveFormationStrategy(leader, followTransform, transform,  index);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            baseMoveStrategy = new CircularFormationStrategy( leader, followTransform, transform,  index);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            baseMoveStrategy = new TriangleFormationStrategy(leader, followTransform, transform,  index);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            baseMoveStrategy = new TriangleRepelStrategy(leader, followTransform, transform, index);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            baseMoveStrategy = new PetRepelPetStrategy(leader, followTransform, transform, index);
        }
    }
   
    public void SetFollowEnable(Transform followTransform)
>>>>>>> Stashed changes
    {
        followTransform = target;
        EnableFollow = true;
    }

    public bool IsFollowingTarget()
    {
        return followTransform != null;
    }
}