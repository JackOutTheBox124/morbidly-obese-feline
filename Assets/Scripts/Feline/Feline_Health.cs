using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feline_Health : MonoBehaviour
{
    private SpriteRenderer felineSpriteRenderer;
    private int health = 3;
    private float damageCooldownSeconds = 1.5f;
    private float lastTimeDamaged = 0;

    private Coroutine blinkDaFeline;
    // Start is called before the first frame update
    void Start()
    {
        felineSpriteRenderer = GetComponent<SpriteRenderer>();
        //lastTimeDamaged = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if((other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBullet")) && (lastTimeDamaged + damageCooldownSeconds < Time.time))
        {
            Debug.Log("hit!");
            health--;
            lastTimeDamaged = Time.time;

            if (blinkDaFeline != null)
            {
                StopCoroutine(blinkDaFeline);
            }

            blinkDaFeline = StartCoroutine(BlinkDaFeline());
        }
    }

    private IEnumerator BlinkDaFeline()
    {

        float initTime = Time.time;
        do {
            felineSpriteRenderer.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(0.1f);
            felineSpriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.1f);

        } while(Time.time < initTime + damageCooldownSeconds);
        felineSpriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        blinkDaFeline = null;
    }
}
