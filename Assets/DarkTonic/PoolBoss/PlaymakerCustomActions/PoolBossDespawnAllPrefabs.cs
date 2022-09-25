using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;
using DarkTonic.PoolBoss;

[ActionCategory("Pool Boss")]
[Tooltip("Despawn all prefabs")]
public class PoolBossDespawnAllPrefabs : FsmStateAction {
	public override void OnEnter() {
		// despawn!
		PoolBoss.DespawnAllPrefabs();
		
		Finish();
	}
	
	public override void Reset() {
	}
}
