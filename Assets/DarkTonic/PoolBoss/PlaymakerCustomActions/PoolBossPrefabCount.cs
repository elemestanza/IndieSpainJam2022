using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;
using DarkTonic.PoolBoss;

[ActionCategory("Pool Boss")]
[Tooltip("Get total number of different prefabs set up in Pool Boss")]
public class PoolBossPrefabCount : FsmStateAction {
	[RequiredField]
	[Tooltip("The variable to store the value in.")]
	public FsmInt intVariable = new FsmInt();
	
	public override void OnEnter() {
		intVariable.Value = PoolBoss.PrefabCount;
		
		Finish();
	}

	public override void Reset() {
		intVariable = new FsmInt();
	}
}
