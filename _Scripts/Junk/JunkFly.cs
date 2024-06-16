using UnityEngine;

public class JunkFly : DuongMonoBehaviour
{

    public float fallSpeed = 5f; // T?c ?? r?i c?a thiên th?ch

    void Update()
    {
        // Di chuy?n thiên th?ch xu?ng d??i
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }


}

