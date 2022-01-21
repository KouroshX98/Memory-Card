using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card List", menuName = "Card List", order = 1)]
public class CardList : ScriptableObject
{

    public Sprite[] cards;
    private int[] availability;

    private void OnValidate()
    {

        availability = new int[cards.Length];

        for(int j = 0;j < cards.Length;j++)
        {

            availability[j] = 2;

        }

    }

    public Sprite ReturnSprite()
    {

        int availableCardCount = 0;

        foreach(int a in availability)
        {

            if(a != 0)
            {

                availableCardCount++;

            }

        }

        int c = Random.Range(1, availableCardCount + 1);
        int counter = 0;

        for(int j = 0;j < availability.Length;j++)
        {

            if(availability[j] != 0)
            {

                counter++;
                if (counter == c)
                {
                    
                    availability[j]--;
                    return cards[j];

                }

            }

        }

        return null;

    }

}
