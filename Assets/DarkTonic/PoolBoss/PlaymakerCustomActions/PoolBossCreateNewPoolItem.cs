using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;
using System;

[ActionCategory("Pool Boss")]
[Tooltip("Creates a new Item in Pool Boss at runtime. Useful if you don't want to instantiate all prefabs on Start.")]

public class PoolBossCreateNewPoolItem : FsmStateAction
{
	[RequiredField]
	[Tooltip("The GameObject to add to the Pool")]
	public FsmGameObject itemToAdd;

	[Tooltip("Normally set to type 'Prefab'. If your project has the Addressables Package installed and Pool Boss Addressables Support is enabled on the Welcome Window, you can select Addressables as an option here too.")]
	public DarkTonic.PoolBoss.PoolBoss.PrefabSource sourceType;

	[RequiredField]
	[Tooltip("The Category Name of the item to be added")]
	public FsmString categoryName;

	[Tooltip("The number of instances to preload")]
	public FsmInt preloadQty;

	[Tooltip("Activate this to enable the option to instantiate more")]
	public FsmBool canInstantiateMore;

	[Tooltip("The Item Limit if Can Instantiate More is True")]
	public FsmInt hardLimit;

	[Tooltip("Activate Log messages during spawn and despawn")]
	public FsmBool logMessage;

	public override void Reset()
	{
		itemToAdd = new FsmGameObject { UseVariable = true };
		categoryName = null;
		preloadQty = 0;
		canInstantiateMore = false;
		hardLimit = 10;
		logMessage = false;
	}

	public override void OnEnter()
	{
		DarkTonic.PoolBoss.PoolBoss.CreateNewPoolItem(itemToAdd.Value.transform, preloadQty.Value, canInstantiateMore.Value, hardLimit.Value, logMessage.Value, categoryName.Value, sourceType);
		Finish();
	}
}