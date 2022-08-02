using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Assignments
{
    public class CreateAssignmentModel
    {
        public int AssignedByUserId { get; set; }
        public int AssignedToUserId { get; set; }
        public int AssetId { get; set; }
        public DateTime AssignedDate { get; set; }
        public string Note { get; set; }
    }
}