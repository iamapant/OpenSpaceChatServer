namespace Api;

public record struct Position(double Latitude, double Longitude) : IEquatable<Position> {
    // public double Latitude { get; } = latitude;
    // public double Longitude { get; } = longitude;
    // private const float TOLERANCE = 0.000000001f;

    public double DistanceTo(Position other) {
        var deltaX = other.Longitude - Longitude;
        var deltaY = other.Latitude - Latitude;
        return Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
    }
    // public static bool operator ==(Position a, Position b) => Math.Abs(a.Latitude - b.Latitude) < TOLERANCE && Math.Abs(a.Longitude - b.Longitude) < TOLERANCE;
    // public static bool operator !=(Position a, Position b) => !(a == b);
    public static implicit operator Position((double lat, double lng) pos)  => new (pos.lat, pos.lng);
    public override string ToString() => $"lat:{Latitude}, lng:{Longitude}";

    // public bool Equals(Position other) => Latitude.Equals(other.Latitude) && Longitude.Equals(other.Longitude);

    // public override bool Equals(object? obj) => obj is Position other && Equals(other);

    // public override int GetHashCode() => HashCode.Combine(Latitude, Longitude);
}