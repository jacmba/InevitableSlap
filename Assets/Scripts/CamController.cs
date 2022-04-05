using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
  [SerializeField]
  private Transform target;
  [SerializeField]
  private Transform kriss;
  [SerializeField]
  private Transform finalSpot;

  /// <summary>
  /// Start is called on the frame when a script is enabled just before
  /// any of the Update methods is called the first time.
  /// </summary>
  void Start()
  {
    GameController.OnRangeReached += OnRangeReached;
  }

  /// <summary>
  /// This function is called when the MonoBehaviour will be destroyed.
  /// </summary>
  void OnDestroy()
  {
    GameController.OnRangeReached -= OnRangeReached;
  }

  // Update is called once per frame
  void Update()
  {
    if (target != null)
    {
      transform.LookAt(target);
    }
  }

  void OnRangeReached()
  {
    target = kriss;
    transform.position = finalSpot.position;
  }
}
