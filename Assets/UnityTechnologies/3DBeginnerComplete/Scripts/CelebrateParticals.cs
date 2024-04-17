using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CelebrateParticals : MonoBehaviour
{
    public GameObject player;
    public AudioSource happyAudio;
    
    public ParticleSystem particle;

    bool trigger;

    bool m_HasAudioPlayed;
   void OnTriggerStay (Collider other)
   {
    if (other.gameObject == player)
    {
        trigger = true;
    }
   }

   void OnTriggerExit (Collider other)
   {
        trigger = false;
    //Destroy(gameObject, sparks.main.duration);
   }
    // Update is called once per frame

    void Update ()
    {
        if (trigger)
        {
            particle.Play();
            Celebrate(happyAudio);
            print("Object hit");
        }
        else
        {
            Exited(happyAudio);
            print("Object exit");
        }
    }

    void Celebrate (AudioSource audioSource)
    {
        if(!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
        particle.Play();
    }

    void Exited(AudioSource audioSource)
    {
        audioSource.Pause();
        m_HasAudioPlayed = false;
        particle.Pause();
        particle.Clear();
    }
   
}
