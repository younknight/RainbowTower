using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.0f;
    [SerializeField] Vector3 moveDirection = Vector3.zero;
    public float MoveSpeed => moveSpeed;
    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
    public void MoveTo(Vector3 dircetion)
    {
        moveDirection = dircetion;
    }
}
