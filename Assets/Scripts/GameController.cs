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

  [SerializeField] private Text tipsText;

  [SerializeField] private Text timeText;
  [SerializeField] private AudioSource bgMusic;
  private bool started;
  private bool finished;
  private float fSeconds;
  private int seconds;
  private int minutes;
  private int hiScore;

  // Start is called before the first frame update
  void Start()
  {
    bool musicOn = PlayerPrefs.GetInt("music_on", 1) == 1;
    if (!musicOn)
    {
      bgMusic.Stop();
    }

    hiScore = PlayerPrefs.GetInt("hi_score", -1);

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
      string timeStr = TimeUtils.getTimeString(minutes, seconds);
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
      int totalTime = TimeUtils.getAbsoluteTime(minutes, seconds);
      if (totalTime > hiScore)
      {
        PlayerPrefs.SetInt("hi_score", totalTime);
        PlayerPrefs.Save();
        string timeStr = TimeUtils.getTimeString(minutes, seconds);
        tipsText.text = "Congratulations!!! You set a new record ( " + timeStr + " )";
        yield return new WaitForSeconds(5);
      }

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
    tipsText.text = "That slap just happened. Your delay time is " + TimeUtils.getTimeString(minutes, seconds);
    StartCoroutine(ClearText());
  }
}