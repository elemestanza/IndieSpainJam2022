using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;
using DarkTonic.PoolBoss;

[ActionCategory("Pool Boss")]
[Tooltip("Returns whether a specified Game Object is spawned. If not, then it's available to spawn.")]

public class PoolBossItemIsSpawned : FsmStateAction
{
	[RequiredField]
	[Tooltip("Prefab To Ask About")]
	public FsmGameObject item;

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


	public override void Reset()
	{
		item = new FsmGameObject { UseVariable = true };
        boolVariable = new FsmBool { UseVariable = true };
		isTrue = null;
		isFalse = null;
		everyFrame = false;
	}

	public override void OnEnter()
	{
		boolVariable.Value = PoolBoss.IsSpawned(item.Value);

		Fsm.Event(boolVariable.Value ? isTrue : isFalse);

		if (!everyFrame)
		{
			Finish();
		}
	}

	public override void OnUpdate()
	{
        boolVariable.Value = PoolBoss.IsSpawned(item.Value);
		Fsm.Event(boolVariable.Value ? isTrue : isFalse);
	}
}