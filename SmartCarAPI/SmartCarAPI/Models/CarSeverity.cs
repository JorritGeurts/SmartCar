using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCarAPI.Models
{
    public class CarSeverity
    {
        public int Id { get; set; }

        // Foreign key for Car
        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }
        public Car Car { get; set; }

        // Foreign key for Severity
        [ForeignKey(nameof(Severity))]
        public int SeverityId { get; set; }
        public Severity Severity { get; set; }

        // Foreign key for Damage
        [ForeignKey(nameof(Damage))]
        public int DamageId { get; set; }
        public Damage Damage { get; set; }

    }
}
