using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    private Ray m_shotRay;

    private void Update()
    {
        if (Input.GetMouseButtonDown((int)MouseButton.Left))
        {
            this.m_shotRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(this.m_shotRay, out RaycastHit hit, float.MaxValue))
            {
                Debug.Log(hit.collider.name);
            }
        }
    }
}
