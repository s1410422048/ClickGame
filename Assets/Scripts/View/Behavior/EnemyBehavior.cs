using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(HealthComponent))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(MeshFader))]
[RequireComponent(typeof(Animator))]//attribute屬性(不可在Inspector刪掉)
public class EnemyBehavior : MonoBehaviour {

    private Animator animator;
    private MeshFader meshFader;
    private AudioSource audioSource;
    private HealthComponent healthComponent;
    [SerializeField]
    public AudioClip hurtClip;
    [SerializeField]
    public AudioClip deadClip;

    public EnemyData enemyData;
    public bool IsDead
    {
        get
        {
            return healthComponent.IsOver;
        }
    }

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
      
        
    }

    [ContextMenu("Test Excute")]
    private void TestExcute()
    {
        StartCoroutine(Excute(enemyData));
    }
    public IEnumerator Excute(EnemyData enemyData)
    {
        healthComponent.Init(enemyData.health);
        while (IsDead == false)
        {
            yield return null;
        }
        animator.SetTrigger("die");
        audioSource.clip = deadClip;
        audioSource.Play();
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);
        yield return StartCoroutine(meshFader.FadeOut());
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
