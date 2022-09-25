using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory("Pool Boss")]
[Tooltip("Destroys a pool item, and all prefabs from it that are already spawned.\n\nYou should never call this except maybe during a new Scene load when you no longer need an item.")]

public class PoolBossDestroyPoolItem : FsmStateAction
{
	[RequiredField]
	[Tooltip("The GameObject to destroy in the Pool")]
	public FsmGameObject itemToDestroy;

	[Tooltip("Normally set to type 'Prefab'. If your project has the Addressables package installed and Pool Boss Addressables support is enabled on the Welcome Window, you can select Addressables as an option here too.")]
	public DarkTonic.PoolBoss.PoolBoss.PrefabSource sourceType;

	public override void Reset()
	{
		itemToDestroy = new FsmGameObject { UseVariable = true };
	}

	public override void OnEnter()
	{
		DarkTonic.PoolBoss.PoolBoss.DestroyPoolItem(itemToDestroy.Value.transform, sourceType);
		Finish();
	}
}