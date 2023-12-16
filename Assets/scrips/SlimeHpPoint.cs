using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlimeHpPoint : MonoBehaviour
{
    public int coins = 0;

    [SerializeField] TMP_Text coinsText;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;

            coinsText.text = "Coins: " + coins;
        }
    }


}
