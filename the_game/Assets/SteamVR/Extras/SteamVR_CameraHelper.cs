using UnityEngine;
using System.Collections;

namespace Valve.VR
{
	public class SteamVR_CameraHelper : MonoBehaviour
	{
		void Start()
		{
			Debug.Log("Transform Tag is: " + gameObject.tag);
#if OPENVR_XR_API && UNITY_LEGACY_INPUT_HELPERS
			if (this.gameObject.GetComponent<UnityEngine.SpatialTracking.TrackedPoseDriver>() == null)
			{
				this.gameObject.AddComponent<UnityEngine.SpatialTracking.TrackedPoseDriver>();
			}
#endif
		}
	}
}