class Character
{
    public UInt64 Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Relationship { get; set; } = string.Empty;

    public string Display()
    {
        return $"Id: {Id}\nName: {Name}\nDescription: {Relationship}\n";
    }
}