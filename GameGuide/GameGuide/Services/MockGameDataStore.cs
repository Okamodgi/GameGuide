using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class MockGameDataStore : IGameDataStore
{
    readonly List<Game> games;

    public MockGameDataStore()
    {
        games = new List<Game>()
        {
            new Game { Id = Guid.NewGuid().ToString(), Name = "Game 1", Logo = "game1.png", Sections = new List<Section>() }
        };

        // Add mock sections and section items here
    }

    public async Task<IEnumerable<Game>> GetGamesAsync()
    {
        return await Task.FromResult(games);
    }

    public async Task<Game> GetGameAsync(string id)
    {
        return await Task.FromResult(games.FirstOrDefault(g => g.Id == id));
    }

    public async Task<IEnumerable<Section>> GetSectionsAsync(string gameId)
    {
        var game = games.FirstOrDefault(g => g.Id == gameId);
        return await Task.FromResult(game?.Sections);
    }

    public async Task<Section> GetSectionAsync(string id)
    {
        var section = games.SelectMany(g => g.Sections).FirstOrDefault(s => s.Id == id);
        return await Task.FromResult(section);
    }

    public async Task<IEnumerable<SectionItem>> GetSectionItemsAsync(string sectionId)
    {
        var items = games.SelectMany(g => g.Sections).FirstOrDefault(s => s.Id == sectionId)?.Items;
        return await Task.FromResult(items);
    }

    public async Task<SectionItem> GetSectionItemAsync(string id)
    {
        var item = games.SelectMany(g => g.Sections).SelectMany(s => s.Items).FirstOrDefault(i => i.Id == id);
        return await Task.FromResult(item);
    }
}
