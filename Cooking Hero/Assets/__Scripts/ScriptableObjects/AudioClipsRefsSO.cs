using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioClips", menuName = "Audio Clips")]
public class AudioClipsRefsSO : ScriptableObject
{
    public AudioClip[] chop;
    public AudioClip[] deliveryFailed;
    public AudioClip[] deliverySuccess;
    public AudioClip[] footstep;
    public AudioClip[] objectDrop;
    public AudioClip[] objectPickup;
    public AudioClip stoveSizzle;
    public AudioClip[] trash;
    public AudioClip[] warning;
}
