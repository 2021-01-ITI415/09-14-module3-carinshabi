using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{
    public int ItemsCollected;
    public GameObject GameOverPanel;
    public Text StatsText;
    public int ItemsToCollect;
    public GameObject Rain;
    public ParticleSystem[] particles;
    public AudioSource[] audioSources;
    public AudioSource playerAudio;
    public AudioClip collect;
   /* private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            ItemsCollected++;
            Destroy(collision.gameObject);
        }
    }*/


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            playerAudio.clip = collect;
            playerAudio.Play();
            ItemsCollected++;
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "End")
        {
            GameOverPanel.SetActive(true);
            StatsText.text = "Items Collected Stats: " + ItemsCollected +"/" + ItemsToCollect ;

        }

        if(other.gameObject.tag == "Building")
        {
            Rain.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Building")
        {
            Rain.SetActive(true);
            
            foreach(ParticleSystem p in particles)
            {
                p.Play();
            }

            foreach(AudioSource audio in audioSources)
            {
                audio.Play();
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSources = Rain.GetComponents<AudioSource>();
        GameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       /* if (ItemsCollected >= WinScore)
        {
            
        }*/
    }
}
