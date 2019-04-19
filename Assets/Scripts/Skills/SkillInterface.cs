using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SkillInterface {

    Stats Stats { get; set; }

     string Type { get; set; }


    void startTurn();

    void FindTester();

    void endTurn();

	bool turnAttack(GameObject o);

    bool turnSkill();

	bool subHealth(int value);
 


}
