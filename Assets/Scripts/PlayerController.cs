using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField]
  private float speed;

  [SerializeField]
  private float rotSpeed;

  private float moveX;
  private float moveY;
  private Rigidbody body;

  // Start is called before the first frame update
  void Start()
  {
    body = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void Update()
  {
    moveX = Input.GetAxis("Horizontal");
    moveY = Input.GetAxis("Vertical");

    transform.Rotate(Vector3.up * moveX * Time.deltaTime * rotSpeed);
  }

  /// <summary>
  /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
  /// </summary>
  void FixedUpdate()
  {
    transform.Translate(Vector3.forward * Time.deltaTime * moveY * speed);
  }
}