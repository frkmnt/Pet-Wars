using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySkills : MonoBehaviour, SkillInterface
{
    public Stats Stats { get; set; }

    public string Type { get; set; }

    private bool SkillFlag; // toggle true if used
    private int cooldown;

    public readonly string Description = "Annoy - Distract an enemy pet for 1 turn.";

    PetLogger Tester;

    void Awake()
    {
        Stats = this.gameObject.GetComponent<Stats>();
        SkillFlag = false;
        cooldown = 0;
        Type = "enemy";
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
        float i = Random.Range(0, 101);

        if (i >= 90f)
        {
            Stats.subHealth(value);
            Tester.Log("Fly CurHealth: " + Stats.CurHealth);
            return true;
        }
        DamagePopupController.CreateHitPopup("Miss", gameObject.transform);
        Tester.Log("Dodged!");
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
            if (cooldown == 0 && SkillFlag)
            {
                s.Stats.TauntTarget = this.gameObject;
                SkillFlag = false;
                cooldown++;
                return true;
            }

            else
            {
                s.subHealth(Stats.Damage);
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
        if (SkillFlag && cooldown == 0) SkillFlag = false;
        else if (!SkillFlag && cooldown == 0) SkillFlag = true;

        if (SkillFlag)
        {
            Tester.Log(Description);
            Tester.Log("The skill is enabled!");
        }
        else Tester.Log("The skill is disabled!");

        return true;
    }


    public void startTurn()
    {
        SkillFlag = false;

        if (Stats.PoisonCooldown > 3)
        {
            Stats.PoisonCooldown = 0;
            Stats.IsPoisoned = false;
            Tester.Log("The Fly is no longer poisoned!");
        }

        if (Stats.DistractedCooldown > 1)
        {
            Stats.DistractedCooldown = 0;
            Stats.IsDistracted = false;
            Tester.Log("The Fly is no longer distracted!");
        }

        if (Stats.IsAfraid)
        {
            float i = Random.value;
            if (i >= 0.5f)
            {
                Stats.IsAfraid = false;
                Tester.Log("The Fly surpassed its fear this turn!");
            }
        }

        if (cooldown > 3)
        {
            cooldown = 0;
        }
    }

    public void endTurn()
    {
        if (cooldown >= 1) cooldown++;

        if (Stats.IsPoisoned)
        {
            Stats.PoisonCooldown++;
            Stats.PoisonDamage();
            Tester.Log("The Fly is poisoned! Its CurHP is " + Stats.CurHealth);
        }

        if (Stats.IsDistracted)
        {
            Tester.Log("The Fly is distracted!");
            Stats.DistractedCooldown++;
        }

        if (Stats.IsAfraid)
        {
            Tester.Log("The Fly is afraid!");
        }

        if (Stats.IsInvulnerable)
        {
            Tester.Log("The Fly is invulnerable!");
        }

        if (Stats.TauntTarget != null)
        {
            Stats.TauntTarget = null;
            Tester.Log("The Pet is no longer distracted by the Fly!");
        }

    }

    
}
