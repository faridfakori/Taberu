using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControll : MonoBehaviour
{
    //can add audios in here
    public AudioClip Hurt;
    public AudioClip Jump;
    public AudioClip Pickup;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
