using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
  [SerializeField] Toggle musicToggle;
  [SerializeField] AudioSource bgMusic;

  // Start is called before the first frame update
  void Start()
  {
    bool musicOn = PlayerPrefs.GetInt("music_on", 1) == 1;
    if (!musicOn)
    {
      bgMusic.Stop();
      musicToggle.isOn = false;
    }
  }

  // Update is called once per frame
  void Update() { }

  public void clickPlay()
  {
    SceneManager.LoadScene(1);
  }

  public void toggleMusic()
  {
    if (musicToggle.isOn)
    {
      bgMusic.Play();
      PlayerPrefs.SetInt("music_on", 1);
    }
    else
    {
      bgMusic.Stop();
      PlayerPrefs.SetInt("music_on", 0);
    }

    PlayerPrefs.Save();
  }
}