using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextFader : MonoBehaviour
{
  [SerializeField]
  private float fadeSpeed = 5f;
  private bool toRight;
  private Text text;
  private float alpha;
  // Start is called before the first frame update
  void Start()
  {
    toRight = false;
    alpha = 1f;
    text = GetComponent<Text>();
  }

  // Update is called once per frame
  void Update()
  {
    int coef = toRight ? 1 : -1;
    alpha += coef * fadeSpeed * Time.deltaTime;
    if (alpha >= 1f)
    {
      alpha = 1f;
      toRight = false;
    }
    else if (alpha <= 0f)
    {
      alpha = 0f;
      toRight = true;
    }
    text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);

    if (Input.GetKeyDown(KeyCode.Escape))
    {
      Application.Quit();
    }
    else if (Input.anyKeyDown)
    {
      SceneManager.LoadScene(1);
    }
  }
}
