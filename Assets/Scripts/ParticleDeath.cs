using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDeath : MonoBehaviour
{
    [SerializeField] private int TimeBeforeDeath;
    void Start()
    {
        Destroy(transform.gameObject, TimeBeforeDeath);
    }

}
