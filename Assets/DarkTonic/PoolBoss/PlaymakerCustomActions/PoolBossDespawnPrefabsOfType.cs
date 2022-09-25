using DarkTonic.PoolBoss;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory("Pool Boss")]
[Tooltip("Despawn all prefabs of one type")]
public class PoolBossDespawnPrefabsOfType : FsmStateAction {
	private Transform trans = null;
	
    [RequiredField]
    [Tooltip("Object holding object to despawn")]
	public FsmOwnerDefault gameObject = new FsmOwnerDefault();
	
	public override void OnEnter() {
		if (this.trans == null) {
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			this.trans = go.transform;
		}
		
		// despawn!
		PoolBoss.DespawnAllOfPrefab(this.trans);
		
		Finish();
	}
	
	public override void Reset() {
		gameObject = new FsmOwnerDefault();
	}
}
