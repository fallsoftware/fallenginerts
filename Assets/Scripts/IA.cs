using UnityEngine;
using System;
using System.Collections;
/// <summary>
/// Script of Gestion Of the IA of the player2
/// </summary>
public class IA : MonoBehaviour {
    //State of the IA
    //Wood: buy minion for wood
    //Iron: buy minion for iron
    //Food: buy minion for food
    //sword: buy swordsman
    //bow: buy bowman
    //horse: buy horseman
    //send: send units
    enum State {WOOD,IRON,FOOD,SWORD,BOW,HORSE,SEND }
    public GameObject army;
    public Player player;
    public UnitBuildingLife building1;
    public UnitBuildingLife building2;
    public UnitBuildingLife building3;

    public Transform Lane1;
    public Transform Lane2;
    public Transform Lane3;
    private State state;
    /// <summary>
    /// Start the IA with a update of 3 seconds
    /// </summary>
    void Start () {
        state = State.WOOD;
        InvokeRepeating("ComputeIA",0, 3);
	}
    /// <summary>
    /// Computation of the IA with a VERY SIMPLE state machine
    /// </summary>
	private void ComputeIA()
    {
        switch(state){
            //On the state wood we buy minions for the wood,we then switch to a ressource needed or to buy swords
            case State.WOOD:
                {
                    player.BuyMinionWood(Math.Min(20,player.maxBuyableUnit(new Minion())));
                    if (player.minionFood.Count < 20)
                    {
                        state = State.FOOD;
                    }
                    else if (player.minionIron.Count < 20)
                    {
                        state = State.IRON;
                    }
                    else
                    {
                        state = State.SWORD;
                    }
                    break;
                }
            //On the state food we buy minions for the food,we then switch to a ressource needed or to buy swords
            case State.FOOD:
                {
                    player.BuyMinionFood(Math.Min(20, player.maxBuyableUnit(new Minion())));
                    if (player.minionIron.Count < 20)
                    {
                        state = State.IRON;
                    }
                    else
                    {
                        state = State.SWORD;
                    }
                    break;
                }
            //On the state iron we buy minions for the iron,we then switch to buy swords
            case State.IRON:
                {
                    player.BuyMinionIron(Math.Min(20, player.maxBuyableUnit(new Minion())));
                    state = State.SWORD;

                    break;
                }
            //On the state sword we buy swordsmans,we then switch to send troop if we can't buy more else we buy bowmans
            case State.SWORD:
                {
                    player.BuyUnit(player.maxBuyableUnit(new Swordsman()),new Swordsman());
                    if (player.population == 200)
                    {
                        state = State.SEND;
                    }
                    else
                    {
                        state = State.BOW;

                    }
                    break;
                }
            //On the state bow we buy bowmans,we then switch to send troop if we can't buy more else we buy horsemans
            case State.BOW:
                {
                    player.BuyUnit(player.maxBuyableUnit(new Bowman()), new Bowman());
                    if (player.population == 200)
                    {
                        state = State.SEND;
                    }
                    else
                    {
                        state = State.HORSE;

                    }
                    break;
                }
            //On the state horse we buy Horseman,we then switch to send troop
            case State.HORSE:
                {
                    player.BuyUnit(player.maxBuyableUnit(new Horseman()), new Horseman());
                    state = State.SEND;
                    break;
                }
            //On the state send we sends the units, half the reserve at a random lane or a lane with destroyed building
            //we then buy more minions if needed else we buy units
            case State.SEND:
                {
                    player.BuyMinionFood(player.maxBuyableUnit(new Minion()));
                    MovingArmy currentArmy = Instantiate(army).GetComponent<MovingArmy>();
                    currentArmy.player = player;
                    currentArmy.army = new Army(player);
                    Army currentRealArmy = currentArmy.army;
                    currentRealArmy.swordsmanCount = player.reserveArmy.swordsmanCount / 2;
                    currentRealArmy.horsemanCount = player.reserveArmy.horsemanCount / 2;
                    currentRealArmy.bowmanCount = player.reserveArmy.bowmanCount / 2;
                    if (building1.life == 0)
                    {
                        currentArmy.transform.position = Lane1.position;
                    }
                    else if (building2.life == 0)
                    {
                        currentArmy.transform.position = Lane2.position;
                    }
                    else if (building3.life == 0)
                    {
                        currentArmy.transform.position = Lane3.position;
                    }
                    else
                    {
                        switch ((int)Math.Round(UnityEngine.Random.value * 3 + 0.5))
                        {
                            case 1:
                                {
                                    currentArmy.transform.position = Lane1.position;
                                    break;
                                }
                            case 2:
                                {
                                    currentArmy.transform.position = Lane2.position;
                                    break;
                                }
                            case 3:
                                {
                                    currentArmy.transform.position = Lane3.position;
                                    break;
                                }
                        }
                    }
                    
                    player.reserveArmy.swordsmanCount -= currentRealArmy.swordsmanCount;
                    player.reserveArmy.bowmanCount -= currentRealArmy.bowmanCount;
                    player.reserveArmy.horsemanCount -= currentRealArmy.horsemanCount;
                    if (player.minionWood.Count < 20)
                    {
                        state = State.WOOD;
                    }
                    else if (player.minionFood.Count < 20)
                    {
                        state = State.FOOD;
                    }
                    else if (player.minionIron.Count < 20)
                    {
                        state = State.IRON;
                    }
                    else
                    {
                        if (player.reserveArmy.bowmanCount == 0)
                        {
                            state = State.BOW;
                        }
                        else if(player.reserveArmy.horsemanCount == 0)
                        {
                            state = State.HORSE;
                        }
                        else
                        {
                            state = State.SWORD;
                        }
                        
                    }
                    break;
                }
        }

    }
}
