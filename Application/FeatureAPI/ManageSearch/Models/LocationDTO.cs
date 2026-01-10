public class LocationDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Lat { get; set; }
    public double Lng { get; set; }
    public List<AreaDTO> Areas { get; set; } = new();

}
public class AreaDTO
{
    public int Id { get; set; }
    public int EmirateId { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Lat { get; set; }
    public double Lng { get; set; }
}

