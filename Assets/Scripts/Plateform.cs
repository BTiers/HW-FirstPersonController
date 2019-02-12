using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plateform : MonoBehaviour
{
    public static Plateform instance = null;
    public Text uiText;
    public int lifes = 3;

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        else
            instance = this;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            --lifes;
            uiText.text = "Lifes : " + lifes.ToString();
        }
        if (lifes == 0)
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
