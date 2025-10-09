namespace Domain.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
        public DateTime Date { get; set; }
    }
}
