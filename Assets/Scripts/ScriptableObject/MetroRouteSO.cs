using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metro
{
    [CreateAssetMenu(fileName = "New Metro Route", menuName = "Metro/Route")]
    public class MetroRouteSO : ScriptableObject
    {
        public List<MetroStationSO> stations = new List<MetroStationSO>();
        public List<MetroStationSO> transferStations = new List<MetroStationSO>();
        public bool isCircle;

        private void OnValidate()
        {
            for (int i = 0; i < stations.Count; ++i)
            {
                stations[i].neighbors.Clear();

                if (stations[i].neighbors.Count != 0) continue;

                if (!isCircle)
                {
                    MetroStationSO previous = i > 0 ? stations[i - 1] : null;
                    MetroStationSO next = i < stations.Count - 1 ? stations[i + 1] : null;
                    if (previous != null)
                    {
                        stations[i].neighbors.Add(previous);
                    }
                    if (next != null)
                    {
                        stations[i].neighbors.Add(next);
                    }

                }
                else
                {
                    MetroStationSO previous = i > 0 ? stations[i - 1] : stations[stations.Count - 1];
                    MetroStationSO next = i < stations.Count - 1 ? stations[i + 1] : stations[0];

                    stations[i].neighbors.Add(previous);
                    stations[i].neighbors.Add(next);
                }
            }
        }
        public void FillNeighbors()
        {
            for (int i = 0; i < stations.Count; ++i)
            {
                if (stations[i].neighbors.Count != 0) continue;

                if (!isCircle)
                {
                    MetroStationSO previous = i > 0 ? stations[i - 1] : null;
                    MetroStationSO next = i < stations.Count - 1 ? stations[i + 1] : null;
                    if (previous != null)
                    {
                        stations[i].neighbors.Add(previous);
                    }
                    if (next != null)
                    {
                        stations[i].neighbors.Add(next);
                    }

                }
                else
                {
                    MetroStationSO previous = i > 0 ? stations[i - 1] : null;
                    MetroStationSO next = i < stations.Count - 1 ? stations[i + 1] : null;

                    stations[i].neighbors.Add(previous);
                    stations[i].neighbors.Add(next);
                }
            }
        }
    }
}

