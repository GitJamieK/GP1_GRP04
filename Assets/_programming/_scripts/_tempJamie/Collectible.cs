using System;
using System.Linq;
using UnityEngine;

namespace jamie {
    /// <summary>
    /// Logic for collecting Acorns that then increases Player.AcornScore by 1
    /// </summary>
    public class Collectible : MonoBehaviour {
        Player p;
        public GameObject collectParticlePrefab;

        private float _bounceSpeed = 2f;
        private float _bounceHeight = 0.15f;
        private float _rotationSpeed = 30f;
        
        private Vector3 _startPos;

        private void Start() {
            _startPos = transform.position;
        }

        private void Update() {
            float newY = _startPos.y + Mathf.Sin(Time.time * _bounceSpeed) * _bounceHeight;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            
            transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
        }
        /// <summary>
        /// Handle collision from acorn collectible to player
        /// </summary>
        /// <param name="other"></param>
        void OnTriggerEnter(Collider other) {
            //Debug.Log("collision with Acorn from player");
            p = other.gameObject.GetComponent<Player>();

            if (p != null) {
                p.acornScore++;
                Debug.Log("Player has collected an Acorn. Acorn score: " + p.acornScore);

                Instantiate(collectParticlePrefab, transform.position, Quaternion.identity);

                Destroy(gameObject);

                //add UI logic (3/20 acorns)
            }
        }
    }
}