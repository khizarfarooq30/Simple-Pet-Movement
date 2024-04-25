using System.Collections.Generic;
using UnityEngine;

public class Leader : MonoBehaviour
{
   [SerializeField] private float moveSpeed = 5f;

   private float horizontal;
   private float vertical;

   private List<Transform> followTransforms = new List<Transform>();

   private void Start()
   {
      followTransforms.Add(transform);
   }

   private void Update()
   {
      horizontal = Input.GetAxis("Horizontal");
      vertical = Input.GetAxis("Vertical");
      float up = Input.GetKey(KeyCode.UpArrow) ? 1 : Input.GetKey(KeyCode.DownArrow) ? -1 : 0;

      Vector3 moveVec = new Vector3(horizontal, up, vertical);
      transform.position += moveVec * (moveSpeed * Time.deltaTime);
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
