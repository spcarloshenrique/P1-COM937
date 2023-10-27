using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Moeda : MonoBehaviour
{
    AudioSource _audioSource;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(_audioSource.clip, transform.position);
    }
}
