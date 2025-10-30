namespace Api;

public struct Position(double latitude, double longitude) {
    public double Latitude { get; } = latitude;
    public double Longitude { get; } = longitude;
    
    public static implicit operator Position((double lat, double lng) pos)  => new (pos.lat, pos.lng);
    public override string ToString() => $"lat:{latitude}, lng:{longitude}";
}

public struct Coordinate(double x, double y) {
    public double x { get; } = x;
    public double y { get; } = y;

    public static implicit operator Coordinate((double x, double y) coor)  => new (coor.x, coor.y);
    public override string ToString() => $"lat:{x}, lng:{y}";
}