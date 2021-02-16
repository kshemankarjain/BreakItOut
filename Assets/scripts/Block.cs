using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip BreakSound;
    level Level;
    GameStatus gamestatus;
    [SerializeField] GameObject blockSparklesVFX;
   
    [SerializeField] int timesHit;
    [SerializeField] Sprite[] hitSprite;

    public void Start()
    {
        gamestatus = FindObjectOfType<GameStatus>();

        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        Level = FindObjectOfType<level>();

        if (tag == "Breakable")
        {
            Level.CountBlocks();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }

    }

    private void HandleHit()
    {
        timesHit++;
        int MaxHit = hitSprite.Length + 1;
        if (timesHit >= MaxHit)
        {
            DestroyBlock();
        }else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteindex = timesHit - 1;
        if (hitSprite[spriteindex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprite[spriteindex];
        }else
        {
            Debug.LogError("block error is missing from the array ");
        }
    }

    public void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(BreakSound, Camera.main.transform.position);
        Destroy(gameObject);
        Level.BlocksDestroyed();
        gamestatus.AddToScore();
        TriggerSparklesVFX();
        
    }
    public void TriggerSparklesVFX()
    {
        GameObject sparkels = Instantiate(blockSparklesVFX,transform.position,transform.rotation);
        Destroy(sparkels, 1f);
    }
}
