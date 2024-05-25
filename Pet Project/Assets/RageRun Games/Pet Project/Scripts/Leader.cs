using System.Collections.Generic;
using UnityEngine;

public class Leader : MonoBehaviour
{
   [SerializeField] private float moveSpeed = 5f;
   [SerializeField] private Animator animator;
   
   [SerializeField] private bool useUpwardMovement;

   private float horizontal;
   private float vertical;
   private float up;
   
   private List<Transform> followTransforms = new List<Transform>();

<<<<<<< Updated upstream
   public Vector3 MoveVector { get; set; }

   private void Start()
   {
      followTransforms.Add(transform);
   }

   private void Update()
   {
      horizontal = Input.GetAxisRaw("Horizontal");
      vertical = Input.GetAxisRaw("Vertical");

      if (useUpwardMovement)
      {
         up = Input.GetKey(KeyCode.UpArrow) ? 1 : Input.GetKey(KeyCode.DownArrow) ? -1 : 0;
      }
      
      MoveVector = new Vector3(horizontal, up, vertical).normalized;
      transform.position += MoveVector * (moveSpeed * Time.deltaTime);
      
      if (MoveVector.magnitude > 0.1f)
      {
         // smooth rotation
         transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(MoveVector), Time.deltaTime * 10f);
      }
      
      if (animator != null)
      {
         animator.SetBool("Moving", MoveVector.magnitude > 0.1f);
      }
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.TryGetComponent(out PetMovement petMovement) && !petMovement.EnableFollow)
      {
         if (!petMovement.IsFollowingTarget())
         {
            petMovement.SetFollowTarget(followTransforms[^1]);
            followTransforms.Add(other.transform);
         }
      }
   }
}
=======
    [Header("Pet Settings")] 
    public float maxDistance = 3f;
    public float stopDistance = 1f;
    public Vector3 followOffset = new Vector3(1f, 0f, 1f);


    [Header("Golden Ratio Settings")] 
    public float goldenRatioRadius = 1f;
    public float goldenRatioAngle = 137.5f;

    [Header("Distance")] 
    public float formationDistance = 0.5f;
    public float repelAmount = 1f;
    
    [Header("Row Column Settings")] 
    public int columnSize = 3;

    public List<Transform> petTransforms = new List<Transform>();
    
    private float horizontal;
    private float vertical;
    private float up;
    public int triangleBase = 3;

    public Vector3 MoveVector { get; set; }


    private void Start()
    {
        petTransforms.Add(transform);
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (useUpwardMovement)
        {
            up = Input.GetKey(KeyCode.UpArrow) ? 1 : Input.GetKey(KeyCode.DownArrow) ? -1 : 0;
        }

        MoveVector = new Vector3(horizontal, up, vertical).normalized;
        transform.position += MoveVector * (moveSpeed * Time.deltaTime);

        if (MoveVector.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(MoveVector),
                Time.deltaTime * 10f);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PetMovement petMovement) && !petMovement.EnableFollow)
        {
            var row = petTransforms.Count / columnSize;
            var column = petTransforms.Count % columnSize;
            
            var centerOffset = new Vector3((columnSize - 1) * formationDistance * 0.5f, 0f,
                (columnSize - 1) * formationDistance * 0.5f);
            
            petMovement.FollowOffset = followOffset;
            followOffset = new Vector3(column * formationDistance, 0f, row * formationDistance) - centerOffset;
            
            petMovement.SetFollowEnable(petTransforms[^1]);
            petMovement.InitiliazeStrategy();
            petTransforms.Add(other.transform);
        }
    }

}
>>>>>>> Stashed changes
