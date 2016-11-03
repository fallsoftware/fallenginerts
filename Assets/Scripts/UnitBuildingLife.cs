using UnityEngine;
using System.Collections;

public class UnitBuildingLife : MonoBehaviour {
    public static int maxlife =100;
    public static int RespawnCooldown = 200;

    public int life;
    public int cooldownBeforeRespawn=0;
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
            /*
             * retirer boxCollider et changer le sprite
             */
        }
    }
}
