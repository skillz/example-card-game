using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PulseAnimator : MonoBehaviour
{
  public float pulseSpeed = 1f;
  public float pulseMagnitude = .05f;

  private Vector3 orignalScale;

  private void Start()
  {
    orignalScale = transform.localScale;
  }

  private void Update()
  {
    transform.localScale = orignalScale + Vector3.one * (Mathf.Sin(Time.realtimeSinceStartup * pulseSpeed) * pulseMagnitude);
  }
}
