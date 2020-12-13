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
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        s.value = health;
        t.text = System.String.Format("Health:   {0}/100",health);
        checkHealth();
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "SpaceStationSatellit" || collision.gameObject.name == "SpaceStationSatellit(Clone)")
        {
            health -= 10;
        }

        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy(Clone)" || collision.gameObject.tag == "enemy")
        {
            health -= 10;
        }
    }
}
