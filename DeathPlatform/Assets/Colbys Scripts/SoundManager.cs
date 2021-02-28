using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    public enum Sound
    {
        playerMove,
        playerToPlatform,
        playerJump,
        playerJump2,
        playerJump3,
        teleport,
        levelRestart,
        fireHittingPlatform,
        endLevelSound,
        titleMusic,
    }

    private static GameObject oneShotGameObject;

    private static AudioSource oneShotAudioSource;


    public static void PlaySound(Sound sound, Vector3 position)
    {
        GameObject soundGameObject = new GameObject("Sound");
        soundGameObject.transform.position = position;
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();

        audioSource.clip = GetAudioClip(sound);

        audioSource.maxDistance = 70f;
        audioSource.spatialBlend = 1f;
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        audioSource.dopplerLevel = 0f;


        audioSource.Play();

        Object.Destroy(soundGameObject, audioSource.clip.length);
    }


    public static void PlaySound(Sound sound)
    {
       if(oneShotGameObject == null)
        {
            oneShotGameObject = new GameObject("One shot sound");
            oneShotAudioSource = oneShotGameObject.AddComponent<AudioSource>();
        }
        oneShotAudioSource.PlayOneShot(GetAudioClip(sound));
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (SoundAssets.SoundAudioClip soundAudioClip in SoundAssets.i.soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound " + sound + " not found!");
        return null;

    }

}
