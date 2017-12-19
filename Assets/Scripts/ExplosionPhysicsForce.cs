using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Effects
{
    public class ExplosionPhysicsForce : MonoBehaviour
    {
        public float explosionForce = 4;
        public GameObject wave;
        public GameObject waveS;
        public AudioClip[] splashes;

        IEnumerator DelayDestroy()
        {
            yield return new WaitForSeconds(1.0f);
            Destroy(gameObject);
        }

        void OnTriggerEnter(Collider other)
        {
            if (GetComponent<AudioSource>().isPlaying) return;
            GetComponent<AudioSource>().clip = splashes[UnityEngine.Random.Range(0, splashes.Length)];
            GetComponent<AudioSource>().Play();
            Instantiate(wave, gameObject.transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
            Instantiate(waveS, gameObject.transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
            if (other.gameObject.tag != "Player")
            {
                float r = 25;
                var cols = Physics.OverlapSphere(transform.position, r);
                var rigidbodies = new List<Rigidbody>();
                foreach (var col in cols)
                {
                    if (col.attachedRigidbody != null && !rigidbodies.Contains(col.attachedRigidbody))
                    {
                        rigidbodies.Add(col.attachedRigidbody);
                    }
                }
                foreach (var rb in rigidbodies)
                {
                    rb.AddExplosionForce(explosionForce, transform.position, r, 1, ForceMode.Impulse);
                }
                StartCoroutine(DelayDestroy());
            }
        }
    }
}
