using UnityEngine;
using System.Collections;

public class DualScreen : MonoBehaviour {
	
	public bool isDualScreen = true;
	private Camera audienceCam = null;

	void Start () {
		// Aquire and scale the cameras
		var audience = transform.FindChild ("CameraAudience");
		if (audience)
			audienceCam = audience.camera;
		OVRCameraController controller = gameObject.GetComponent<OVRCameraController>();
		OVRCamera[] cameras = gameObject.GetComponentsInChildren<OVRCamera>();
		for (int i = 0; i < cameras.Length; i++)
		{
			Rect r = new Rect(0.5f - (controller.ScaleRenderTarget * 0.5f) + ((cameras[i].RightEye) ? 0.5f : 0f), 
			                  0.5f - (controller.ScaleRenderTarget * 0.5f), 
			                  0.5f * controller.ScaleRenderTarget, 
			                  controller.ScaleRenderTarget);
			if (audienceCam)
				audienceCam.gameObject.SetActive(isDualScreen);
			if (isDualScreen) {
				if(audienceCam)
					audienceCam.rect = new Rect(0.5f, 0, 0.5f, 1f);

			}
			cameras[i].camera.rect = r;
		}
	}
}
