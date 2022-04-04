using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrissController : MonoBehaviour
{
  private Animator animator;

  // Start is called before the first frame update
  void Start()
  {
    animator = GetComponentInChildren<Animator>();
    animator.SetBool("Waiting", true);
  }

  public void ReceiveSlap()
  {
    animator.SetTrigger("ReceiveSlap");
  }
}
