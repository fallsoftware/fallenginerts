using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// Script of gestion on the menu
/// </summary>
public class Menu : MonoBehaviour {
    public GameObject BattleGround;
    [HideInInspector] public MouseManager MouseManager;
    public bool ShutPanels = false;
    public AudioClip MenuSfx;
    /// <summary>
    /// On restart we reaload the scene
    /// </summary>
    public void Restart() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void HandleMenu() {
        this.initializeField();

        if (this.MouseManager != null && this.ShutPanels) {
            this.MouseManager.ResetSpriteRenderers();
            this.MouseManager.ShutAllPanels();
        }

        this.gameObject.SetActive(!this.gameObject.activeSelf);

        if (this.MenuSfx == null) return;

        SoundManager.instance.RandomizeSfx(this.MenuSfx);
    }
    /// <summary>
    /// handle of the timescale and sfx on the pause/unpause
    /// </summary>
    public void HandlePause() {
        this.gameObject.SetActive(!this.gameObject.activeSelf);

        if (this.gameObject.activeSelf) {
             Time.timeScale = 0f;
         } else {
             Time.timeScale = 1f;
         }

        if (this.MenuSfx == null) return;

        SoundManager.instance.RandomizeSfx(this.MenuSfx);
    }
    /// <summary>
    /// Initialization of the mousemanager
    /// </summary>
    private void initializeField() {
        if (this.BattleGround == null || this.MouseManager != null) return;

        this.MouseManager = this.BattleGround.GetComponent<MouseManager>();
    }
}