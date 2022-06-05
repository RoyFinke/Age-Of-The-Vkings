using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    public AxeThrowController RoundTargets;
    bool CanHit = true;
    private void OnCollisionEnter(Collision collision)
    {
        if (CanHit == true)
        {
            gameObject.SetActive(false);
            RoundTargets.Targets++;
            CanHit = false;
        }


    }
}
