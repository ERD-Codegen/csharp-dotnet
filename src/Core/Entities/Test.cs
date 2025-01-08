using System;
using System.ComponentModel.DataAnnotations;

namespace Realworlddotnet.Core.Entities;

public class Test
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}