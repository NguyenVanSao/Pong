using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : Singleton<ObjectPooling>
{
    List<AudioSource> audioSource_pool = new List<AudioSource>();
    [SerializeField] AudioSource audioSource;


    public void playSound()
    {
        foreach(AudioSource A in audioSource_pool)
        {
            if(A.gameObject.activeSelf)
            {
                continue;
            }

            A.gameObject.SetActive(true);
            return;
        }

        AudioSource A2 = Instantiate<AudioSource>(audioSource, this.gameObject.transform.position, Quaternion.identity);
        audioSource_pool.Add(A2);
    }



}
