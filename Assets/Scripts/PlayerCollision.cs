using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    float delay = 1f;
    [SerializeField]
    AudioClip ExplosionSound;
    [SerializeField]
    AudioClip SucessSound;

    [SerializeField]
    ParticleSystem ExplosionParticles;
    [SerializeField]
    ParticleSystem SucessParticles;

    bool IsTransitioning = false;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision other) {
        if(IsTransitioning)
        {
            return;
        }
        switch(other.gameObject.tag) 
        {
            case "Friendly":
                break;
            case "Finish":
                action("LoadNextLevel", SucessSound, SucessParticles);
                break;
            default:
                action("RestartLevel",  ExplosionSound, ExplosionParticles);
                break;
        }
    }
    void action(string method, AudioClip audio, ParticleSystem particle)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audio);
        particle.Play();
        IsTransitioning = true;
        GetComponent<PlayerMovement>().enabled = false;
        Invoke(method, delay);
    }
    void LoadNextLevel()
    {
        SceneManager.LoadScene(
            (SceneManager.GetActiveScene().buildIndex + 1) %
            SceneManager.sceneCountInBuildSettings
        );
    }
    void RestartLevel()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}
