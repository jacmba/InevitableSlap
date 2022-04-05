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

  private AudioSource audioSource;

  // Start is called before the first frame update
  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
    animator = GetComponentInChildren<Animator>();
    kriss = target.GetComponent<KrissController>();
    audioSource = GetComponent<AudioSource>();

    GameController.OnGameStart += OnGameStart;
  }

  /// <summary>
  /// This function is called when the MonoBehaviour will be destroyed.
  /// </summary>
  void OnDestroy()
  {
    GameController.OnGameStart -= OnGameStart;
  }

  public void OnSlap()
  {
    audioSource.Play();
    kriss.ReceiveSlap();
    GameController.GiveSlap();
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
      GameController.ReachRange();
    }
  }

  void OnGameStart()
  {
    agent.SetDestination(target.position);
    animator.SetBool("Walking", true);
  }
}
