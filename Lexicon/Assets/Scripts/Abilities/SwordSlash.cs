[System.Serializable]

public class SwordSlash : BaseAbility {

	public SwordSlash ()
	{
		AbilityName = "Sword Slash";
		AbilityDescription = "A strong slash from wielder's sword";
		AbilityID = 2;
		AbilityPower = 20;
		AbilityCost = 10;
		AbilityStatusEffect = new BurnStatusEffect ();
		AbilityStatusEffects.Add (new BurnStatusEffect ());
		AbilityCritChance = 85;
		AbilityCritModifier = 1.2f;
	}
}
