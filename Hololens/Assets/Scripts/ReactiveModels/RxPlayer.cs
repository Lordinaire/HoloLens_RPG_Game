using Assets.Scripts.Models;
using UniRx;

namespace Assets.Scripts.ReactiveModels
{
    public class RxPlayer
    {
        public Player Data;

        public ReactiveProperty<string> Name { get; private set; }

        public RxPlayer(Player player)
        {
            Data = player;

            Name = new StringReactiveProperty(player.Name);
        }
    }
}
