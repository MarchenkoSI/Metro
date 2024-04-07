using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metro
{
    public class RouteUI : MonoBehaviour
    {
        public static RouteUI Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void SetStation(MetroStationSO station)
        {
            if (from == null)
            {
                from = station;
            }
            else if (to == null)
            {
                to = station;
            }
            else
            {
                from = station;
                to = null;
            }

            if (from == null || to == null) return;


            stations.ForEach(currentStation => currentStation.ResetColor());

            route = metroManager.FindShortestPath(from, to);

            if (route == null || route.Count == 0) return;

            foreach(StationUI currentStation in stations)
            {
                if (!route.Contains(currentStation.station)) continue;

                currentStation.UpdateColor();
            }
        }

        [SerializeField] private MetroManager metroManager;
        [SerializeField] private List<StationUI> stations;

        [SerializeField] private List<MetroStationSO> route = new List<MetroStationSO>();

        [SerializeField] private MetroStationSO from;
        [SerializeField] private MetroStationSO to;
    }
}

