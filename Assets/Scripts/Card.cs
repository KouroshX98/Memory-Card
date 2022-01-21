using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    public Sprite card;
    public Animator anim;

    void Start()
    {

        transform.GetComponentInChildren<SpriteRenderer>().sprite = card;
        anim = GetComponent<Animator>();

    }

    
    void Update()
    {
        


    }

    private void OnMouseDown()
    {

        FindObjectOfType<GameManager>().CardToBeTurned(this);

    }

}
