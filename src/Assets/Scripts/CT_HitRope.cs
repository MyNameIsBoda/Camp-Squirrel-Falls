//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: BALLOONS!!
//
//=============================================================================

﻿using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	public class CT_HitRope: MonoBehaviour
	{
		private Hand hand;

		public GameObject popPrefab;

        public float maxVelocity = 5f;

		public GameObject lifetimeEndParticlePrefab;
		public SoundPlayOneshot lifetimeEndSound;

		private float releaseTime = 99999f;

		public SoundPlayOneshot collisionSound;
		private float lastSoundTime = 0f;
		private float soundDelay = 0.2f;

		private Rigidbody balloonRigidbody;

		private bool bParticlesSpawned = false;

		private static float s_flLastDeathSound = 0f;

        public bool isHard;


        //-------------------------------------------------
        void Start()
		{
			hand = GetComponentInParent<Hand>();
			balloonRigidbody = GetComponent<Rigidbody>();
		}


		//-------------------------------------------------
		void Update()
		{
			//if (transform.position.z < .05 )
			//{
   //             ApplyDamage();
			//}
		}


		//-------------------------------------------------
		private void SpawnParticles( GameObject particlePrefab, SoundPlayOneshot sound )
		{
			// Don't do this twice
			if ( bParticlesSpawned )
			{
				return;
			}

			bParticlesSpawned = true;

			if ( particlePrefab != null )
			{
				GameObject particleObject = Instantiate( particlePrefab, transform.position, transform.rotation ) as GameObject;
				particleObject.GetComponent<ParticleSystem>().Play();
				Destroy( particleObject, 2f );
			}

			if ( sound != null )
			{
				float lastSoundDiff = Time.time - s_flLastDeathSound;
				if ( lastSoundDiff < 0.1f )
				{
					sound.volMax *= 0.25f;
					sound.volMin *= 0.25f;
				}
				sound.Play();
				s_flLastDeathSound = Time.time;
			}
		}



        //-------------------------------------------------
        private void ApplyDamage()
        {
            if(!isHard)
            {
                SpawnParticles(popPrefab, null);
                GameObject parent = transform.parent.gameObject.transform.parent.gameObject;
                parent.transform.GetChild(0).gameObject.SetActive(false);
                parent.transform.GetChild(1).gameObject.SetActive(true);
            }  
        }

        private void ApplyFireDamage()
        {
            SpawnParticles(popPrefab, null);
            GameObject parent = transform.parent.gameObject.transform.parent.gameObject;
            parent.transform.GetChild(0).gameObject.SetActive(false);
            parent.transform.GetChild(1).gameObject.SetActive(true);
        }


        //-------------------------------------------------
  //      void OnCollisionEnter( Collision collision )
		//{
		//	if ( bParticlesSpawned )
		//	{
		//		return;
		//	}

		//	Hand collisionParentHand = null;

		//	BalloonHapticBump balloonColliderScript = collision.gameObject.GetComponent<BalloonHapticBump>();

		//	if ( balloonColliderScript != null && balloonColliderScript.physParent != null )
		//	{
		//		collisionParentHand = balloonColliderScript.physParent.GetComponentInParent<Hand>();
		//	}

		//	if ( Time.time > ( lastSoundTime + soundDelay ) )
		//	{
		//		if ( collisionParentHand != null ) // If the collision was with a controller
		//		{
		//			if ( Time.time > ( releaseTime + soundDelay ) ) // Only play sound if it's not immediately after release
		//			{
		//				collisionSound.Play();
		//				lastSoundTime = Time.time;
		//			}
		//		}
		//		else // Collision was not with a controller, play sound
		//		{
		//			collisionSound.Play();
		//			lastSoundTime = Time.time;

		//		}
		//	}


		//	if ( balloonRigidbody.velocity.magnitude > ( maxVelocity * 10 ) )
		//	{
		//		balloonRigidbody.velocity = balloonRigidbody.velocity.normalized * maxVelocity;
		//	}

		//	if ( hand != null )
		//	{
		//		ushort collisionStrength = (ushort)Mathf.Clamp( Util.RemapNumber( collision.relativeVelocity.magnitude, 0f, 3f, 500f, 800f ), 500f, 800f );

		//		hand.TriggerHapticPulse( collisionStrength );
		//	}
		//}
	}
}
