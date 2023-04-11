using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CarEffects : MonoBehaviour
{
   
    public CarMovement carMovement;
    public Rigidbody rg;

    [Header("Break lights")]
    public GameObject breakLightLeft;
    public GameObject breakLightRight;
    public float breakLightsIntensity = 5f;
    public float normalLightsIntensity = 1f;
    
    
    [Header("Smoke effect")]
    public ParticleSystem smokeLeft;
    public ParticleSystem smokeRight;
    public float minSpeedToSmoke = 5f;
    
    
    [Header("Tire trails")]
    public TrailRenderer trailLeft;
    public TrailRenderer trailRight;
    public float minTurnForceToShowTrails = 0.4f;

    [Header("Turn wheels")]
    public Transform leftWheel;
    public Transform rightWheel;

    [Header("Sounds and sfx")]
    public AudioClip engineSfx;
    public float engineSfxVelocityPitchFactor = 0.25f;
    public float engineSfxBasePitch = 1f;
    public AudioClip[] collisionSfxs;

    // private vars
    private AudioSource audioSource;
    private Color breakColor;
    private float divide = 5f;
    private float minus = 1f;

    void Awake()
    {
        // init audio source for engine sfx
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = engineSfx;
        audioSource.volume = .5f;
        audioSource.loop = true;
        audioSource.spatialBlend = 1;
        audioSource.minDistance = 25;
        audioSource.spread = 360;
        breakLightLeft.SetActive(false);
        breakLightRight.SetActive(false);
        
        audioSource.Play();
    }

    void Update()
    {
        UpdateBrakeLightEffect();
        UpdateSkidEffect();
        //UpdateTurnWheelsEffect();
        UpdateEngineSfx();
        UpdateSmokeEffect();
}

    private void OnCollisionEnter(Collision collision)
    {
        PlayCollisionSfx(collision);
    }

    private void PlayCollisionSfx(Collision collision)
    {
        if (!rg || !audioSource || collision==null)
        {
            // Can't play collision sfx
            return;
        }
        audioSource.pitch = Random.Range(0.85f, 1f);
        // the more the collisison is big, the more the sound velocity
        audioSource.PlayOneShot(collisionSfxs[Random.Range(0, collisionSfxs.Length - 1)], 0.2f);
    }

    private void UpdateBrakeLightEffect()
    {
        if (!carMovement || !breakLightLeft || !breakLightRight)
        {
            // Can't play brake light effect
            return;
        }

        bool isSpeeding = carMovement.GetSpeed() < 0;
        if (isSpeeding)
        {
            breakLightLeft.SetActive(true);
            breakLightRight.SetActive(true);
        }
        else
        {
            breakLightLeft.SetActive(false);
            breakLightRight.SetActive(false);
        }
    }

    private void UpdateSkidEffect()
    {
        if (!carMovement || !trailLeft || !trailRight)
        {
            // Can't play skid effect
            return;
        }

        if (carMovement.input.x > 0 && carMovement.GetSpeed() > 0)
        {
            trailLeft.emitting = true;
            trailRight.emitting = true;
        }
        else
        {
            trailLeft.emitting = false;
            trailRight.emitting = false;
        }
        
        
        
    }

    private void UpdateTurnWheelsEffect()
    {
        if (!carMovement || !leftWheel || !rightWheel)
        {
            // Can't play turn wheels effect
            return;
        }
        float wheelRotation = 90f + carMovement.input.x * 30f;
        leftWheel.localRotation = Quaternion.Euler(leftWheel.localRotation.eulerAngles.x, wheelRotation, leftWheel.localRotation.eulerAngles.z);
        rightWheel.localRotation = Quaternion.Euler(rightWheel.localRotation.eulerAngles.x, wheelRotation, rightWheel.localRotation.eulerAngles.z);
    }

    private void UpdateEngineSfx()
    {
        if (!rg || !audioSource)
        {
            // Can't play engine sfx
            return;
        }

        if (carMovement.GetSpeed() > 0)
        {
            audioSource.mute = false;

        }
        else
        {
            audioSource.mute = true; 
        }
    }
    
    private void UpdateSmokeEffect()
    {
        if (!carMovement || !smokeLeft || !smokeRight)
        {
            // Can't play skid effect
            return;
        }

        bool isSpeeding = carMovement.GetSpeed() > minSpeedToSmoke;
        if (isSpeeding)
        {
            smokeLeft.Play();
            smokeRight.Play();
        }
        else
        {
            smokeLeft.Stop();
            smokeRight.Stop();
        }
    }
    
}
