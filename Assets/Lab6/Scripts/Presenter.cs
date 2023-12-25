using UnityEngine;
using UnityEngine.UI;

namespace Assets.Lab6.Scripts
{
    public class Presenter : MonoBehaviour
    {
        public Text deaths;
        public Text items;
        public Text health;

        private void Update()
        {
            deaths.text = $"Mureders: {Enemy.deaths}";
            items.text = $"Items: {Movement.items}/{Movement.itemsForWin}";
            health.text = $"Health: {Movement.health}";
        }
    }
}