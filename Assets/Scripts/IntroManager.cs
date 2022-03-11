using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip clickSound;

    private Coroutine clickSoundCoroutine;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound, 1);
    }

    public void QuitGame()
    {
        PlayClickSound();
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator SoundCDCoroutine()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Worked?");
    }
}

