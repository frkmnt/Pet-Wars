using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarantulaSkills : MonoBehaviour, SkillInterface {

    public Stats Stats { get; set; }

    public string Type { get; set; }

    private bool SkillFlag; // toggle true if used
    private int cooldown;
    public readonly string Description = "Poison - Normal attacks poison the target, dealing 10% of its current HP as damage for 3 turns.";

    PetLogger Tester;

    void Awake()
    {
        Stats = this.gameObject.GetComponent<Stats>();
        SkillFlag = true;
        cooldown = 0;
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
            Stats.subHealth(value);
            Tester.Log("Tarantula CurHealth: " + Stats.CurHealth);
            return true;
        }
        DamagePopupController.CreateHitPopup("Miss", gameObject.transform);
        //Tester.Log("Dodged!");
        return false;
    }


    public bool toggleAfraid()
    {
        return Stats.ToggleAfraid();
    }

    public bool ToggleDistracted()
    {
        return Stats.ToggleDistracted();
    }

    public bool togglePoisoned()
    {
        return Stats.togglePoisoned();
    }




    public bool turnAttack(GameObject o)
    {
        SkillInterface s = (SkillInterface)o.GetComponent(typeof(SkillInterface));

        if (Stats.canAttack())
        {
            bool b = s.subHealth(Stats.Damage);
            if (b)
            {
                if (!s.Stats.IsPoisoned) s.Stats.togglePoisoned();
                else s.Stats.PoisonCooldown = 0;
                return true;
            }
            
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
        return true;
    }

    public void startTurn()
    {
        if (Stats.PoisonCooldown > 3)
        {
            Stats.PoisonCooldown = 0;
            Stats.IsPoisoned = false;
            Tester.Log("The Tarantula is no longer poisoned!");
        }

        if (Stats.DistractedCooldown > 1)
        {
            Stats.DistractedCooldown = 0;
            Stats.IsDistracted = false;
            Tester.Log("The Tarantula is no longer distracted!");
        }

        if (Stats.IsAfraid)
        {
            float i = Random.value;
            if (i >= 0.5f)
            {
                Stats.IsAfraid = false;
                Tester.Log("The Tarantula surpassed its fear this turn!");
            }
        }
    }

    public void endTurn()
    {
        if (Stats.IsPoisoned)
        {
            Stats.PoisonCooldown++;
            Stats.PoisonDamage();
            Tester.Log("The Tarantula is poisoned! Its CurHP is " + Stats.CurHealth);
        }

        if (Stats.IsDistracted)
        {
            Tester.Log("The Tarantula is distracted!");
            Stats.DistractedCooldown++;
        }

        if (Stats.IsAfraid)
        {
            Tester.Log("The Tarantula is afraid!");
        }

        if (Stats.IsInvulnerable)
        {
            Tester.Log("The Tarantula is invulnerable!");
        }

        if (Stats.TauntTarget != null)
        {
            Stats.TauntTarget = null;
            Tester.Log("The Pet is no longer distracted by the Fly!");
        }
    }

	
}
