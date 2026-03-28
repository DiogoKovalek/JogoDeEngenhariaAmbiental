using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSmoke;
    private bool smokeRun = false;

    #region Smoke
    public void StartSmoke()
    {
        particleSmoke.Play();
        smokeRun = true;
    }

    public void StopSmoke()
    {
        particleSmoke.Stop();
        smokeRun = false;
    }
    public void UpdateSmokeDirection(Vector2 BIOxDirection)
    {
        particleSmoke.transform.up = - BIOxDirection;
    }

    public bool IsSmokeRun()
    {
        return smokeRun;
    }
    #endregion

    
}
