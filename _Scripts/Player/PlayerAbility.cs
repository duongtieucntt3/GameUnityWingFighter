using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : DuongMonoBehaviour
{
    public virtual void Active(AbilitiesCode abilitiesCode)
    {
        Debug.Log("abilitiesCode: " + abilitiesCode.ToString());
    }
}
