﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DemoCorsoBlazor.API.Models;

public partial class Eventi
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public DateTime Data { get; set; }

    public string Località { get; set; }

    public virtual ICollection<Speakers> Speakers { get; set; } = new List<Speakers>();
}