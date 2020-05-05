using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoard.Domain.Entites.Topics
{
    public class SubjectData
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectID { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
    }
}