using System.Collections.Generic;
using System.Threading.Tasks;

public interface IGameDataStore
{
    Task<IEnumerable<Game>> GetGamesAsync();
    Task<Game> GetGameAsync(string id);
    Task<IEnumerable<Section>> GetSectionsAsync(string gameId);
    Task<Section> GetSectionAsync(string id);
    Task<IEnumerable<SectionItem>> GetSectionItemsAsync(string sectionId);
    Task<SectionItem> GetSectionItemAsync(string id);
}
