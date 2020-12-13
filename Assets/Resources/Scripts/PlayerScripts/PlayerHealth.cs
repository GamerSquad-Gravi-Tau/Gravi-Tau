using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //public Text healthText;
    public int health;
    public Slider s;
    public Text t;

    public SpriteRenderer sp;
    public bool isDamaged = false;
    public bool blinkUp = true;
    public float damageTime = 0f;
    public float blinkTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        sp = transform.GetChild(0).GetComponent<SpriteRenderer>();
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        s.value = health;
        t.text = System.String.Format("Health:   {0}/100",health);
        checkHealth();

        if (isDamaged)
        {
            damageTime += Time.smoothDeltaTime;
            blinkTime += Time.smoothDeltaTime;
            if (blinkUp)
            {
                redUp();
            } else 
            {
                redDown();
            }
        }
        if (damageTime > 4f)
        {
            isDamaged = false;
            damageTime = 0f;
            Color curColor = sp.color;
            curColor.g = 1f;
            curColor.b = 0f;
        }
        if (blinkTime > 1f)
        {
            blinkUp = !blinkUp;
            blinkTime = 0f;
        }
    }

    private void checkHealth()
    {
        if (health < 1)
        {
            SceneManager.LoadScene(2);
        }

        if (health > 100)
        {
            health = 100;
        }

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        isDamaged = true;
        damageTime = 0f;
        blinkTime = 0f;
        Color curColor = sp.color;
        curColor.g = 1f;
        curColor.b = 0f;
        sp.color = curColor;
        blinkUp = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "SpaceStationSatellit" || collision.gameObject.name == "SpaceStationSatellit(Clone)")
        {
            health -= 10;
        }
    }

    private void redDown()
    {
        //PlayerMovement player = new PlayerMovement();
        //SpriteRenderer renderer = player.GetComponent<SpriteRenderer>();
        Color curColor = sp.color;
        curColor.g *= 1.02f;
        curColor.b *= 1.02f;
        sp.color = curColor;
    }

    private void redUp()
    {
        Color curColor = sp.color;
        curColor.g *= 0.985f;
        curColor.b *= 0.985f;
        sp.color = curColor;
    }
}