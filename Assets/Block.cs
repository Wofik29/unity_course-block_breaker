using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private Sprite[] hitSprites;
    [SerializeField] private GameObject VFXObject;

    [SerializeField] private int maxHit;
    private int currentHit;
    
    private Level level;
    private GameSession session;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        session = FindObjectOfType<GameSession>();
        level.IncrementBreakCount();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentHit++;
        if (currentHit >= maxHit)
            DestroyBlock();
        else {
            GetComponent<SpriteRenderer>().sprite = hitSprites[currentHit - 1];
        }
        
        GameObject VFX = Instantiate(VFXObject, transform.position, transform.rotation);
        Destroy(VFX, 1f);
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, transform.position);
        session.UpdateScope();
        Destroy(gameObject);
        level.DecrementBreakCount();
    }
}
