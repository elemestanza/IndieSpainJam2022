using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;
using DarkTonic.PoolBoss;

[ActionCategory("Pool Boss")]
[Tooltip("Checks if all pool items in Pool Boss are ready to spawn")]

public class PoolBossIsReady : FsmStateAction
{
	[UIHint(UIHint.Variable)]
	[Tooltip("Optional: store the result in a boolean variable.")]
	public FsmBool boolVariable;

	[ActionSection("Events")]
	[Tooltip("Event to send if the Bool variable is True.")]
	public FsmEvent isTrue;

	[Tooltip("Event to send if the Bool variable is False.")]
	public FsmEvent isFalse;

	[Tooltip("Repeat every frame while the state is active.")]
	public bool everyFrame;

	public override void Reset() {
		boolVariable = new FsmBool { UseVariable = true };
		isTrue = null;
		isFalse = null;
		everyFrame = false;
	}

	public override void OnEnter()
	{
		boolVariable.Value = PoolBoss.IsReady;

		Fsm.Event(boolVariable.Value ? isTrue : isFalse);

		if (!everyFrame)
		{
			Finish();
		}
	}

	public override void OnUpdate()
	{
		boolVariable.Value = PoolBoss.IsReady;
		Fsm.Event(boolVariable.Value ? isTrue : isFalse);
	}
}