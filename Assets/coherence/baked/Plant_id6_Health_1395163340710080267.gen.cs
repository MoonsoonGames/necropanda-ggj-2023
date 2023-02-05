// Copyright (c) coherence ApS.
// For all coherence generated code, the coherence SDK license terms apply. See the license file in the coherence Package root folder for more information.

// <auto-generated>
// Generated file. DO NOT EDIT!
// </auto-generated>
namespace Coherence.Generated
{
	using Coherence.ProtocolDef;
	using Coherence.Serializer;
	using Coherence.SimulationFrame;
	using Coherence.Entity;
	using Coherence.Utils;
	using Coherence.Brook;
	using Coherence.Toolkit;
	using UnityEngine;

	public struct Plant_id6_Health_1395163340710080267 : ICoherenceComponentData
	{
		public int maxHealth;
		public int currentHealth;

		public override string ToString()
		{
			return $"Plant_id6_Health_1395163340710080267(maxHealth: {maxHealth}, currentHealth: {currentHealth})";
		}

		public uint GetComponentType() => Definition.InternalPlant_id6_Health_1395163340710080267;

		public const int order = 0;

		public int GetComponentOrder() => order;

		public AbsoluteSimulationFrame Frame;
	
		private static readonly int _maxHealth_Min = -2147483648;
		private static readonly int _maxHealth_Max = 2147483647;
		private static readonly int _currentHealth_Min = -2147483648;
		private static readonly int _currentHealth_Max = 2147483647;

		public void SetSimulationFrame(AbsoluteSimulationFrame frame)
		{
			Frame = frame;
		}

		public AbsoluteSimulationFrame GetSimulationFrame() => Frame;

		public ICoherenceComponentData MergeWith(ICoherenceComponentData data, uint mask)
		{
			var other = (Plant_id6_Health_1395163340710080267)data;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				maxHealth = other.maxHealth;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				currentHealth = other.currentHealth;
			}
			mask >>= 1;
			return this;
		}

		public static void Serialize(Plant_id6_Health_1395163340710080267 data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Utils.Bounds.Check(data.maxHealth, _maxHealth_Min, _maxHealth_Max, "Plant_id6_Health_1395163340710080267.maxHealth");
				data.maxHealth = Coherence.Utils.Bounds.Clamp(data.maxHealth, _maxHealth_Min, _maxHealth_Max);
				bitStream.WriteIntegerRange(data.maxHealth, 32, -2147483648);
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Utils.Bounds.Check(data.currentHealth, _currentHealth_Min, _currentHealth_Max, "Plant_id6_Health_1395163340710080267.currentHealth");
				data.currentHealth = Coherence.Utils.Bounds.Clamp(data.currentHealth, _currentHealth_Min, _currentHealth_Max);
				bitStream.WriteIntegerRange(data.currentHealth, 32, -2147483648);
			}
			mask >>= 1;
		}

		public static (Plant_id6_Health_1395163340710080267, uint, uint?) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new Plant_id6_Health_1395163340710080267();
	
			if (bitStream.ReadMask())
			{
				val.maxHealth = bitStream.ReadIntegerRange(32, -2147483648);
				mask |= 0b00000000000000000000000000000001;
			}
			if (bitStream.ReadMask())
			{
				val.currentHealth = bitStream.ReadIntegerRange(32, -2147483648);
				mask |= 0b00000000000000000000000000000010;
			}
			return (val, mask, null);
		}
		public static (Plant_id6_Health_1395163340710080267, uint, uint?) DeserializeArchetypePlant_d765de643a6a3a84481a9718beb599b3_Plant_id6_Health_1395163340710080267_LOD0(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new Plant_id6_Health_1395163340710080267();
			if (bitStream.ReadMask())
			{
				val.maxHealth = bitStream.ReadIntegerRange(32, -2147483648);
				mask |= 0b00000000000000000000000000000001;
			}
			if (bitStream.ReadMask())
			{
				val.currentHealth = bitStream.ReadIntegerRange(32, -2147483648);
				mask |= 0b00000000000000000000000000000010;
			}

			return (val, mask, 0);
		}

		/// <summary>
		/// Resets byte array references to the local array instance that is kept in the lastSentData.
		/// If the array content has changed but remains of same length, the new content is copied into the local array instance.
		/// If the array length has changed, the array is cloned and overwrites the local instance.
		/// If the array has not changed, the reference is reset to the local array instance.
		/// Otherwise, changes to other fields on the component might cause the local array instance reference to become permanently lost.
		/// </summary>
		public void ResetByteArrays(ICoherenceComponentData lastSent, uint mask)
		{
			var last = lastSent as Plant_id6_Health_1395163340710080267?;
	
		}
	}
}