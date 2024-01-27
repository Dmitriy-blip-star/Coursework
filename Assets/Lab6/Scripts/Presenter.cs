using UnityEngine;
using TMPro;

namespace Assets.Lab6.Scripts
{
    public class Presenter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _deaths;
        [SerializeField] private TextMeshProUGUI _items;
        [SerializeField] private TextMeshProUGUI _health;

        private void Update()
        {
            _deaths.text = $"Mureders: {Enemy.Deaths}";
            _items.text = $"Items: {Movement.Items}/{Movement.ItemsForWin}";
            _health.text = $"Health: {Movement.Health}";
        }
    }
}