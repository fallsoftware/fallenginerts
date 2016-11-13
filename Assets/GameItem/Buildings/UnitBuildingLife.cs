using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// Script Operating the life of the Production Building
/// </summary>
public class UnitBuildingLife : MonoBehaviour {
    public static int maxlife = 100;
    public static int RespawnCooldown = 200;
    public Sprite spriteAlive;
    public Sprite spriteDestroy;
    public int life = maxlife;
    public int cooldownBeforeRespawn = RespawnCooldown;
    public AudioClip BuildingDestroyedSound;
    void Start() {

        life = maxlife;
        cooldownBeforeRespawn = RespawnCooldown;
    }

	///checking for the Respawn if needed in the update
	void Update () {
        if (cooldownBeforeRespawn < RespawnCooldown)
        {
            cooldownBeforeRespawn++;
            if (cooldownBeforeRespawn == RespawnCooldown)
            {
                life = maxlife;
                this.gameObject.AddComponent<BoxCollider2D>();
                this.gameObject.GetComponent<BoxCollider2D>().isTrigger=true;
                (gameObject.GetComponent<SpriteRenderer>()).sprite = spriteAlive;
            }
        }
	}
    /// <summary>
    /// deals damage to the building
    /// </summary>
    /// <param name="damage">number of the damage dealt</param>
    public void HurtBuilding(int damage)
    {
        life -= damage;
        if (life < 0)
        {
            life = 0;
            cooldownBeforeRespawn = 0;
            Destroy(this.gameObject.GetComponent<BoxCollider2D>());
            (gameObject.GetComponent<SpriteRenderer>()).sprite = spriteDestroy;
            SoundManager.instance.RandomizeSfx(this.BuildingDestroyedSound);
        }
    }
}
