namespace Model
{
    public class RewardData
    {
        private string _dateTime;
        private bool _rewardWasTaken;
        
        public RewardData(string dataTime, bool rewardWasTaken)
        {
            _dateTime = dataTime;
            _rewardWasTaken = rewardWasTaken;
        }

        public string DateTimeWhenRewardWasTaken => _dateTime;
        public bool RewardWasTaken => _rewardWasTaken;
    }
}