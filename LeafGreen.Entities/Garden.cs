using System;

namespace LeafGreen.Entities
{
    public class Garden
    {
        public int GardenId { get; set; }
        public string GardenName { get; set; }
        public bool IsArchived { get; set; }
        public DateTime DateAdded { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string DeviceId { get; set; }
    }
}
