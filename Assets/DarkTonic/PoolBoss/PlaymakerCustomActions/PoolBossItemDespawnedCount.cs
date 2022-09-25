using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;
using DarkTonic.PoolBoss;

[ActionCategory("Pool Boss")]
[Tooltip("Get total number of a pooled item set up in Pool Boss, despawned copies")]
public class PoolBossItemDespawnedCount : FsmStateAction {
	
	[RequiredField]
    [Tooltip("Item To Ask About")]
	public FsmGameObject item = new FsmGameObject();
	
	[RequiredField]
	[Tooltip("The variable to store the value of the World Variable in.")]
	public FsmInt intVariable = new FsmInt();
	
	public override void OnEnter() {
		if (item.Value == null) {
			Debug.LogError("No item specified in FSM for '" + this.Owner.transform.name + "'.");
			return;
		}
		
		var itemInfo = PoolBoss.PoolItemInfoByName(item.Value.transform.name);
		if (itemInfo == null) {
			intVariable.Value = 0;
			return;
		}
		
		intVariable.Value = itemInfo.DespawnedClones.Count;
		
		Finish();
	}

	public override void Reset() {
		intVariable = new FsmInt();
	}
}
