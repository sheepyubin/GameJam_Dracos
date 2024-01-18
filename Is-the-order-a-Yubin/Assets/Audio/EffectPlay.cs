using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class EffectPlay : MonoBehaviour
{
    public AudioClip EatFeed;
    public AudioClip EnemySkill;
    public AudioClip EnemyAttack;
    public AudioClip PlayerAttack;
    public AudioClip ButtonClick;
    public AudioSource audioSource;
    public float Setvolume;

    private void Awake()
    {
        Setvolume = 1.0f;
    }
    public void buttonClick()
    {
        audioSource.PlayOneShot(ButtonClick, Setvolume);
    }

    public void playerAttack()
    {
        audioSource.PlayOneShot(PlayerAttack, Setvolume);
    }
    public void enemyAttack()
    {
        audioSource.PlayOneShot(EnemyAttack, Setvolume);
    }

    public void enemySkill()
    {
        audioSource.PlayOneShot(EnemySkill, Setvolume);
    }
    public void eetFeed()
    {
        audioSource.PlayOneShot(EatFeed, Setvolume);
    }
}
