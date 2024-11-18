using UnityEngine;

public class CarSfxHandler : MonoBehaviour
{
    [Header("Audio sources")]
    public AudioSource tireScreechingAudioSource;
    public AudioSource carHitAudioSource;
    public AudioSource engineAudioSource;
    public AudioSource sirenAudioSource;
    float desiredEnginePitch = 0.5f;
    float tireScreechPitch = 0.5f;

    CarController carController;

    private void Awake()
    {
        carController = GetComponentInParent<CarController>();
        tireScreechingAudioSource.volume = 0;
        engineAudioSource.volume = 0;
        carHitAudioSource.volume = 0;   
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        UpdateEngineSFX();
        UpdateTiresScreechingSFX();
        if (carController.GetVelocityMagnitude() > 1f)
        {
            sirenAudioSource.volume = 1;
        }
        else
        {
            sirenAudioSource.volume = 0;
        }

        
    }

    void UpdateEngineSFX()
    {
        float velocityMagnitude = carController.GetVelocityMagnitude();
        float desiredEngineVolume = velocityMagnitude * 0.05f;

        desiredEngineVolume = Mathf.Clamp(desiredEngineVolume, 0.2f, 1.0f);
        engineAudioSource.volume = Mathf.Lerp(engineAudioSource.volume, desiredEngineVolume, Time.deltaTime * 10);

        desiredEnginePitch = velocityMagnitude * 0.2f;
        desiredEnginePitch = Mathf.Clamp(desiredEnginePitch, 0.5f, 2f);
        engineAudioSource.pitch = Mathf.Lerp(engineAudioSource.pitch, desiredEnginePitch, Time.deltaTime * 1.5f);
    }

    void UpdateTiresScreechingSFX()
    {
        if (carController.IsTireScreeching(out float lateralVelocity, out bool isBreaking))
        {
            if (isBreaking)
            {
                tireScreechingAudioSource.volume = Mathf.Lerp(tireScreechingAudioSource.volume, 1f, Time.deltaTime * 10);
                tireScreechPitch = Mathf.Lerp(tireScreechPitch,0.5f,Time.deltaTime * 10);

            }
            else
            {
                tireScreechingAudioSource.volume = Mathf.Abs(lateralVelocity) * 0.05f;
                tireScreechPitch = Mathf.Abs(lateralVelocity) * 0.1f;
            }
        }
    }

}

