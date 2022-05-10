using Gameplay;

namespace Core
{
    public class PlayerHealthInteractor : Interactor
    {
        private PlayerHealthRepository _playerHealthRepository;

        public override void OnCreate()
        {
            _playerHealthRepository = Game.GetRepository<PlayerHealthRepository>();
        }

        public override void OnInitialize()
        {
            Player.Initialize(this);
        }


        public int GetHealth => _playerHealthRepository.Health;

        public void AddHealth(object sender, int value)
        {
            if (_playerHealthRepository.Health + value < _playerHealthRepository.maxHeath)
                _playerHealthRepository.Health += value;
            else
            {
                _playerHealthRepository.Health += _playerHealthRepository.maxHeath - _playerHealthRepository.Health;
            }

            _playerHealthRepository.Save();
        }

        public void DecreaseHealth(object sender, int value)
        {
            _playerHealthRepository.Health -= value;
            _playerHealthRepository.Save();
        }
    }
}