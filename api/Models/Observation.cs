using FluentValidation;

namespace api.Models
{
    public class ObservationValidator : AbstractValidator<Observation>
    {
        public ObservationValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
        }
    }
    public class Observation
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}