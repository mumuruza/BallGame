using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorActivator : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    public void Activate()
    {
        target.SetActive(true);
    }
    public void DisActivate()
    {
        target.SetActive(false);
    }
}
