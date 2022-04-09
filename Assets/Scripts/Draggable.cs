using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(Rigidbody))]
public class Draggable : MonoBehaviour
{
  private AudioSource audioSource;
  private Rigidbody body;
  private bool touching;

  // Start is called before the first frame update
  void Start()
  {
    touching = false;
    audioSource = GetComponent<AudioSource>();
    body = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if (touching)
    {
      Vector3 velocity = body.velocity;
      velocity.y = 0f;
      float magnitude = Mathf.Abs(velocity.magnitude);

      if (velocity.sqrMagnitude > 0f && !audioSource.isPlaying)
      {
        audioSource.Play();
      }
      else if (magnitude < 0f && audioSource.isPlaying)
      {
        audioSource.Stop();
      }
    }
    else if (audioSource.isPlaying)
    {
      audioSource.Stop();
    }
  }

  /// <summary>
  /// OnCollisionEnter is called when this collider/rigidbody has begun
  /// touching another rigidbody/collider.
  /// </summary>
  /// <param name="other">The Collision data associated with this collision.</param>
  void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.tag == "Player")
    {
      touching = true;
    }
  }

  /// <summary>
  /// OnCollisionExit is called when this collider/rigidbody has
  /// stopped touching another rigidbody/collider.
  /// </summary>
  /// <param name="other">The Collision data associated with this collision.</param>
  void OnCollisionExit(Collision other)
  {
    if (other.gameObject.tag == "Player")
    {
      touching = false;
    }
  }
}