using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VARLabBootCamp2022
{
    public class PlayerDeath : MonoBehaviour
    {
        /// <summary>Restarts the current scene upon player "death" -- aka when they fall out of bounds
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
