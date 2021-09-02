using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Sistema de controle de musica de background
public class SoundFxController : MonoBehaviour
{
    [SerializeField] AudioSource _soundFxController;

    public void PlaySoundFx(AudioClip audio) => _soundFxController.PlayOneShot(audio);
}