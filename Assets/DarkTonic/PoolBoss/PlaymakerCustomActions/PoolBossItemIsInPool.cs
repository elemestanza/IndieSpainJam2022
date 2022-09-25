using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;
using DarkTonic.PoolBoss;

[ActionCategory("Pool Boss")]
[Tooltip("Return a boolean indicating if a Transform is pooled in Pool Boss")]
public class PoolBossItemIsInPool : FsmStateAction {

	[RequiredField]
    [Tooltip("Prefab To Ask About")]
	public FsmGameObject prefab = new FsmGameObject();
	
	[RequiredField]
	[Tooltip("The variable to store the result in.")]
	public FsmBool boolVariable = new FsmBool();
	
	public override void OnEnter() {
		if (prefab.Value == null) {
			Debug.LogError("You have not set the prefab object in the FSM in Game Object '" + this.Owner.transform.name + "'.");
			return;
		}
		
		boolVariable.Value = PoolBoss.PrefabIsInPool(prefab.Value.transform);
		
		Finish();
	}

	public override void Reset() {
		prefab = new FsmGameObject();
		boolVariable = new FsmBool();
	}
}
