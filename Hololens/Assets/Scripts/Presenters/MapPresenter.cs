using System.Collections.Generic;
using Assets.Scripts.Framework;
using Assets.Scripts.Helpers;
using Assets.Scripts.Models;
using Assets.Scripts.ReactiveModels;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Presenters
{
    public class MapPresenter : NetworkBehaviour
    {
        #region Properties

        [HideInInspector]
        public RxMap CurrentMap;

        private List<GameObject> _cases = new List<GameObject>();

        #endregion

        #region Bindings

        [Header("Map")]
        public float Height = 1;

        public float Width = 1;


        [Header("Cases")]
        public GameObject[] EmptyPrefab;

        public GameObject[] ForestPrefab;

        public GameObject[] MountainPrefab;

        #endregion

        #region Main methods

        public void Start()
        {
            // this.ObserveEveryValueChanged(x => x.CurrentMap).Subscribe(LoadMap);
            CmdGetRandomMap();
        }

        #endregion

        #region Methods

        [Command]
        public void CmdGetRandomMap()
        {
            if (NetworkManager.singleton.client.connection.connectionId != 0)
                return;

            GetMap();
            LoadMap(CurrentMap);
        }

        [Server]
        public void GetMap()
        {
            var map = new Map
            {
                Width = 5,
                Height = 5,
                Cases = new List<Case>
                {
                    // 0
                    new Case
                    {
                        X = 0,
                        Y = 0
                    },
                    new Case
                    {
                        X = 1,
                        Y = 0
                    },
                    new Case
                    {
                        X = 2,
                        Y = 0
                    },
                    new Case
                    {
                        X = 3,
                        Y = 0
                    },
                    new Case
                    {
                        X = 4,
                        Y = 0
                    },
                    // 1
                    new Case
                    {
                        X = 0,
                        Y = 1
                    },
                    new Case
                    {
                        X = 1,
                        Y = 1
                    },
                    new Case
                    {
                        X = 2,
                        Y = 1
                    },
                    new Case
                    {
                        X = 3,
                        Y = 1
                    },
                    new Case
                    {
                        X = 4,
                        Y = 1
                    },
                    //2
                    new Case
                    {
                        X = 0,
                        Y = 2
                    },
                    new Case
                    {
                        X = 1,
                        Y = 2
                    },
                    new Case
                    {
                        X = 2,
                        Y = 2
                    },
                    new Case
                    {
                        X = 3,
                        Y = 2
                    },
                    new Case
                    {
                        X = 4,
                        Y = 2
                    },
                    // 3
                    new Case
                    {
                        X = 0,
                        Y = 3
                    },
                    new Case
                    {
                        X = 1,
                        Y = 3
                    },
                    new Case
                    {
                        X = 2,
                        Y = 3
                    },
                    new Case
                    {
                        X = 3,
                        Y = 3
                    },
                    new Case
                    {
                        X = 4,
                        Y = 3
                    },
                    // 4
                    new Case
                    {
                        X = 0,
                        Y = 4
                    },
                    new Case
                    {
                        X = 1,
                        Y = 4
                    },
                    new Case
                    {
                        X = 2,
                        Y = 4
                    },
                    new Case
                    {
                        X = 3,
                        Y = 4
                    },
                    new Case
                    {
                        X = 4,
                        Y = 4
                    },
                }
            };

            //var json = JsonConvert.SerializeObject(map);

            if (map != null)
            {
                CurrentMap = new RxMap(map);
            }
        }

        [Server]
        private void LoadMap(RxMap map)
        {
            if (map == null)
                return;

            var caseX = Width / map.Data.Width;
            var caseY = Height / map.Data.Height;

            var caseOffsetX = caseX / 2;
            var caseOffsetY = caseX / 2;

            var mapOffsetX = -Width / 2;
            var mapOffsetY = -Height / 2;

            // Remove old cases
            if (_cases.Count > 0)
            {
                for (int i = _cases.Count - 1; i >= 0; i--)
                {
                    var child = _cases[i];
                    NetworkServer.Destroy(child);
                    _cases.RemoveAt(i);
                }
            }

            // Create new cases
            for (int i = 0; i < CurrentMap.Cases.Count; i++)
            {
                var currentCase = CurrentMap.Cases[i];
                var casePosX = mapOffsetX + (currentCase.X * caseX) + caseOffsetX;
                var casePosY = mapOffsetY + (currentCase.Y * caseY) + caseOffsetY;

                var prefab = GetCasePrefabByType(currentCase.Type);
                if (prefab == null)
                    continue;

                prefab.transform.localPosition = new Vector3(casePosX, 0, casePosY);
                prefab.transform.localScale = new Vector3(caseX, (caseX + caseY) / 2, caseY);

                SpawnCorrector corrector = prefab.GetComponent<SpawnCorrector>();
                corrector.Scale = prefab.transform.localScale;

                _cases.Add(prefab);
                NetworkServer.Spawn(prefab);
            }
        }

        [Server]
        private GameObject GetCasePrefabByType(CaseType type)
        {
            GameObject prefab = null;
            switch (type)
            {
                case CaseType.Empty:
                    prefab = Instantiate(GetRandomPrefabFromList(EmptyPrefab));
                    break;
                case CaseType.Forest:
                    prefab = Instantiate(GetRandomPrefabFromList(ForestPrefab));
                    break;
                case CaseType.Mountain:
                    prefab = Instantiate(GetRandomPrefabFromList(MountainPrefab));
                    break;
            }

            return prefab;
        }

        [Server]
        private GameObject GetRandomPrefabFromList(GameObject[] prefabs)
        {
            if (prefabs == null || prefabs.Length <= 0)
                return null;

            var prefab = prefabs[Random.Range(0, prefabs.Length)];
            return prefab;
        }

        #endregion
    }
}