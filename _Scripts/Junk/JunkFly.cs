using UnityEngine;

public class JunkFly : DuongMonoBehaviour
{

    public float fallSpeed = 5f; // T?c ?? r?i c?a thi�n th?ch

    void Update()
    {
        // Di chuy?n thi�n th?ch xu?ng d??i
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }


}

