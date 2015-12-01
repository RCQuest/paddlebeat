using UnityEngine;
using System.Collections;
using Rhythmify;
using System;
using System.Collections.Generic;

public class Brick : MonoBehaviour {

    public int brokenStage;
    public List<Sprite> variations;
    public List<Sprite> breaks;
    private int maxHp;
    public GameObject breakOverlay;
    private int scoreValue;
    public GameObject destroyEmitter;

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = variations[UnityEngine.Random.Range(0, variations.Count)];
        maxHp = brokenStage;
        scoreValue = maxHp * 1000;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            degrade();
        }
        else if (other.CompareTag("Health"))
        {
            damagePlayer(other.GetComponent<PlayerStats>());
        }
            
    }

    private void damagePlayer(PlayerStats player)
    {
        player.depleteLife();
        //damage animation here
        Destroy(this.gameObject);
    }

    public void degrade()
    {
        if(brokenStage > 0) brokenStage--;
        setBrokenSprite(brokenStage / maxHp);
    }

    public bool isBroken()
    {
        return brokenStage <= 0;
    }

    public void assertDestruction()
    {
        if(brokenStage <= 0)
        {
            FindObjectOfType<PlayerStats>().incrementScore(scoreValue);
            Instantiate(destroyEmitter,this.transform.position,this.transform.localRotation);
            Destroy(this.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
            assertDestruction();
    }

    private void setBrokenSprite(float percentBroken)
    {
        SpriteRenderer sr = breakOverlay.GetComponent<SpriteRenderer>();
        if(percentBroken<=1f)
            sr.sprite = breaks[(int)percentBroken*(breaks.Count-1)];
    }


}
