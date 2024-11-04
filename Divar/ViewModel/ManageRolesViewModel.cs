using System.Collections.Generic;

namespace Divar.Models
{
    public class ManageRolesViewModel
    {
        public string UserId { get; set; }
        public List<IdentityRole> AvailableRoles { get; set; }
        public IList<string> UserRoles { get; set; }
        public List<string> SelectedRoles { get; set; }
    }
}
