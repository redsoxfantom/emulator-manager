using System.Threading.Tasks;

namespace EmulatorManager.Components.GameDataComponent
{
    public interface IRomDataAccessor
    {
        void ClearCache();
        Task<GameData> RetrieveGameData(string romType, string romId);
        void UpdateGamePlayedTime(string romId, GameData data);
        Task UpdateOrAddGameData(string romId, GameData data);
    }
}