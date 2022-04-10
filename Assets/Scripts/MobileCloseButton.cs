using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MobileCloseButton : MonoBehaviour
{
  public void OnReturn()
  {
    SceneManager.LoadScene(0);
  }

  public void OnExit()
  {
    Application.Quit();
  }
}
