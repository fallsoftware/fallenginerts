using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UnitBuildingLife : MonoBehaviour {
    public static int maxlife =100;
    public static int RespawnCooldown = 200;
    public Sprite spriteAlive;
    public Sprite spriteDestroy;
    public int life=maxlife;
    public int cooldownBeforeRespawn = RespawnCooldown;
    public AudioClip BuildingDestroyedSound;
    // Use this for initialization
    void Start () {
        life = maxlife;
        cooldownBeforeRespawn = RespawnCooldown;
	}
	
	// Update is called once per frame
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


                /*
                 *Remettre La boxCollider et rechanger le sprite 
                 */
            }
        }
	}
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
