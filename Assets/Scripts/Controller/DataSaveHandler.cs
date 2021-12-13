using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Model;

namespace Controller
{
    [Serializable]
    public class DataSaveHandler
    {
        private string _dateTimeWhenRewardWasTaken;
        private bool _rewardWasTaken;
        
        public DataSaveHandler(RewardScreenModel rewardScreenModel)
        {
            _dateTimeWhenRewardWasTaken = rewardScreenModel.WhenRewardWasTaken.ToString();
            _rewardWasTaken = rewardScreenModel.RewardWasTaken;
        }

        public void SaveRewardData()
        {
            var binaryFormatter = new BinaryFormatter();
            var path = Application.persistentDataPath + "/RewardTimerData.txt";

            var stream = new FileStream(path, FileMode.Create);
            
            Debug.LogWarning(_dateTimeWhenRewardWasTaken +"\n\r"+ _rewardWasTaken);

            var data = new RewardData(_dateTimeWhenRewardWasTaken, _rewardWasTaken);
            
            binaryFormatter.Serialize(stream, data);
            stream.Close();
        }

        public RewardData LoadRewardData()
        {
            var path = Application.persistentDataPath + "/RewardTimerData.txt";
            if (File.Exists(path))
            {
                var binaryFormatter = new BinaryFormatter();
                var stream = new FileStream(path, FileMode.Open);
                var data = binaryFormatter.Deserialize(stream) as RewardData;
                stream.Close();
                return data;
            }
            else
            {
                Debug.LogError("Save data not found");
                return null;
            }
        }
    }
}