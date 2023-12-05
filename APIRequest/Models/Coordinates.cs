namespace waterlocator
{
    class Coordinates
    {
        string Northern_most;
        string Western_most;
        string Eastern_most;
        string Southern_most;
        public Coordinates(string north, string west, string east, string south)
        {
            Northern_most = north;
            Western_most = west;
            Eastern_most = east;
            Southern_most = south;
        }
    }
}