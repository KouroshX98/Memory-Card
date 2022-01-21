using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public CardList cards;
    public Card card;
    public Animator endScreen;
    public Card first, second;
    public Text scoreText;
    public Text timeText;

    private enum GameState { state0, state1, state2 };
    private GameState gameState;
    private Color green, red;
    private bool enable = true;
    private bool finished;
    private float startTime = 0;
    private int score = 0;

    private void Start()
    {

        for (int j = 0; j < cards.cards.Length * 2; j++)
        {

            Transform a = Instantiate(card).gameObject.transform;
            a.position = new Vector3(-13.5f + (j % 4) * 9, 7.5f - (j / 4) * 5, 0);
            a.GetComponent<Card>().card = cards.ReturnSprite();

        }
        startTime = Time.time;
        green = new Color(0f / 255f, 255f / 255f, 111f / 255f);
        red = new Color(255f / 255f, 0f / 255f, 88f / 255f);

    }

    private void Update()
    {
        switch (gameState)
        {

            case GameState.state0:
                {

                    timeText.text = ((int)(Time.time - startTime)).ToString();

                    if (((int)(Time.time - startTime)) == 60)
                    {

                        gameState = GameState.state1;

                    }

                    if (enable && first != null && second != null)
                    {

                        if (first.card == second.card)
                        {

                            first.gameObject.SetActive(false);
                            second.gameObject.SetActive(false);

                            first = null;
                            second = null;
                            score += 10;
                            scoreText.text = score.ToString();
                            if (score == 80)
                            {

                                gameState = GameState.state1;

                            }

                        }
                        else
                        {

                            first.anim.SetBool("Turninverse", false);
                            first.anim.SetTrigger("Turn");
                            second.anim.SetBool("Turninverse", true);
                            second.anim.SetTrigger("Turn");
                            first = null;
                            second = null;

                        }

                    }
                    break;

                }
            case GameState.state1:
                {

                    endScreen.SetTrigger("Finish");
                    enable = false;
                    Text txt = endScreen.GetComponentInChildren<Text>();
                    if (score == 80)
                    {

                        txt.text = "You Won!\n=)";
                        txt.color = green;

                    }
                    else
                    {

                        txt.text = "You Lost!\n=(";
                        txt.color = red;

                    }

                    gameState = GameState.state2;

                    break;

                }
            case GameState.state2:
                {

                    break;

                }



        }

    }

    public void CardToBeTurned(Card a)
    {

        if (enable)
        {

            if (first == null)
            {

                a.anim.SetBool("Turninverse", false);
                a.anim.SetTrigger("Turn");
                StartCoroutine(DelayCardTurn(a));
                first = a;
                return;

            }
            if (second == null)
            {

                a.anim.SetBool("Turninverse", false);
                a.anim.SetTrigger("Turn");
                StartCoroutine(DelayCardTurn(a));
                second = a;
                return;

            }

        }

    }

    private IEnumerator DelayCardTurn(Card a)
    {

        enable = false;
        yield return new WaitForSeconds(0.5f);
        enable = true;

    }

}
