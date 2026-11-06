using System;
using System.Collections.Generic;
using System.Text;

namespace B_Review_Domain.Entities
{
    public class StudentPatchDto
    {
        public string? Name { get; set; }

        public string? Email { get; set; }

        public int? Age { get; set; }

        public string? Course { get; set; }

    }
}
