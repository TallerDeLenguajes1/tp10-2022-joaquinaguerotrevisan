public class Structure
{
    public int id { get; set; }
    public string? name { get; set; }
    public string? description { get; set; }
    public string? expansion { get; set; }
    public string? age { get; set; }
    public float build_time { get; set; }
    public float hit_points { get; set; }
    public float line_of_sight { get; set; }
    public string? armor { get; set; }
    public string? range { get; set; }
    public float reload_time { get; set; }
    public float attack { get; set; }
}

public class Root
{
    public List<Structure>? structures { get; set; }
}
