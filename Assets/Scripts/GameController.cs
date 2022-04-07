using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
  public static event Action OnGameStart;
  public static event Action OnRangeReached;
  public static event Action OnSlapGiven;

  [SerializeField]
  private Text tipsText;

  [SerializeField]
  private Text timeText;

  private bool started;
  private bool finished;
  private float fSeconds;
  private int seconds;
  private int minutes;

  // Start is called before the first frame update
  void Start()
  {
    tipsText.text = "Meanwhile in the golden statue awards event... Kriss is making fun of Bill's big ears. Use the obstacle in the scenery to avoid Bill to reach Kriss for a Slap";
    started = false;
    finished = false;

    OnRangeReached += onRangeReached;
    OnSlapGiven += onSlapGiven;

    fSeconds = 0f;
    seconds = 0;
    minutes = 0;

    StartCoroutine(ClearText());
  }

  /// <summary>
  /// Update is called every frame, if the MonoBehaviour is enabled.
  /// </summary>
  void Update()
  {
    if (started && !finished)
    {
      fSeconds += Time.deltaTime;
      if (fSeconds > 60f)
      {
        fSeconds = 0f;
        minutes++;
      }

      seconds = Mathf.FloorToInt(fSeconds);
      string timeStr = getTimeString();
      timeText.text = timeStr;
    }

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
      tipsText.text = "Game Over ";
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
    finished = true;
    tipsText.text = "Oh no, here it comes...";
  }

  void onSlapGiven()
  {
    tipsText.text = "That slap just happened. Your delay time is " + getTimeString();
    StartCoroutine(ClearText());
  }

  private String getTimeString()
  {
    string format = "00";
    return minutes.ToString(format) + ":" + seconds.ToString(format);
  }
}