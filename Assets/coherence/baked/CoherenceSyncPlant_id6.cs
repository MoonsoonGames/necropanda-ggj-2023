// Copyright (c) coherence ApS.
// For all coherence generated code, the coherence SDK license terms apply. See the license file in the coherence Package root folder for more information.

// <auto-generated>
// Generated file. DO NOT EDIT!
// </auto-generated>
namespace Coherence.Generated
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using Coherence.Toolkit;
	using Coherence.Toolkit.Bindings;
	using Coherence.Entity;
	using Coherence.ProtocolDef;
	using Coherence.Brook;
	using Coherence.Toolkit.Bindings.ValueBindings;
	using Coherence.Toolkit.Bindings.TransformBindings;
	using Coherence.Connection;
	using Coherence.Log;
	using Logger = Coherence.Log.Logger;
	using UnityEngine.Scripting;

	public class Binding_d765de643a6a3a84481a9718beb599b3_e47fb28e_5877_4eca_9bd9_bc273f9b5944 : BoolBinding
	{
		private PlantObject CastedUnityComponent;		

		protected override void OnBindingCloned()
		{
			CastedUnityComponent = (PlantObject)UnityComponent;
		}
		public override string CoherenceComponentName => "Plant_id6_PlantObject_4428920011090734227";

		public override uint FieldMask => 0b00000000000000000000000000000001;

		public override bool Value
		{
			get => (bool)(System.Boolean)(CastedUnityComponent.enabled);
			set => CastedUnityComponent.enabled = (System.Boolean)(value);
		}

		protected override bool ReadComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Plant_id6_PlantObject_4428920011090734227)coherenceComponent;
			return update.enabled;
		}
		
		public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Plant_id6_PlantObject_4428920011090734227)coherenceComponent;
			update.enabled = Value;
			return update;
		}

		public override ICoherenceComponentData CreateComponentData()
		{
			return new Plant_id6_PlantObject_4428920011090734227();
		}
	}

	public class Binding_d765de643a6a3a84481a9718beb599b3_f9b527ea_dab0_4442_8e9c_e0bd68b3222f : Vector3Binding
	{
		private UnityEngine.BoxCollider CastedUnityComponent;		

		protected override void OnBindingCloned()
		{
			CastedUnityComponent = (UnityEngine.BoxCollider)UnityComponent;
		}
		public override string CoherenceComponentName => "Plant_id6_UnityEngine__char_46_BoxCollider_4428920011090734224";

		public override uint FieldMask => 0b00000000000000000000000000000001;

		public override Vector3 Value
		{
			get => (Vector3)(UnityEngine.Vector3)(CastedUnityComponent.size);
			set => CastedUnityComponent.size = (UnityEngine.Vector3)(value);
		}

		protected override Vector3 ReadComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Plant_id6_UnityEngine__char_46_BoxCollider_4428920011090734224)coherenceComponent;
			return update.size;
		}
		
		public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Plant_id6_UnityEngine__char_46_BoxCollider_4428920011090734224)coherenceComponent;
			update.size = Value;
			return update;
		}

		public override ICoherenceComponentData CreateComponentData()
		{
			return new Plant_id6_UnityEngine__char_46_BoxCollider_4428920011090734224();
		}
	}

	public class Binding_d765de643a6a3a84481a9718beb599b3_abb2a6a2_43e1_4a1f_bbed_c95cd8121e43 : IntBinding
	{
		private Health CastedUnityComponent;		

		protected override void OnBindingCloned()
		{
			CastedUnityComponent = (Health)UnityComponent;
		}
		public override string CoherenceComponentName => "Plant_id6_Health_1395163340710080267";

		public override uint FieldMask => 0b00000000000000000000000000000001;

		public override int Value
		{
			get => (int)(System.Int32)(CastedUnityComponent.maxHealth);
			set => CastedUnityComponent.maxHealth = (System.Int32)(value);
		}

		protected override int ReadComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Plant_id6_Health_1395163340710080267)coherenceComponent;
			return update.maxHealth;
		}
		
		public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Plant_id6_Health_1395163340710080267)coherenceComponent;
			update.maxHealth = Value;
			return update;
		}

		public override ICoherenceComponentData CreateComponentData()
		{
			return new Plant_id6_Health_1395163340710080267();
		}
	}

	public class Binding_d765de643a6a3a84481a9718beb599b3_1e3f1912_0ba7_4d72_b908_cb812bee5819 : IntBinding
	{
		private Health CastedUnityComponent;		

		protected override void OnBindingCloned()
		{
			CastedUnityComponent = (Health)UnityComponent;
		}
		public override string CoherenceComponentName => "Plant_id6_Health_1395163340710080267";

		public override uint FieldMask => 0b00000000000000000000000000000010;

		public override int Value
		{
			get => (int)(System.Int32)(CastedUnityComponent.currentHealth);
			set => CastedUnityComponent.currentHealth = (System.Int32)(value);
		}

		protected override int ReadComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Plant_id6_Health_1395163340710080267)coherenceComponent;
			return update.currentHealth;
		}
		
		public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Plant_id6_Health_1395163340710080267)coherenceComponent;
			update.currentHealth = Value;
			return update;
		}

		public override ICoherenceComponentData CreateComponentData()
		{
			return new Plant_id6_Health_1395163340710080267();
		}
	}

	public class Binding_d765de643a6a3a84481a9718beb599b3_fe8ed896_3a31_4971_9fab_0e18c9630b8d : DeepPositionBinding
	{
		private UnityEngine.Transform CastedUnityComponent;		

		protected override void OnBindingCloned()
		{
			CastedUnityComponent = (UnityEngine.Transform)UnityComponent;
		}
		public override string CoherenceComponentName => "Plant_id6_UnityEngine__char_46_Transform_4428920010626887975";

		public override uint FieldMask => 0b00000000000000000000000000000001;

		public override Vector3 Value
		{
			get => (Vector3)(UnityEngine.Vector3)(CastedUnityComponent.localPosition);
			set => CastedUnityComponent.localPosition = (UnityEngine.Vector3)(value);
		}

		protected override Vector3 ReadComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Plant_id6_UnityEngine__char_46_Transform_4428920010626887975)coherenceComponent;
			return update.position;
		}
		
		public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Plant_id6_UnityEngine__char_46_Transform_4428920010626887975)coherenceComponent;
			update.position = Value;
			return update;
		}

		public override ICoherenceComponentData CreateComponentData()
		{
			return new Plant_id6_UnityEngine__char_46_Transform_4428920010626887975();
		}
	}

	public class Binding_d765de643a6a3a84481a9718beb599b3_9bbb132f_d579_496e_806e_2ab0f2dab763 : DeepRotationBinding
	{
		private UnityEngine.Transform CastedUnityComponent;		

		protected override void OnBindingCloned()
		{
			CastedUnityComponent = (UnityEngine.Transform)UnityComponent;
		}
		public override string CoherenceComponentName => "Plant_id6_UnityEngine__char_46_Transform_4428920010626887975";

		public override uint FieldMask => 0b00000000000000000000000000000010;

		public override Quaternion Value
		{
			get => (Quaternion)(UnityEngine.Quaternion)(CastedUnityComponent.localRotation);
			set => CastedUnityComponent.localRotation = (UnityEngine.Quaternion)(value);
		}

		protected override Quaternion ReadComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Plant_id6_UnityEngine__char_46_Transform_4428920010626887975)coherenceComponent;
			return update.rotation;
		}
		
		public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Plant_id6_UnityEngine__char_46_Transform_4428920010626887975)coherenceComponent;
			update.rotation = Value;
			return update;
		}

		public override ICoherenceComponentData CreateComponentData()
		{
			return new Plant_id6_UnityEngine__char_46_Transform_4428920010626887975();
		}
	}

	public class Binding_d765de643a6a3a84481a9718beb599b3_265fc8e9_58d6_494e_a5c1_8c5192ea84c9 : DeepScaleBinding
	{
		private UnityEngine.Transform CastedUnityComponent;		

		protected override void OnBindingCloned()
		{
			CastedUnityComponent = (UnityEngine.Transform)UnityComponent;
		}
		public override string CoherenceComponentName => "Plant_id6_UnityEngine__char_46_Transform_4428920010626887975";

		public override uint FieldMask => 0b00000000000000000000000000000100;

		public override Vector3 Value
		{
			get => (Vector3)(UnityEngine.Vector3)(CastedUnityComponent.localScale);
			set => CastedUnityComponent.localScale = (UnityEngine.Vector3)(value);
		}

		protected override Vector3 ReadComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Plant_id6_UnityEngine__char_46_Transform_4428920010626887975)coherenceComponent;
			return update.localScale;
		}
		
		public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Plant_id6_UnityEngine__char_46_Transform_4428920010626887975)coherenceComponent;
			update.localScale = Value;
			return update;
		}

		public override ICoherenceComponentData CreateComponentData()
		{
			return new Plant_id6_UnityEngine__char_46_Transform_4428920010626887975();
		}
	}

	public class Binding_d765de643a6a3a84481a9718beb599b3_6b8ba6d1_0406_4031_9839_0ba74abd7172 : Vector2Binding
	{
		private UnityEngine.SpriteRenderer CastedUnityComponent;		

		protected override void OnBindingCloned()
		{
			CastedUnityComponent = (UnityEngine.SpriteRenderer)UnityComponent;
		}
		public override string CoherenceComponentName => "Plant_id6_UnityEngine__char_46_SpriteRenderer_4428920010626887974";

		public override uint FieldMask => 0b00000000000000000000000000000001;

		public override Vector2 Value
		{
			get => (Vector2)(UnityEngine.Vector2)(CastedUnityComponent.size);
			set => CastedUnityComponent.size = (UnityEngine.Vector2)(value);
		}

		protected override Vector2 ReadComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Plant_id6_UnityEngine__char_46_SpriteRenderer_4428920010626887974)coherenceComponent;
			return update.size;
		}
		
		public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Plant_id6_UnityEngine__char_46_SpriteRenderer_4428920010626887974)coherenceComponent;
			update.size = Value;
			return update;
		}

		public override ICoherenceComponentData CreateComponentData()
		{
			return new Plant_id6_UnityEngine__char_46_SpriteRenderer_4428920010626887974();
		}
	}


	[Preserve]
	[AddComponentMenu("coherence/Baked/Baked 'Plant' (auto assigned)")]
	[RequireComponent(typeof(CoherenceSync))]
	public class CoherenceSyncPlant_id6 : CoherenceSyncBaked
	{
		private CoherenceSync coherenceSync;
		private Logger logger;

		// Cached targets for commands
		private InputBuffer<Plant> inputBuffer;
		private Plant currentInput;
		private long lastAddedFrame = -1;
		private CoherenceInput coherenceInput;
		private long currentSimulationFrame => coherenceInput.CurrentSimulationFrame;

		private IClient client;
		private CoherenceMonoBridge monoBridge => coherenceSync.MonoBridge;

		protected void Awake()
		{
			coherenceSync = GetComponent<CoherenceSync>();
			coherenceSync.usingReflection = false;

			logger = coherenceSync.logger.With<CoherenceSyncPlant_id6>();
			coherenceInput = coherenceSync.Input;
			inputBuffer = new InputBuffer<Plant>(coherenceInput.InitialBufferSize, coherenceInput.InitialBufferDelay, coherenceInput.UseFixedSimulationFrames);
			if (coherenceSync.TryGetBindingByGuid("e47fb28e-5877-4eca-9bd9-bc273f9b5944", "enabled", out Binding InternalPlant_id6_PlantObject_4428920011090734227_Plant_id6_PlantObject_4428920011090734227_enabled))
			{
				var clone = new Binding_d765de643a6a3a84481a9718beb599b3_e47fb28e_5877_4eca_9bd9_bc273f9b5944();
				InternalPlant_id6_PlantObject_4428920011090734227_Plant_id6_PlantObject_4428920011090734227_enabled.CloneTo(clone);
				coherenceSync.Bindings[coherenceSync.Bindings.IndexOf(InternalPlant_id6_PlantObject_4428920011090734227_Plant_id6_PlantObject_4428920011090734227_enabled)] = clone;
			}
			else
			{
				logger.Error("Couldn't find binding (PlantObject).enabled");
			}
			if (coherenceSync.TryGetBindingByGuid("f9b527ea-dab0-4442-8e9c-e0bd68b3222f", "size", out Binding InternalPlant_id6_UnityEngine__char_46_BoxCollider_4428920011090734224_Plant_id6_UnityEngine__char_46_BoxCollider_4428920011090734224_size))
			{
				var clone = new Binding_d765de643a6a3a84481a9718beb599b3_f9b527ea_dab0_4442_8e9c_e0bd68b3222f();
				InternalPlant_id6_UnityEngine__char_46_BoxCollider_4428920011090734224_Plant_id6_UnityEngine__char_46_BoxCollider_4428920011090734224_size.CloneTo(clone);
				coherenceSync.Bindings[coherenceSync.Bindings.IndexOf(InternalPlant_id6_UnityEngine__char_46_BoxCollider_4428920011090734224_Plant_id6_UnityEngine__char_46_BoxCollider_4428920011090734224_size)] = clone;
			}
			else
			{
				logger.Error("Couldn't find binding (UnityEngine.BoxCollider).size");
			}
			if (coherenceSync.TryGetBindingByGuid("abb2a6a2-43e1-4a1f-bbed-c95cd8121e43", "maxHealth", out Binding InternalPlant_id6_Health_1395163340710080267_Plant_id6_Health_1395163340710080267_maxHealth))
			{
				var clone = new Binding_d765de643a6a3a84481a9718beb599b3_abb2a6a2_43e1_4a1f_bbed_c95cd8121e43();
				InternalPlant_id6_Health_1395163340710080267_Plant_id6_Health_1395163340710080267_maxHealth.CloneTo(clone);
				coherenceSync.Bindings[coherenceSync.Bindings.IndexOf(InternalPlant_id6_Health_1395163340710080267_Plant_id6_Health_1395163340710080267_maxHealth)] = clone;
			}
			else
			{
				logger.Error("Couldn't find binding (Health).maxHealth");
			}
			if (coherenceSync.TryGetBindingByGuid("1e3f1912-0ba7-4d72-b908-cb812bee5819", "currentHealth", out Binding InternalPlant_id6_Health_1395163340710080267_Plant_id6_Health_1395163340710080267_currentHealth))
			{
				var clone = new Binding_d765de643a6a3a84481a9718beb599b3_1e3f1912_0ba7_4d72_b908_cb812bee5819();
				InternalPlant_id6_Health_1395163340710080267_Plant_id6_Health_1395163340710080267_currentHealth.CloneTo(clone);
				coherenceSync.Bindings[coherenceSync.Bindings.IndexOf(InternalPlant_id6_Health_1395163340710080267_Plant_id6_Health_1395163340710080267_currentHealth)] = clone;
			}
			else
			{
				logger.Error("Couldn't find binding (Health).currentHealth");
			}
			if (coherenceSync.TryGetBindingByGuid("fe8ed896-3a31-4971-9fab-0e18c9630b8d", "position", out Binding InternalPlant_id6_UnityEngine__char_46_Transform_4428920010626887975_Plant_id6_UnityEngine__char_46_Transform_4428920010626887975_position))
			{
				var clone = new Binding_d765de643a6a3a84481a9718beb599b3_fe8ed896_3a31_4971_9fab_0e18c9630b8d();
				InternalPlant_id6_UnityEngine__char_46_Transform_4428920010626887975_Plant_id6_UnityEngine__char_46_Transform_4428920010626887975_position.CloneTo(clone);
				coherenceSync.Bindings[coherenceSync.Bindings.IndexOf(InternalPlant_id6_UnityEngine__char_46_Transform_4428920010626887975_Plant_id6_UnityEngine__char_46_Transform_4428920010626887975_position)] = clone;
			}
			else
			{
				logger.Error("Couldn't find binding (UnityEngine.Transform).position");
			}
			if (coherenceSync.TryGetBindingByGuid("9bbb132f-d579-496e-806e-2ab0f2dab763", "rotation", out Binding InternalPlant_id6_UnityEngine__char_46_Transform_4428920010626887975_Plant_id6_UnityEngine__char_46_Transform_4428920010626887975_rotation))
			{
				var clone = new Binding_d765de643a6a3a84481a9718beb599b3_9bbb132f_d579_496e_806e_2ab0f2dab763();
				InternalPlant_id6_UnityEngine__char_46_Transform_4428920010626887975_Plant_id6_UnityEngine__char_46_Transform_4428920010626887975_rotation.CloneTo(clone);
				coherenceSync.Bindings[coherenceSync.Bindings.IndexOf(InternalPlant_id6_UnityEngine__char_46_Transform_4428920010626887975_Plant_id6_UnityEngine__char_46_Transform_4428920010626887975_rotation)] = clone;
			}
			else
			{
				logger.Error("Couldn't find binding (UnityEngine.Transform).rotation");
			}
			if (coherenceSync.TryGetBindingByGuid("265fc8e9-58d6-494e-a5c1-8c5192ea84c9", "localScale", out Binding InternalPlant_id6_UnityEngine__char_46_Transform_4428920010626887975_Plant_id6_UnityEngine__char_46_Transform_4428920010626887975_localScale))
			{
				var clone = new Binding_d765de643a6a3a84481a9718beb599b3_265fc8e9_58d6_494e_a5c1_8c5192ea84c9();
				InternalPlant_id6_UnityEngine__char_46_Transform_4428920010626887975_Plant_id6_UnityEngine__char_46_Transform_4428920010626887975_localScale.CloneTo(clone);
				coherenceSync.Bindings[coherenceSync.Bindings.IndexOf(InternalPlant_id6_UnityEngine__char_46_Transform_4428920010626887975_Plant_id6_UnityEngine__char_46_Transform_4428920010626887975_localScale)] = clone;
			}
			else
			{
				logger.Error("Couldn't find binding (UnityEngine.Transform).localScale");
			}
			if (coherenceSync.TryGetBindingByGuid("6b8ba6d1-0406-4031-9839-0ba74abd7172", "size", out Binding InternalPlant_id6_UnityEngine__char_46_SpriteRenderer_4428920010626887974_Plant_id6_UnityEngine__char_46_SpriteRenderer_4428920010626887974_size))
			{
				var clone = new Binding_d765de643a6a3a84481a9718beb599b3_6b8ba6d1_0406_4031_9839_0ba74abd7172();
				InternalPlant_id6_UnityEngine__char_46_SpriteRenderer_4428920010626887974_Plant_id6_UnityEngine__char_46_SpriteRenderer_4428920010626887974_size.CloneTo(clone);
				coherenceSync.Bindings[coherenceSync.Bindings.IndexOf(InternalPlant_id6_UnityEngine__char_46_SpriteRenderer_4428920010626887974_Plant_id6_UnityEngine__char_46_SpriteRenderer_4428920010626887974_size)] = clone;
			}
			else
			{
				logger.Error("Couldn't find binding (UnityEngine.SpriteRenderer).size");
			}
		}

		public override List<ICoherenceComponentData> CreateEntity()
		{
			if (coherenceSync.UsesLODsAtRuntime && (Archetypes.IndexForName.TryGetValue(coherenceSync.Archetype.ArchetypeName, out int archetypeIndex)))
			{
				var components = new List<ICoherenceComponentData>()
				{
					new ArchetypeComponent
					{
						index = archetypeIndex
					}
				};

				return components;
			}
			else
			{
				logger.Warning($"Unable to find archetype {coherenceSync.Archetype.ArchetypeName} in dictionary. Please, bake manually (coherence > Bake)");
			}

			return null;
		}
		private void OnDestroy()
		{
			if (monoBridge != null)
			{
				monoBridge.OnLateFixedNetworkUpdate -= SendInputState;
			}
		}

		public override void Initialize(CoherenceSync sync, IClient client)
		{
			if (coherenceSync == null)
			{
				coherenceSync = sync;
			}
			this.client = client;
			sync.Input.internalSetButtonState = SetButtonState;
			sync.Input.internalSetButtonRangeState = SetButtonRangeState;
			sync.Input.internalSetAxisState = SetAxisState;
			sync.Input.internalSetStringState = SetStringState;
			sync.Input.internalGetButtonState = GetButtonState;
			sync.Input.internalGetButtonRangeState = GetButtonRangeState;
			sync.Input.internalGetAxisState = GetAxisState;
			sync.Input.internalGetStringState = GetStringState;
			sync.Input.internalRequestBuffer = () => inputBuffer;
			sync.Input.internalOnInputReceived += OnInput;
			sync.Input.internalRequestBuffer = () => inputBuffer;

			if (coherenceInput.UseFixedSimulationFrames)
			{
				sync.MonoBridge.OnLateFixedNetworkUpdate += SendInputState;
			}
		}

		public override void ReceiveCommand(IEntityCommand command)
		{
			switch(command)
			{
				default:
					logger.Warning($"[CoherenceSyncPlant_id6] Unhandled command: {command.GetType()}.");
					break;
			}
		}

		private void SetButtonState(string name, bool value)
		{
			switch(name)
			{
				default:
					logger.Error($"No input button of name: {name}");
					break;
			}
		}

		private void SetButtonRangeState(string name, float value)
		{
			switch(name)
			{
			default:
				logger.Error($"No input button range of name: {name}");
				break;
			}
		}

		private void SetAxisState(string name, Vector2 value)
		{
			switch(name)
			{
			default:
				logger.Error($"No input axis of name: {name}");
				break;
			}
		}

		private void SetStringState(string name, string value)
		{
			switch(name)
			{
				default:
					logger.Error($"No input button of name: {name}");
					break;
			}
		}

		public override void SendInputState()
		{
			if (!coherenceInput.IsProducer || !coherenceInput.IsReadyToProcessInputs || !coherenceInput.IsInputOwner)
			{
				return;
			}

			if (lastAddedFrame != currentSimulationFrame)
			{
				inputBuffer.AddInput(currentInput, currentSimulationFrame);
				lastAddedFrame = currentSimulationFrame;
			}

			while (inputBuffer.DequeueForSending(currentSimulationFrame, out long frameToSend, out Plant input, out bool differs))
			{
				coherenceInput.DebugOnInputSent(frameToSend, input);
				client.SendInput(input, frameToSend, coherenceSync.EntityID);
			}
		}

		private bool ShouldPollCurrentInput(long frame)
		{
			return coherenceInput.IsProducer && coherenceInput.Delay == 0 && frame == currentSimulationFrame;
		}

		private bool GetButtonState(string name, long? simulationFrame)
		{
			long frame = simulationFrame.GetValueOrDefault(currentSimulationFrame);

			switch(name)
			{
				default:
					logger.Error($"No input button of name: {name}");
					break;
			}

			return false;
		}

		private float GetButtonRangeState(string name, long? simulationFrame)
		{
			long frame = simulationFrame.GetValueOrDefault(currentSimulationFrame);

			switch(name)
			{
			default:
				logger.Error($"No input button range of name: {name}");
				break;
			}

			return 0f;
		}

		private Vector2 GetAxisState(string name, long? simulationFrame)
		{
			long frame = simulationFrame.GetValueOrDefault(currentSimulationFrame);

			switch(name)
			{
			default:
				logger.Error($"No input axis of name: {name}");
				break;
			}

			return Vector2.zero;
		}

		private string GetStringState(string name, long? simulationFrame)
		{
			long frame = simulationFrame.GetValueOrDefault(currentSimulationFrame);

			switch(name)
			{
				default:
					logger.Error($"No input button of name: {name}");
					break;
			}

			return null;
		}

		private void OnInput(IEntityInput entityInput, long frame)
		{
			var input = (Plant)entityInput;
			coherenceInput.DebugOnInputReceived(frame, entityInput);
			inputBuffer.ReceiveInput(input, frame);
		}
	}
}