namespace Api;

public struct Position(double latitude, double longitude) {
    public double Latitude { get; } = latitude;
    public double Longitude { get; } = longitude;
    public const float TOLERANCE = 0.000000001f;

    public double DistanceTo(Position other) {
        var deltaX = other.Longitude - longitude;
        var deltaY = other.Latitude - latitude;
        return Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
    }
    public static bool operator ==(Position a, Position b) => Math.Abs(a.Latitude - b.Latitude) < TOLERANCE && Math.Abs(a.Longitude - b.Longitude) < TOLERANCE;
    public static implicit operator Position((double lat, double lng) pos)  => new (pos.lat, pos.lng);
    public override string ToString() => $"lat:{latitude}, lng:{longitude}";
}