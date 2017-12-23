using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(HealthComponent))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(MeshFader))]
[RequireComponent(typeof(Animator))]//attribute屬性
public class EnemyBehavior : MonoBehaviour {

    private Animator animator;
    private MeshFader meshFader;
    private AudioSource audioSource;
    private HealthComponent healthComponent;
    public AudioClip hurtClip;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        meshFader = GetComponent<MeshFader>();
        audioSource = GetComponent<AudioSource>();
        healthComponent = GetComponent<HealthComponent>();
       
    }
    // Use this for initialization
    private void OnEnable()
    {
        StartCoroutine(meshFader.FadeIn());
        healthComponent.Init(100);
        
    }

    private void DoDamage (int attack)
    {
        animator.SetTrigger("hurt");
        audioSource.clip = hurtClip;
        audioSource.Play();
        healthComponent.Hurt(attack);
    }

    private void Update()
    {
        if (healthComponent.IsOver)
            return;
        if (Input.GetButtonDown("Fire1"))
        {
            DoDamage(10);
        }
    }

}
