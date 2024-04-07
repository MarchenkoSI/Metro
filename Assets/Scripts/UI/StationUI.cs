using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Metro
{
    public class StationUI : MonoBehaviour, IPointerClickHandler
    {
        public Color usedColor;
        public Color normalColor;

        public TextMeshProUGUI stationName;
        public MetroStationSO station;

        private void OnValidate()
        {
            if (stationImage == null)
            {
                stationImage = GetComponent<Image>();
            }

            if (stationName == null)
            {
                stationName = gameObject.GetComponentInChildren<TextMeshProUGUI>();
            }

            stationName.text = station.stationName;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            RouteUI.Instance.SetStation(station);
        }

        public void ResetColor()
        {
            stationImage.color = normalColor;
        }
        public void UpdateColor()
        {
            stationImage.color = usedColor;
        }

        private Image stationImage;
    }
}
