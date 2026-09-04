using UnityEngine;
using UnityEngine.InputSystem;

public class MosueTrail : MonoBehaviour
{

    public TrailRenderer mouseTrail;

    private void Start()
    {
        mouseTrail = GetComponent<TrailRenderer>();
        mouseTrail.emitting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current != null)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();

            mousePos.z = 10f;

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            transform.position = worldPos;

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                mouseTrail.Clear();
                mouseTrail.emitting = true;
            }
            else if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                mouseTrail.emitting = false;
            }
            
        }
    }
}
