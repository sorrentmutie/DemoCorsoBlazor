﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DemoCorsoBlazor.API.Models;

public partial class Speakers
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public int EventoId { get; set; }

    public virtual Eventi Evento { get; set; }

    public virtual ICollection<Certifications> Certifications { get; set; } = new List<Certifications>();
}