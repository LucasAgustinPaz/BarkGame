using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToggleWinScreen : MonoBehaviour
{
    public TextMeshProUGUI winText;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        winText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.tag == "Win"){
            winText.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        
    }
}
