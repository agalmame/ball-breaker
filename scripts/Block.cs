using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject BlockExplosion;

    [SerializeField] int maxHits;
    int timeHit = 0;

    [SerializeField] Sprite[] sprits;

    private Level level;
    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        if (tag == "Breakable")
        {
            level = FindObjectOfType<Level>();
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timeHit++;
        if (timeHit >= maxHits)
        {
            TriggerExplosionVFX();
            DestroyBlock();
        }
        else
        {
            ShowNextSprite();

        }
    }

    private void ShowNextSprite()
    {
        if (sprits[timeHit - 1] != null)
        {
            GetComponent<SpriteRenderer>().sprite = sprits[timeHit - 1];
        }
        else
        {
            Debug.Log("sprite does not exicte");
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        
        FindObjectOfType<GameSession>().AddScore();
        Destroy(gameObject);
        
        level.BlockDestroyed();

    }

    private void TriggerExplosionVFX()
    {
        GameObject explosion = Instantiate(BlockExplosion, transform.position, transform.rotation);
    }
}
