using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace BloodDonationManagement.Models;

public partial class Donor
{
    [Key]
    public int DonorId { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? BloodGroup { get; set; }

    public string? Phone { get; set; }

    public DateOnly? LastDonationDate { get; set; }

    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();
}
