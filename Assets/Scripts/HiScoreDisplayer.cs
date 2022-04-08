using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiScoreDisplayer : MonoBehaviour
{
  [SerializeField] private Text scoreText;

  // Start is called before the first frame update
  void Start()
  {
    int hiScore = PlayerPrefs.GetInt("hi_score", -1);
    if (hiScore >= 0)
    {
      int[] timeParts = TimeUtils.getTime(hiScore);
      string timeStr = TimeUtils.getTimeString(timeParts[0], timeParts[1]);
      scoreText.text = "Best delay " + timeStr;
    }
  }
}