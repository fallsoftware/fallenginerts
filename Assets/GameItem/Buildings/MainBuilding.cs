using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;


class MainBuilding : MonoBehaviour 
{
    public Player player;
    public GameObject GameOverPanel;
    public GameObject GameOverLogoObject;
    public Sprite GameOverDefeat;
    public Sprite GameOverVictory;

    public void CheckDestoy()
    {
        if (this.player.reserveArmy.TotalUnit <= 0)
        {
            this.GameOver(this.player.tag);
        } 
    }

    private void GameOver(string playerTag) {
        Menu menu = this.GameOverPanel.GetComponent<Menu>();
        SoundManager.instance.RandomizeSfx(menu.MenuSfx);
        this.GameOverPanel.SetActive(true);
        Time.timeScale = 0f;

        Image gameOverLogo = this.GameOverLogoObject.GetComponent<Image>();

        if (gameOverLogo == null) return;

        gameOverLogo.sprite = this.getGameOverLogo(playerTag);
    }

    private Sprite getGameOverLogo(string playerTag) {
        if (playerTag == "Player") {
            return this.GameOverDefeat;
        }

        return this.GameOverVictory;
    }
}
