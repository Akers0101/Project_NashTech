using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Enums;

namespace backend.Entities
{
    public class Assignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssignmentId { get; set; }
        public int AssignedToUserId { get; set; }
        public string AssignedToUserName { get; set; }
        public int AssignedByUserId { get; set; }
        public string AssignedByUserName { get; set; }
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public string AssetCode { get; set; }
        public string Specification { get; set; }
        public DateTime AssignedDate { get; set; }
        public string Note { get; set; }
        public virtual Asset Asset { get; set; }
        public virtual User AssignedTo { get; set; }
        public virtual User AssignedBy { get; set; }
        [Required, DefaultValue(AssetState.WaitingForRecycling)]
        public AssignmentState AssignmentState { get; set; }
        public string Location { get; set; }
    }
}