namespace SzkolenieTechniczne2.Cinema.Common.Entities;

public interface ITrackedEntity
{
    DateTime CreateOn { get; set; }
    DateTime ModifiedOn { get; set; }
    Guid CreatedByUserId { get; set; }
    Guid ModifiedByUserId { get; set; }
}
