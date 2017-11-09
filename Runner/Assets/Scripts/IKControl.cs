using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKControl : MonoBehaviour {

    public Transform lookTarget;

    public Transform leftHandTrackingTarget;

    public Transform rightHandTrackingTarget;

    private Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    private void OnAnimatorIK(int layerIndex)
    {
        if (leftHandTrackingTarget != null)
        {
            // 가중치 설정
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.8f);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.8f);

            anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHandTrackingTarget.position);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, leftHandTrackingTarget.rotation);
        }

        if (rightHandTrackingTarget != null)
        {
            // 가중치 설정
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.8f);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.8f);

            anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandTrackingTarget.position);
            anim.SetIKRotation(AvatarIKGoal.RightHand, rightHandTrackingTarget.rotation);
        }


        if (lookTarget != null)
        {
            // 가중치 설정
            anim.SetLookAtWeight(1.0f);

            anim.SetLookAtPosition(lookTarget.position);

        }
    }
}
