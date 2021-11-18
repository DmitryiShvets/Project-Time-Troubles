
using Gameplay;

namespace Core
{
    public class BankInteractor : Interactor
    {
        private BankRepository _bankRepository;

        public override void OnCreate()
        {
            _bankRepository = Game.GetRepository<BankRepository>();
        }

        public override void OnInitialize()
        {
            Bank.Initialize(this);
        }


        public int GetCoins => _bankRepository.Coins;

        public void AddCoins(object sender, int value)
        {
            _bankRepository.Coins += value;
            _bankRepository.Save();
        }

        public void SpendCoins(object sender, int value)
        {
            _bankRepository.Coins -= value;
            _bankRepository.Save();
        }
    }
    
}
