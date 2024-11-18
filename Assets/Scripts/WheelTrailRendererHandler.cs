using UnityEngine;

public class WheelTrailRendererHandler : MonoBehaviour
{
    GameObject ambualnce;
    CarController carController;
    TrailRenderer trailRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        ambualnce = GameObject.FindGameObjectWithTag("ambulance");
        carController = ambualnce.GetComponent<CarController>();
        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.emitting = false;

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (carController.IsTireScreeching(out float lateralVelocity, out bool isBreaking))
        {
            trailRenderer.emitting = true;
        }
        else
        {
            trailRenderer.emitting = false;
        }
    }
}
