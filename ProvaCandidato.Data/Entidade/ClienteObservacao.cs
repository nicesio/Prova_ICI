using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProvaCandidato.Data.Entidade
{
    public class ClienteObservacao
    {
        [Key]
        [Column("codigo")]
        public int Codigo { get; set; }
        [Column("descricao")]
        [Display(Name = "Descricao")]
        [MaxLength(255)]
        [Required]
        public string Descricao { get; set; }

        [Column("codigo_cliente")]
        public int ClienteId { get; set; }


        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }
    }
}
