using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Block : MonoBehaviour
{
    //config params
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject partical_system;
    [SerializeField] Sprite[] hitSprites;
    //cached reference
    //state Varbles
    [SerializeField] int timesHit;

    [SerializeField] int Points = 83;

    public UnityEvent OnBreak;

    GameSession gameSession;
    public void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }
    [Obsolete]
    private void OnCollisionEnter2D(Collision2D collision)
    {    

        
        if (tag == "Breakable")
        {
            HandleHit();   
        }
       
        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(collision.gameObject);
        }
    }

    [Obsolete]
    private void HandleHit()
    {
       // Debug.Log("blockhit");
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (maxHits <= timesHit)
        {
            BreakBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    public void BreakBlock()
    {
        OnBreak?.Invoke();
        FindObjectOfType<GameSession>().AddToScore(Points);

        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position,gameSession.CurrentGameVolume );

        partical_system.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;

        Instantiate(partical_system, transform.position, transform.rotation);

        Destroy(gameObject);
    }

    [Obsolete]
    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }else
        {
            Debug.LogError("block spruite missing from array" + gameObject.name);
        }
    }
}
