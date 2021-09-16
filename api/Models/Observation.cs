using FluentValidation;
using NpgsqlTypes;

namespace api.Models
{
    public class ObservationValidator : AbstractValidator<Observation>
    {
        public ObservationValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
        }
    }
    public class Observation
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
    }
}