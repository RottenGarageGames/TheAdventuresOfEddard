using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampSwitch : MonoBehaviour
{

    SpriteRenderer lampSprite;
    public Sprite unlitSprite;
    public Sprite litSprite;


    private Color lampColor;

    void Start()
    {

       lampSprite = gameObject.GetComponent<SpriteRenderer>();
         lampSprite.color = Random.ColorHSV(0.7f, .8f);
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            lampSprite.sprite = litSprite;

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            lampSprite.sprite = unlitSprite;
        }
    }
}
