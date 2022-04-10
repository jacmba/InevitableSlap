using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileDisplayer : MonoBehaviour
{
  [SerializeField] private GameObject mobileUI;

  // Start is called before the first frame update
  void Start()
  {
    if (SystemInfo.deviceType == DeviceType.Handheld)
    {
      mobileUI.SetActive(true);
    }
  }
}
