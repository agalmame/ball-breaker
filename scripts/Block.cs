using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject BlockExplosion;
    private Level level;
    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        TriggerExplosionVFX();
        DestroyBlock();
        

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
