using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Metro
{
    public class MetroManager : MonoBehaviour
    {
        public static MetroManager Instance;

        public List<MetroRouteSO> routes = new List<MetroRouteSO>();

        private void Awake()
        {
            Instance = this;
        }

        public List<MetroStationSO> FindShortestPath(MetroStationSO startStation, MetroStationSO endStation)
        {
            var distances = routes.SelectMany(route => route.stations)
                                  .ToDictionary(station => station, _ => float.PositiveInfinity);

            var previousStations = distances.ToDictionary(kv => kv.Key, _ => (MetroStationSO)null);

            var priorityQueue = new PriorityQueue<MetroStationSO>();

            distances[startStation] = 0;
            priorityQueue.Enqueue(startStation, 0);

            while (priorityQueue.Count > 0)
            {
                var currentStation = priorityQueue.Dequeue();

                if (currentStation == endStation)
                    break;

                foreach (var neighborStation in currentStation.neighbors.Union(currentStation.transferTo ?? Enumerable.Empty<MetroStationSO>()))
                {
                    var distance = distances[currentStation] + 1;

                    if (distance < distances[neighborStation])
                    {
                        distances[neighborStation] = distance;
                        previousStations[neighborStation] = currentStation;
                        priorityQueue.Enqueue(neighborStation, distance);
                    }
                }
            }

            var shortestPath = new List<MetroStationSO>();

            for (var current = endStation; current != null; current = previousStations[current])
                shortestPath.Add(current);

            shortestPath.Reverse();
            return shortestPath;
        }
    }
}
