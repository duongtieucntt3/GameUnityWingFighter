using UnityEngine;

public class SetAspectRatio : MonoBehaviour
{
    void Start()
    {
        Camera.main.aspect = 9f / 16f; 
    }
}
