using UnityEngine;

public class MouseLook : MonoBehaviour {

	public enum RotationAxes {

		MouseXAndY = 0,
		MouseX,
		MouseY

	}

	public RotationAxes axes = RotationAxes.MouseXAndY;

	public float sensitivityHor = 9.0f;
	public float sensitivityVert = 9.0f;

	public float minimumVert = -45.0f;
	public float maximumVert = 45.0f;

	private float _rotationX = 0;

	void Start() {

		Rigidbody body = GetComponent<Rigidbody>();
		if (body != null) {
			body.freezeRotation = true;
		}
	}

	// Update is called once per frame
	void Update() {

		float rotationY;

		switch (axes) {
			case RotationAxes.MouseX:
				transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
				break;
			case RotationAxes.MouseY:
				_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
				_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

				rotationY = transform.localEulerAngles.y;

				transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
				break;
			default:
				_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
				_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
				float delta = Input.GetAxis("Mouse X") * sensitivityHor;
				rotationY = transform.localEulerAngles.y + delta;

				transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
				break;
		}
	}

}