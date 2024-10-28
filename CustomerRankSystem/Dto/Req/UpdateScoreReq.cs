using System.ComponentModel.DataAnnotations;

namespace CustomerRankSystem.Dto
{
    public class UpdateScoreReq
    {
        /// <summary>
        /// CustomerId
        /// </summary>
        [Required(ErrorMessage = "CustomerId cannot be empty")]
        [Range(minimum: 1, maximum: Int64.MaxValue, ErrorMessage = "Please enter the correct CustomerId")]
        public Int64? CustomerId { get; set; }

        /// <summary>
        /// Score
        /// </summary>
        [Required(ErrorMessage = "Score cannot be empty")]
        [Range(minimum: -1000, maximum: 1000, ErrorMessage = "Please enter scores in the correct range")]
        public int? Score { get; set; }
    }
}
