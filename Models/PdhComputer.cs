using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pdh_231230796_de01.Models;

[Table("pdhComputer")]
public partial class PdhComputer
{
    [Key]
    [Column("pdhComId")]
    public int PdhComId { get; set; }

    [Column("pdhComName")]
    [StringLength(100)]
    public string PdhComName { get; set; } = null!;

    [Column("pdhComPrice", TypeName = "decimal(18, 2)")]
    public decimal PdhComPrice { get; set; }

    [Column("pdhComImage")]
    [StringLength(255)]
    public string? PdhComImage { get; set; }

    [Column("pdhComStatus")]
    public bool PdhComStatus { get; set; }
}
