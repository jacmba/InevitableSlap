using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
  public static event Action OnGameStart;
  public static event Action OnRangeReached;
  public static event Action OnSlapGiven;

  [SerializeField]
  private Text tipsText;

  private bool started;

  // Start is called before the first frame update
  void Start()
  {
    tipsText.text = "Meanwhile in the golden statue awards event... Kriss is making fun of Bill's big ears. Use the obstacle in the scenery to avoid Bill to reach Kriss for a Slap";
    started = false;

    OnRangeReached += onRangeReached;
    OnSlapGiven += onSlapGiven;

    StartCoroutine(ClearText());
  }

  /// <summary>
  /// Update is called every frame, if the MonoBehaviour is enabled.
  /// </summary>
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      SceneManager.LoadScene(0);
    }
  }

  /// <summary>
  /// This function is called when the MonoBehaviour will be destroyed.
  /// </summary>
  void OnDestroy()
  {
    OnRangeReached -= onRangeReached;
    OnSlapGiven -= onSlapGiven;
  }

  IEnumerator ClearText()
  {
    yield return new WaitForSeconds(5);
    tipsText.text = "";
    if (!started)
    {
      started = true;
      OnGameStart?.Invoke();
    }
    else
    {
      tipsText.text = "Game Over";
      yield return new WaitForSeconds(3);
      SceneManager.LoadScene(0);
    }
  }

  public static void ReachRange()
  {
    OnRangeReached?.Invoke();
  }

  public static void GiveSlap()
  {
    OnSlapGiven?.Invoke();
  }

  void onRangeReached()
  {
    tipsText.text = "Oh no, here it comes...";
  }

  void onSlapGiven()
  {
    tipsText.text = "You did your best, but that slap did happen";
    StartCoroutine(ClearText());
  }
}
