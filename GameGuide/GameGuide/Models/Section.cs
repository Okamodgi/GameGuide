using System.Collections.Generic;

public class Section
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string GameId { get; set; }
    public List<SectionItem> Items { get; set; }
}
