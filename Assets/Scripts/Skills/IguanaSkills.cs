using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IguanaSkills : MonoBehaviour, SkillInterface
{
    
    public Stats Stats { get; set; }
    public string Type { get; set; }

    private bool SkillFlag; // toggle true if used
    private int cooldown;
    public readonly string Description = "Regrow Limb - Regenerate 25% of this pet's max health.";

    PetLogger Tester;

    void Awake()
    {
        Stats = this.gameObject.GetComponent<Stats>();
        SkillFlag = false;
        cooldown = 0;
        Type = "self";
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
            Tester.Log("Iguana CurHealth: " + Stats.CurHealth);
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
        if (cooldown == 0)
        {
            float f = Stats.MaxHealth * 0.25f;
            Stats.addHealth((int)f);
            Tester.Log(Description);
            Tester.Log("The Iguana Healed! Its CurHp is " + Stats.CurHealth);
            return true;
        }

        Tester.Log("The Iguana wasn't able to heal!");
        return false;    
    }


    public void startTurn()
    {
        SkillFlag = false;

        if (Stats.PoisonCooldown > 3)
        {
            Stats.PoisonCooldown = 0;
            Stats.IsPoisoned = false;
            Tester.Log("The Iguana is no longer poisoned!");
        }

        if (Stats.DistractedCooldown > 1)
        {
            Stats.DistractedCooldown = 0;
            Stats.IsDistracted = false;
            Tester.Log("The Iguana is no longer distracted!");
        }

        if (Stats.IsAfraid)
        {
            float i = Random.value;
            if (i >= 0.5f)
            {
                Stats.IsAfraid = false;
                Tester.Log("The Iguana surpassed its fear this turn!");
            }
        }

        if (cooldown > 1)
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
            Tester.Log("The Iguana is poisoned! Its CurHP is " + Stats.CurHealth);
        }

        if (Stats.IsDistracted)
        {
            Tester.Log("The Iguana is distracted!");
            Stats.DistractedCooldown++;
        }

        if (Stats.IsAfraid)
        {
            Tester.Log("The Iguana is afraid!");
        }

        if (Stats.IsInvulnerable)
        {
            Tester.Log("The Iguana is invulnerable!");
        }

        if (Stats.TauntTarget != null)
        {
            Stats.TauntTarget = null;
            Tester.Log("The Pet is no longer distracted by the Fly!");
        }
    }

}
