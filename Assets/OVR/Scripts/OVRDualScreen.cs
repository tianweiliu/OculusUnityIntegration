using UnityEngine;
using System.Collections;

public class OVRDualScreen : MonoBehaviour {
	
	public bool isDualScreen = true;
	public bool RiftOnRight = false;
	private Camera audienceCam = null;

	void Start () {
		// Aquire and scale the cameras
		var audience = transform.FindChild ("CameraAudience");
		if (audience)
			audienceCam = audience.camera;

		OVRCamera[] cameras = gameObject.GetComponentsInChildren<OVRCamera>();
		for (int i = 0; i < cameras.Length; i++)
		{
			if (isDualScreen) {
				if (RiftOnRight) {
					Rect r = new Rect(((cameras[i].name == "CameraRight") ? 0.75f : 0.5f), 0, 0.25f, 1f);
					cameras[i].camera.rect = r;
				}
				else {
					Rect r = new Rect(((cameras[i].name == "CameraRight") ? 0.25f : 0f), 0, 0.25f, 1f);
					cameras[i].camera.rect = r;
				}
			}
			else {
				Rect r = new Rect(((cameras[i].name == "CameraRight") ? 0.5f : 0f), 0, 0.5f, 1f);
				cameras[i].camera.rect = r;
			}
		}

		audienceCam.camera.enabled = isDualScreen;

		if (isDualScreen) {
			if(audienceCam) {
				if (RiftOnRight)
					audienceCam.rect = new Rect(0, 0, 0.5f, 1f);
				else
					audienceCam.rect = new Rect(0.5f, 0, 0.5f, 1f);
			}
		}
	}
}
