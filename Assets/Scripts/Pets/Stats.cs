using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

    public int MaxHealth;
    public int CurHealth;
    public int Damage;
    public int Speed;

    public bool IsPoisoned;
    public int PoisonCooldown; // 3 turns
    public bool IsDistracted; //50% chance
    public int DistractedCooldown; // 2 turns
    public bool IsAfraid;
    public int AfraidCooldown;
    public bool IsInvulnerable;
    public bool IsAirborne;
    public bool IsDead;

    public bool IsMainPet;

    public float HouseScale;

    public GameObject TauntTarget;
    

    public Stats(int maxHealth, int damage, int speed, bool airborne)
    {
        MaxHealth = maxHealth;
        CurHealth = maxHealth;
        Damage = damage;
        Speed = speed;

        IsPoisoned = false;
        PoisonCooldown = 0;
        
        IsDistracted = false;
        DistractedCooldown = 0;

        IsAfraid = false; 
        IsDead = false;
        IsInvulnerable = false;
        IsAirborne = airborne;
        IsMainPet = false;

        TauntTarget = null;
        
        
    }

    public override string ToString()
    {
        return "Health: " + MaxHealth + "\nDamage: " + Damage + "\nSpeed: " + Speed;
    }







    public void runWhenAfraid () 
    {
        //call tile manager
        //walk one block away, depending on location
    }



    public bool canAttack ()
    {
        if (IsInvulnerable || IsAfraid || IsDistracted) return false;

        return true;
    }




    public void SetMainPet()
    {
        IsMainPet = true;
    }



    /// <summary>
    /// add a value to the current health
    /// </summary>
    /// <param name="value"></param>
    /// <returns>current health</returns>
    public int addHealth(int value)
    {
        if (value < 1) return CurHealth;

        if (CurHealth + value < MaxHealth)
        {
            CurHealth += value;
            return CurHealth;
        }
        else       
            CurHealth = this.MaxHealth;
            return this.CurHealth;
    }   


    /// <summary>
    /// subtract a value from the total health, return true if dead
    /// </summary>
    /// <param name="value"></param>
    /// <returns>current value</returns>
    public bool subHealth(int value)
    {
        if (IsAttackable()) 
        {
            if (CurHealth - value > 0)
            {
                CurHealth -= value;
                ShakeCamera();
                DamagePopupController.CreateHitPopup(value.ToString(), gameObject.transform);
                return false;
            }
            else
                CurHealth = 0;
            ToggleDead();
            return true;
        }

        return false;
        
    } 


    public void Clearbuffs()
    {
        IsPoisoned = false;
        PoisonCooldown = 0;
        
        IsDistracted = false;
        DistractedCooldown = 0;

        IsAfraid = false; 
        IsInvulnerable = false;

        TauntTarget = null;

    }

    public void BuffHero()
    {
        this.MaxHealth+=10;
        this.Damage+=10;
        fillHealth();

    }

    public void fillHealth ()
    {
        CurHealth = MaxHealth;
        IsDead = false;
        Clearbuffs();
    } 

    public bool togglePoisoned ()
    {
        if (IsPoisoned == false) return IsPoisoned = true;
        else return IsPoisoned = false;
    }

    public bool ToggleDistracted()
    {
        if (IsDistracted == false) return IsDistracted = true;
        else return IsDistracted = false;
    }

    public bool ToggleAfraid()
    {
        if (IsAfraid == false) return IsAfraid = true;
        else return IsAfraid = false;
    }

    public bool ToggleAirborne()
    {
        if (IsAirborne == false) return IsAirborne = true;
        else return IsAirborne = false;
    }

    public bool ToggleInvulnerable()
    {
        if (IsInvulnerable == false) return IsInvulnerable = true;
        else return IsInvulnerable = false;
    }

    public bool IsAttackable()
    {
        if (IsInvulnerable == false) return true;
        else return false;
    }



    public void ToggleDead()
    {
        this.IsDead = true;
    }


    public void Delete()
    {
        Destroy(this.gameObject);
    }

    public bool Pounce(int dmg)
    {
        if (!IsAirborne)
        {
            subHealth(dmg);
            Debug.Log("Pounce Successful! The target's CurHp is " + CurHealth);
            return true;
        }
        else 
        {
            float i = Random.value;

            if (i >= 0.3f)
            {
                subHealth(dmg);
                Debug.Log("Pounce Successful! The target's CurHp is " + CurHealth);
                return true;
            }
        }

        Debug.Log("Pounce Failed!");
        return false;
    }


    public bool Growl()
    {
        float i = Random.value;

        if (i >= 0.5f)
        {
            if (!IsAfraid) ToggleAfraid();
            return true;
        }
        return false;
    }

    public bool Distract()
    {
        float i = Random.value;
        if (i >= 0.1f)
        {
            if (!IsDistracted) ToggleDistracted();
            return true;
        }
        return false;
    }

    public void RegrowLimb()
    {
        float f = MaxHealth * 0.25f;
        addHealth((int)f);
    }

    public void PoisonDamage() 
    {
        float f = MaxHealth * 0.1f;
        subHealth((int)f);
        if (PoisonCooldown > 2) togglePoisoned();
    }


    private void ShakeCamera()
    {
        PetShake p = GetComponent<PetShake>();
        p.Shake();
    }

}
