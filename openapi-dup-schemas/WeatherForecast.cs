namespace WebApplication1;

public class WeatherForecast
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public LocationDto Location { get; set; }
}

public class LocationDto
{
    public string Name { get; set; }

    public AddressDto Address { get; set; }
}

public class AddressDto
{
    string AddressLine { get; set; }

    public LocationDto RelatedLocation { get; set; }
}