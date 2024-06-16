using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 worldPosition;
    [SerializeField] protected float speed = 0.05f;
    [SerializeField] protected float xLimit = 3f;
    [SerializeField] protected float yLimit = 5f;


    void FixedUpdate()
    {
        this.worldPosition = InputManager.Instance.MouseWorldPos;
        this.worldPosition.z = 0;
        this.worldPosition.x = Mathf.Clamp(worldPosition.x, -xLimit, xLimit);
        this.worldPosition.y = Mathf.Clamp(worldPosition.y, -yLimit, yLimit);
        Vector3 newPos = Vector3.Lerp(transform.position, worldPosition, this.speed);
        
        transform.parent.position = newPos;

    }
}
