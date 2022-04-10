using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileInput : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
  public static float h;
  public static float v;

  [SerializeField] private float sensitivity = 10f;
  [SerializeField] private float maxDist = .5f;

  private Vector2 origin;
  private RectTransform rectTransform;

  // Start is called before the first frame update
  void Start()
  {
    rectTransform = GetComponent<RectTransform>();
    origin = rectTransform.pivot;
  }

  // Update is called once per frame
  void Update()
  {
    h = (origin.x - rectTransform.pivot.x) / maxDist;
    v = (origin.y - rectTransform.pivot.y) / maxDist;
  }

  public void OnPointerUp(PointerEventData data)
  {
    rectTransform.pivot = origin;
  }

  public void OnDrag(PointerEventData data)
  {
    Vector2 move = rectTransform.pivot + data.delta * sensitivity * Time.deltaTime * -1;
    float dist = Vector2.Distance(move, origin);
    if (dist <= maxDist)
    {
      rectTransform.pivot = move;
    }
  }

  public void OnPointerDown(PointerEventData data)
  {
    OnDrag(data);
  }
}
