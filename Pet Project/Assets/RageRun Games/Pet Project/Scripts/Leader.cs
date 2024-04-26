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
