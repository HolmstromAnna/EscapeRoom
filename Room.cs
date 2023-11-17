public class Room
{
    public string RoomDescription;
    public List <Thing> Things;
    public Room (string roomDescription, List <Thing> things)
    {
        RoomDescription = roomDescription;
        Things = things;
    }
}