using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace minimap
{
    public class MapManager : MonoBehaviour
    {
        // PUBLIC/SERIALIZED MEMBERS **************************************************************
        [HideInInspector] public float mapWidth;
        [HideInInspector] public float mapHeight;
        [HideInInspector] public Vector3 playerIconPos;

        [Header("Map Public References")]
        public Transform playerTransform;
        public RectTransform mapTransform;
        public RectTransform playerIconTransform;
        public SpriteRenderer spriteRenderer;
        public Light2D globalLight;
        

        void Awake()
        {
            setMapSize();
        }

        void setMapSize()
        {
            mapWidth = spriteRenderer.bounds.size.x;
            mapHeight = spriteRenderer.bounds.size.y;
        }

        void Update()
        {
            setMapSize();
            playerIconPos = TranslateWorldToMapPosition(playerTransform.position);

            globalLight.intensity = NormaliseMapCoords(playerTransform.position).y*1.1f;

            playerIconTransform.anchoredPosition = new Vector2(playerIconPos.x, playerIconPos.y);
            
        }

        public Vector3 TranslateWorldToMapPosition(Vector3 position)
        {
            // STEP1: normalize world coords
            Vector3 n_pos = new Vector3();
            n_pos = NormaliseMapCoords(position);

            // STEP2: convert normalized coords to local map space
            Vector3 max_lm_pos = new Vector3( mapTransform.rect.width / 2, mapTransform.rect.width / 2, 0);
            Vector3 min_lm_pos = new Vector3(-(mapTransform.rect.width / 2), -(mapTransform.rect.width / 2), 0);
            Vector3 lm_pos = new Vector3();

            lm_pos.x = Mathf.Lerp(min_lm_pos.x, max_lm_pos.x, n_pos.x);
            lm_pos.y = Mathf.Lerp(min_lm_pos.y, max_lm_pos.y, n_pos.y);

            return lm_pos;
        }

        private Vector3 NormaliseMapCoords(Vector3 in_pos)
        {
            Vector3 max_w_pos = new Vector3(mapWidth / 2.0f, mapHeight / 2.0f, 0);
            Vector3 min_w_pos = new Vector3(-(mapWidth / 2.0f), -(mapHeight / 2.0f), 0);
            Vector3 n_pos = new Vector3();

            n_pos.x = Mathf.InverseLerp((float)min_w_pos.x, (float)max_w_pos.x, (float)in_pos.x);
            n_pos.y = Mathf.InverseLerp((float)min_w_pos.y, (float)max_w_pos.y, (float)in_pos.y);

            return n_pos;
        }



    }
}


