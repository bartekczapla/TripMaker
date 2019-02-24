using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using TripMaker.Validation;

namespace TripMaker.Configuration.Models
{
    [Table("TripMakerConfigurations")]
    public class TripMakerConfiguration : Entity
    {

        [Required]
        [StringLength(40)]
        public virtual string Name { get; set; }

        [Required]
        [StringLength(32)]
        public virtual string ValueType { get; set; }

        [Required]
        [StringLength(256)]
        public virtual string Value { get; set; }

        public TripMakerConfiguration() { }

        public TripMakerConfiguration(string name, string valueType, string value)
        {
            Name = name;
            ValueType = valueType;
            Value = value;
        }

    }
}