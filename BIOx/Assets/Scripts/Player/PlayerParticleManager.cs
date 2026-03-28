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
        /*
        Vector2 dir = - BIOxDirection;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        particleSmoke.transform.rotation = Quaternion.Euler(0,0,angle+270);
        */
        particleSmoke.transform.up = - BIOxDirection;
    }

    public bool IsSmokeRun()
    {
        return smokeRun;
    }
    #endregion

    
}
