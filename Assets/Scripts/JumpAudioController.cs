using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAudioController : MonoBehaviour
{
    public AudioClip jumpSound;

    AudioSource fuenteAudio;
    // Start is called before the first frame update
    void Start()
    {
        fuenteAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fuenteAudio.clip = jumpSound;
            fuenteAudio.Play();
        }
    }
}
