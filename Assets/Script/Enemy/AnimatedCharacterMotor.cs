using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedCharacterMotor : MonoBehaviour
{
    public float currentSpeed = 0.0f;

    private int walkingSpeedParam;
    private float walkingSpeedValue;
    Animator m_Animator;

    private Transform oldPosition;
    Vector3 lastPosition;
    float speed;

    private void Awake() {
        m_Animator = gameObject.GetComponent<Animator>();
        oldPosition = transform;
        walkingSpeedParam = Animator.StringToHash("walkingSpeed");
        lastPosition = transform.position;
        speed = 0f;
    }

    private void Update()
    {
        currentSpeed = Mathf.Lerp(speed, (transform.position - lastPosition).magnitude, 0.7f);
        currentSpeed = currentSpeed * 100;
        lastPosition = transform.position;

        m_Animator.SetFloat("walkingSpeed",currentSpeed);
        
        walkingSpeedValue = m_Animator.GetFloat("walkingSpeed");
        
    }
}
