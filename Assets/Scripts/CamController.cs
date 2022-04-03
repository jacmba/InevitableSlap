using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
  [SerializeField]
  private Transform target;

  // Update is called once per frame
  void Update()
  {
    if (target != null)
    {
      transform.LookAt(target);
    }
  }
}