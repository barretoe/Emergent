using Microsoft.EntityFrameworkCore;

namespace Emergent.Models
{
    [Keyless]
    public class Software
    {
        public string Name { get; set; }
        public string Version { get; set; }
    }
}
