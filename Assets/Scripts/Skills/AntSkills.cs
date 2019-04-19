using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSkills : MonoBehaviour, SkillInterface
{
    public Stats Stats {get; set;}

    public string Type {get; set;}


    public readonly string Description = "Strength in numbers – For each 10 points of Damage the ants take, they lose 5 Attack Points.";

    PetLogger Tester;

    void Awake()
    {
        Stats = this.gameObject.GetComponent<Stats>();  
        Type = "passive";     
	}
	
    public void FindTester()
    {
        GameObject l = GameObject.Find("Logger");
        if (l) Tester = l.GetComponent<PetLogger>();
    }

    public void moveWhenAfraid()
    {
        throw new System.NotImplementedException();
    }



    public bool subHealth(int value)
    {

        float i = Random.value;

        if (i >= 0.3f)
        {
            if (Stats.CurHealth - value > 0)
            {
                Stats.subHealth(value);
                Tester.Log("Ant CurHealth: " + Stats.CurHealth);
                int dif = Stats.MaxHealth - Stats.CurHealth; 
                float f = dif / 10;
                int a = Mathf.FloorToInt(f);
                a *= 5;
                Stats.Damage = 100-a;
                Tester.Log("The ants' damage is: " + Stats.Damage);
                return true;
            }

            else
            {
                Stats.ToggleDead();
                return true;
            }
                
        }
        Tester.Log("Dodged!");
        DamagePopupController.CreateHitPopup("Miss", gameObject.transform);
        return false;
        
    }

    public bool ToggleAirborne()
    {
       return Stats.ToggleAirborne();
    }

    public bool ToggleDistracted()
    {
        return Stats.ToggleDistracted();
    }


    public bool ToggleInvulnerable()
    {
        return Stats.ToggleInvulnerable();
    }

    public bool togglePoisoned()
    {
        return Stats.togglePoisoned();
    }

    public bool toggleAfraid()
    {
        return Stats.ToggleAfraid();
    }






    public bool turnAttack(GameObject o)
    {
        SkillInterface s = (SkillInterface)o.GetComponent(typeof(SkillInterface));

        if (Stats.canAttack())
        {
            s.subHealth(Stats.Damage);
            return true;
        }

        return false;
    }

    public bool turnMove()
    {
        if (Stats.canAttack()) return true;
        else return false;
    }


    public bool turnSkill() 
    {
        Tester.Log(Description);
        return false;
    }


    public void startTurn()
    {
        if (Stats.PoisonCooldown > 3)
        {
            Stats.PoisonCooldown = 0;
            Stats.IsPoisoned = false;
            Tester.Log("The Ants are no longer poisoned!");
        }

        if (Stats.DistractedCooldown > 1)
        {
            Stats.DistractedCooldown = 0;
            Stats.IsDistracted = false;
            Tester.Log("The Ants are no longer distracted!");
        }

        if (Stats.IsAfraid)
        {
            float i = Random.value;
            if (i >= 0.5f)
            {
                Stats.IsAfraid = false;
                Tester.Log("The Ants surpassed their fear this turn!");
            }
        }
    }

    public void endTurn()
    {
        if (Stats.IsPoisoned)
        {
            Stats.PoisonCooldown++;
            Stats.PoisonDamage();
            Tester.Log("The Ants are poisoned! Their CurHP is " + Stats.CurHealth);
        }

        if (Stats.IsDistracted)
        {
            Tester.Log("The Ants are distracted!");
            Stats.DistractedCooldown++;
        }

        if (Stats.IsAfraid)
        {
            Tester.Log("The Ants are afraid!");
        }

        if (Stats.IsInvulnerable)
        {
            Tester.Log("The Ants are invulnerable!");
        }

        if (Stats.TauntTarget != null)
        {
            Stats.TauntTarget = null;
            Tester.Log("The Pet is no longer distracted by the Fly!");
        }
    }

    
}
