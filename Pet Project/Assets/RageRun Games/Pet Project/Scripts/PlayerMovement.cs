using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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

      Vector3 moveVec = new Vector3(horizontal, 0f, vertical);
      
      transform.position += moveVec * (moveSpeed * Time.deltaTime);
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.TryGetComponent(out PetMovement petMovement))
      {
         if (!petMovement.IsFollowingTarget())
         {
            followTransforms.Add(other.transform);
            petMovement.SetFollowTarget(followTransforms[^1]);
         }
      }
   }
}
