using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimeUtils
{
  public static int getAbsoluteTime(int minutes, int seconds)
  {
    return (minutes * 60) + seconds;
  }

  public static int[] getTime(int absolute)
  {
    int minutes = absolute / 60;
    int seconds = absolute % 60;

    return new int[] { minutes, seconds };
  }

  public static string getTimeString(int minutes, int seconds)
  {
    string format = "00";
    return minutes.ToString(format) + ":" + seconds.ToString(format);
  }
}