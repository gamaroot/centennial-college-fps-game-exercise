using game;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    private Ray m_shotRay;
    private AudioSource audioSource;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.Play();
            this.m_shotRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(this.m_shotRay, out RaycastHit hit, float.MaxValue))
            {
                Debug.Log(hit.collider.name);
                if(hit.collider.tag == "Zombie")
                {
                    hit.collider.GetComponent<Enemy>().Death();
                }
            }
        }
    }
}
