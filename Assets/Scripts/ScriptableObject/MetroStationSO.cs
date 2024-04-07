using System.Collections.Generic;
using UnityEngine;

namespace Metro
{
    [CreateAssetMenu(fileName = "New Metro Station", menuName = "Metro/Station")]
    public class MetroStationSO : ScriptableObject
    {
        public string stationName;

        public List<MetroStationSO> neighbors;

        public List<MetroStationSO> transferTo;
    }
}

