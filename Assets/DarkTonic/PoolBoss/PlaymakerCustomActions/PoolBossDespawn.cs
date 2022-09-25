using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;
using DarkTonic.PoolBoss;

[ActionCategory("Pool Boss")]
[Tooltip("Despawn any one item")]
public class PoolBossDespawn : FsmStateAction {
	private Transform trans = null;
	
    [RequiredField]
    [Tooltip("Object holding object to despawn")]
	public FsmOwnerDefault gameObject = new FsmOwnerDefault();
	
	public override void OnEnter() {
        if (gameObject != null) {
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go != null) {
                this.trans = go.transform;
            }
        }
		
		// despawn!
		PoolBoss.Despawn(this.trans);
		
		Finish();
	}
	
	public override void Reset() {
		gameObject = new FsmOwnerDefault();
	}
}
