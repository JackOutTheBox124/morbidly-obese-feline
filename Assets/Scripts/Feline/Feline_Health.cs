using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Feline_Health : MonoBehaviour
{
    private SpriteRenderer felineSpriteRenderer;
    private int health = 3;
    private float damageCooldownSeconds = 1.5f;
    private float lastTimeDamaged = 0;

    private Coroutine blinkDaFeline;
    // Gets the sprite renderer component from the inspector
    void Start()
    {
        felineSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    //Checks if the cats healthis less than one each frame, and if so it destroys it
    void Update()
    {
        if(health < 1)
        {
            Destroy(gameObject);

            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    //Removes health from the cat, and gives it immunity frames
    private void OnTriggerEnter2D(Collider2D other) {
        if((other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBullet")) && (lastTimeDamaged + damageCooldownSeconds < Time.time))
        {
            Debug.Log(other.gameObject.name + "   " + other.gameObject.CompareTag("EnemyBullet"));
            health--;
            lastTimeDamaged = Time.time;

            if (blinkDaFeline != null)
            {
                StopCoroutine(blinkDaFeline);
            }

            blinkDaFeline = StartCoroutine(BlinkDaFeline());
        }
    }


    /// <summary>
    /// Make the cat's sprite flash between 0% and 100% transparency.<br/>
    /// The sprite will flash for <see cref="damageCooldownSeconds"/> seconds.<br/>
    /// </summary>
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
