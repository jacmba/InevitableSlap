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

  // Start is called before the first frame update
  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
    animator = GetComponentInChildren<Animator>();

    animator.SetBool("Walking", true);
  }

  // Update is called once per frame
  void Update()
  {
    agent.SetDestination(target.position);
  }
}
