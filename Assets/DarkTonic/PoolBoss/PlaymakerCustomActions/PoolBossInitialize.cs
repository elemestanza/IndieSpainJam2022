using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;
using DarkTonic.PoolBoss;

[ActionCategory("Pool Boss")]
[Tooltip("Pool Boss initializes automatically by default. You can use this action instead if you uncheck 'Create Items On Start' in your PoolBoss settings.")]
[Note("Initializes PoolBoss")]

public class PoolBossInitialize : FsmStateAction
{
	public override void OnEnter()
	{
		DarkTonic.PoolBoss.PoolBoss.Initialize();
		Finish();
	}
}