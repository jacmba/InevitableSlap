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
  private Transform character;
  private Transform standPos;
  private bool started;

  // Start is called before the first frame update
  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
    animator = GetComponentInChildren<Animator>();
    kriss = target.GetComponent<KrissController>();
    audioSource = GetComponent<AudioSource>();

    character = transform.Find("Bill");
    standPos = transform.Find("StandPos");

    animator.SetBool("Sitting", true);

    started = false;

    GameController.OnGameStart += OnGameStart;
  }

  /// <summary>
  /// This function is called when the MonoBehaviour will be destroyed.
  /// </summary>
  void OnDestroy()
  {
    GameController.OnGameStart -= OnGameStart;
  }

  /// <summary>
  /// Update is called every frame, if the MonoBehaviour is enabled.
  /// </summary>
  void Update()
  {
    animator.SetBool("Walking", started && agent.enabled && !agent.isStopped);
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
      GameController.ReachRange();
      StartCoroutine(PrepareForSlap());
    }
  }

  void OnGameStart()
  {
    StartCoroutine(PrepareForAction());
  }

  IEnumerator PrepareForAction()
  {
    yield return new WaitForSeconds(30f);
    animator.SetBool("Sitting", false);
    character.position = standPos.position;
    yield return new WaitForSeconds(10f);
    agent.SetDestination(target.position);
    started = true;
  }

  IEnumerator PrepareForSlap()
  {
    yield return new WaitForSeconds(3f);
    animator.SetTrigger("Slap");
  }
}