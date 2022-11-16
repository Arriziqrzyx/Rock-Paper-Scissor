using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player P1;
    public Player P2;
    public GameState State = GameState.ChooseAttack;
    public GameObject gameOverPanel;
    public TMP_Text winnerText;
    private Player damagePlayer;
    private Player winner;

    public enum GameState
    {
        ChooseAttack,
        Attacks,
        Damages,
        Draw,
        GameOver,
    }

    private void Start() {
        gameOverPanel.SetActive(false); 
    }

    private void Update()
    {
        switch (State)
        {
            case GameState.ChooseAttack:
                if(P1.AttackValue != null && P2.AttackValue != null)
                {
                    P1.AnimateAttack();
                    P2.AnimateAttack();
                    P1.isClickable(false);
                    P2.isClickable(false);
                    State = GameState.Attacks;
                }
                break;

            case GameState.Attacks:
                if(P1.IsAnimating() == false && P2.IsAnimating() == false)
                {
                    damagePlayer = GetDamagePlayer();
                    if(damagePlayer != null)
                    {
                        damagePlayer.AnimateDamage();
                        State = GameState.Damages;
                    }
                    else
                    {
                        P1.AnimateDraw();
                        P2.AnimateDraw();
                        State = GameState.Draw;
                    }
                }
                break;

            case GameState.Damages:
                if(P1.IsAnimating() == false && P2.IsAnimating() == false)
                {
                    if(damagePlayer == P1)
                    {
                        P1.ChangeHealth(-10);
                        P2.ChangeHealth(5);
                    }
                    else
                    {
                        P1.ChangeHealth(5);
                        P2.ChangeHealth(-10);
                    }
                    var winner = GetWinner();
                    if(winner == null)
                    {
                        ResetPlayers();
                        P1.isClickable(true);
                        P2.isClickable(true);
                        State = GameState.ChooseAttack;
                    }
                    else
                    {
                        gameOverPanel.SetActive(true);
                        winnerText.text = winner == P1 ?  "HOREEE PLAYER 1 MENANG" : "HOREEE PLAYER 2 MENANG";
                        ResetPlayers();
                        State = GameState.GameOver;
                    }
                }
                break;

            case GameState.Draw:
                if(P1.IsAnimating() == false && P2.IsAnimating() == false)
                {
                    ResetPlayers();
                    P2.isClickable(true);
                    P1.isClickable(true);
                    State = GameState.ChooseAttack;
                }
                break;
        }
    }

    private void ResetPlayers()
    {
        damagePlayer = null;
        P1.Reset();
        P2.Reset();
    }

    private Player GetDamagePlayer()
    {
        Attack? playerAtk1 = P1.AttackValue;
        Attack? playerAtk2 = P2.AttackValue;

        if(playerAtk1 == Attack.Rock && playerAtk2 == Attack.Paper)
        {
            return P1;
        }
        else if(playerAtk1 == Attack.Rock && playerAtk2 == Attack.Scissor)
        {
            return P2;
        }
        else if(playerAtk1 == Attack.Paper && playerAtk2 == Attack.Rock)
        {
            return P2;
        }
        else if(playerAtk1 == Attack.Paper && playerAtk2 == Attack.Scissor)
        {
            return P1;
        }
        else if(playerAtk1 == Attack.Scissor && playerAtk2 == Attack.Rock)
        {
            return P1;
        }
        else if(playerAtk1 == Attack.Scissor && playerAtk2 == Attack.Paper)
        {
            return P2;
        }

        return null;


    }
    
    private Player GetWinner()
    {
        if(P1.Health == 0)
        {
            return P2;
        }
        else if (P2.Health == 0)
        {
            return P1;
        }
        else
        {
            return null;
        }
    }
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
