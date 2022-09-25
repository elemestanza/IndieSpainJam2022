using UnityEngine;
using HutongGames.PlayMaker;
using DarkTonic.PoolBoss;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory("Pool Boss")]
[Tooltip("Spawn one item from Pool Boss")]
public class PoolBossSpawn : FsmStateAction {
	public enum SpawnPositionMode {
		UseVector3, 
		UseThisObjectPosition,
		UseOtherObjectPosition
	}
	
	public enum RotationType {
        Identity,
		CustomEuler
	}
	
	[RequiredField]
    [Tooltip("Prefab To Spawn")]
	public FsmGameObject prefabToSpawn = new FsmGameObject();
	
	public SpawnPositionMode spawnPositionMode = SpawnPositionMode.UseVector3;

	public FsmVector3 spawnLocation = new FsmVector3(Vector3.zero);

	public FsmGameObject otherObjectForPosition = new FsmGameObject();

	[Tooltip("Choose 'Custom Euler' to enter a rotation")]
	public RotationType rotationType = RotationType.Identity;
	
	[Tooltip("Only used when 'Custom Euler' is chosen above for Rotation Type")] 
	public FsmVector3 eulerRotation = new FsmVector3(Vector3.zero);
	
	[Tooltip("The Game Object to parent the spawned object under (optional)")]
	public FsmGameObject parentGameObject = new FsmGameObject();
	
	[Tooltip("The variable to store the spawned object in.")]
	public FsmGameObject spawnedGameObject = new FsmGameObject();

	public override void OnEnter() {
		SpawnOne();
		
		Finish();
	}

	private void SpawnOne() {
		Transform prefab = null;

		if (prefabToSpawn.Value == null) {
			Debug.LogError("No prefab to spawn has been assigned in FSM in Game Object '" + this.Owner.transform.name + "'.");
			return;
		}
		
		prefab = prefabToSpawn.Value.transform;

		Quaternion spawnQuat = Quaternion.identity;
		if (rotationType == RotationType.CustomEuler) {
			spawnQuat = Quaternion.Euler(eulerRotation.Value);
		}

		Vector3 spawnPos = Vector3.zero;

		switch (spawnPositionMode) {
			case SpawnPositionMode.UseVector3:
				spawnPos = spawnLocation.Value;
				break;
			case SpawnPositionMode.UseThisObjectPosition:
				spawnPos = this.Owner.transform.position;
				break;
			case SpawnPositionMode.UseOtherObjectPosition:
				if (this.otherObjectForPosition.Value == null) {
					Debug.LogError("No game object specified for 'Other Object For Position'");
					return;	
				}
				
				spawnPos = this.otherObjectForPosition.Value.transform.position;
				break;
		}

		var spawned = PoolBoss.SpawnInPool(prefab, spawnPos, spawnQuat);
		if (spawned == null) {
			Debug.LogError("Could not spawn: " + prefabToSpawn.Value.name);
			return;
		}
		
		if (parentGameObject.Value != null) {
			spawned.parent = parentGameObject.Value.transform;
		}
		
		spawnedGameObject.Value = spawned.gameObject;
	}
	
	public override void Reset() {
		prefabToSpawn = new FsmGameObject();
		spawnLocation = new FsmVector3(Vector3.zero);
		eulerRotation = new FsmVector3(Vector3.zero);
		spawnedGameObject = new FsmGameObject();
		otherObjectForPosition = new FsmGameObject();
		spawnPositionMode = SpawnPositionMode.UseVector3;
		parentGameObject = new FsmGameObject();
	}
}
