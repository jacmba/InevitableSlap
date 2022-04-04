using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BillNavigator : MonoBehaviour
{
  [SerializeField]
  private Transform target;

  private NavMeshAgent agent;
  private Animator animator;
  private KrissController kriss;

  // Start is called before the first frame update
  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
    animator = GetComponentInChildren<Animator>();
    kriss = target.GetComponent<KrissController>();

    agent.SetDestination(target.position);

    animator.SetBool("Walking", true);
  }

  public void OnSlap()
  {
    kriss.ReceiveSlap();
  }

  /// <summary>
  /// OnTriggerEnter is called when the Collider other enters the trigger.
  /// </summary>
  /// <param name="other">The other Collider involved in this collision.</param>
  void OnTriggerEnter(Collider other)
  {
    if (other.name == "Kriss")
    {
      agent.enabled = false;
      animator.SetTrigger("Slap");
    }
  }
}
