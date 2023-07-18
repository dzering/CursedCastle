using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTargetMovement : MonoBehaviour
{
    [SerializeField] private Transform reference;

    private void LateUpdate() => 
        VerticalMove();

    private void VerticalMove()
    {
        float rad = reference.localRotation.eulerAngles.x * Mathf.Deg2Rad;
        float y = -Mathf.Tan(rad) / transform.localPosition.z;
        transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
    }
}
