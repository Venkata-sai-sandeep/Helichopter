using SimpleInputNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// This script is needed to demonstrate this asset.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour, ISimpleInputDraggable
{

	[SerializeField] float MaxMotorTorque = 1500;
	[SerializeField] float MaxBrakeTorque = 500;
	[SerializeField] float AccelerationTorque = 1f;
	[SerializeField] float AccelerationBrakeTorque = 0.5f;
	[SerializeField] float AccelerationSteer = 10f;
	[SerializeField] GameObject COM;
	[SerializeField] List<WheelPreset> DrivingWheels = new List<WheelPreset>();
	[SerializeField] List<WheelPreset> SteeringWheels = new List<WheelPreset>();

	public AxisInputUIArrows axisinput;
	public SteeringWheel steeringWheel;
	public AxisInputUIArrows breaks;
	Rigidbody RB;
	HashSet<WheelPreset> AllWheels = new HashSet<WheelPreset>();
	float CurrentAcceleration;
	float CurrentBrake;
	float CurrentSteer;

	public bool Enable { get; set; }

	private void Awake () {
		Enable = false;
		RB = GetComponent<Rigidbody>();
		RB.centerOfMass = COM.transform.localPosition;
		RB.ResetInertiaTensor();
		foreach (var wheel in SteeringWheels) {
			AllWheels.Add(wheel);
		}
		foreach (var wheel in DrivingWheels) {
			AllWheels.Add(wheel);
		}
		
	}

	private void Update () {
		 
		float targetAcceleration = Input.GetAxis("Vertical");//Removed
		float targetSteer = Input.GetAxis("Horizontal"); // Removed
		//string movement = axisinput.yAxis.value;//.ToString();
		//Debug.Log(movement);
		//float targetAcceleration = axisinput.yAxis.value;
		//float targetSteer = steeringWheel.axis.value;
		//Debug.Log(targetAcceleration);
		//Debug.Log(targetSteer);

		if (breaks.xAxis.value == 1 ||breaks.xAxis.value == -1 || !Enable) {
			CurrentAcceleration = 0;
			CurrentBrake = Mathf.MoveTowards(CurrentBrake, 1, AccelerationBrakeTorque * Time.deltaTime);
		} else {
			CurrentAcceleration = Mathf.MoveTowards(CurrentAcceleration, targetAcceleration, AccelerationTorque * Time.deltaTime);
			CurrentBrake = 0;
		}

		if (Enable) {
			CurrentSteer = Mathf.MoveTowards(CurrentSteer, targetSteer, AccelerationSteer * Time.deltaTime);
		}
	}

	private void FixedUpdate () {
		WheelCollider wheelCollider;
		for (int i = 0; i < DrivingWheels.Count; i++) {
			wheelCollider = DrivingWheels[i].WheelCollider;
			wheelCollider.motorTorque = CurrentAcceleration * MaxMotorTorque;
			wheelCollider.brakeTorque = DrivingWheels[i].BrakeTorque * CurrentBrake * MaxBrakeTorque;
		}

		for (int i = 0; i < SteeringWheels.Count; i++) {
			wheelCollider = SteeringWheels[i].WheelCollider;
			wheelCollider.steerAngle = CurrentSteer * SteeringWheels[i].SteerAngle;
			wheelCollider.brakeTorque = DrivingWheels[i].BrakeTorque * CurrentBrake * MaxBrakeTorque;
		}
	}

    public void OnPointerDown(PointerEventData eventData)
    {
		//Debug.Log("Pointer down");
        throw new System.NotImplementedException();

    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    [System.Serializable]
	private class WheelPreset {
		public WheelCollider WheelCollider;
		public float BrakeTorque = 1;
		public float SteerAngle = 25;
	}

}
