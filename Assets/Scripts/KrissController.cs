using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrissController : MonoBehaviour
{
  [SerializeField] private Transform bill;
  private Animator animator;

  // Start is called before the first frame update
  void Start()
  {
    animator = GetComponentInChildren<Animator>();
    animator.SetBool("Waiting", true);
  }

  /// <summary>
  /// Update is called every frame, if the MonoBehaviour is enabled.
  /// </summary>
  void Update()
  {
    transform.LookAt(bill, Vector3.up);
    Vector3 currentRot = transform.rotation.eulerAngles;
    currentRot.x = 0f;
    currentRot.z = 0f;
    transform.rotation = Quaternion.Euler(currentRot);
  }

  public void ReceiveSlap()
  {
    animator.SetTrigger("ReceiveSlap");
  }
}