using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public List<AudioSource> audioSource;

    public void Play(int index)
    {
        audioSource[index].Play();
    }
}
