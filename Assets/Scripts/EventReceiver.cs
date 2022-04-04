using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventReceiver : MonoBehaviour
{
  BillNavigator father;

  // Start is called before the first frame update
  void Start()
  {
    father = transform.parent.GetComponent<BillNavigator>();
  }

  public void OnSlap()
  {
    father.OnSlap();
  }
}
