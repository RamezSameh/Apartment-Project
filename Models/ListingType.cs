using System.ComponentModel.DataAnnotations;

namespace Apartment_Project.Models
{
    public enum ListingType
    {
        [Display(Name = "For Rent")]
        Rent = 0,

        [Display(Name = "For Sale")]
        Sale = 1
    }
}
