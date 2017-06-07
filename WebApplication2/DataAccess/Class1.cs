using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataAccess
{
    public class City
    {
        public int CityId { get; set; }
        public virtual IList<Mine> Mines { get; set; }
        public virtual IList<Resource> Resources { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public virtual List<Troup> Troups { get; set; }
    }

    public class Troup
    {
        public int TroupId { get; set; }
        public int TroupTypeId { get; set; }
        public virtual TroupType TroupType { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public int TroupCount { get; set; }

    }

    public class TroupType
    {
        public int TroupTypeId { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        [RegularExpression("[A-z]*")]
        public string Name { get; set; }
        [Range(0, 100)]
        public double Attack { get; set; }
        [Range(0, 100)]
        public double Defence { get; set; }
        [Range(0, 100)]
        public int CreationSpeed { get; set; }
    }

    public class Resource
    {
        public int ResourceId { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }

        public DateTime LastUpdate { get; set; }
        public ResourceType Type { get; set; }

        public double Value { get; set; }
        public double Level { get; set; }
    }

    public class Mine
    {
        public string MineStyle { get; set; }
        public int MineId { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }

        public int Level { get; set; }

        public ResourceType Type { get; set; }

        public double GetProductionPerHour(int? level = null)
        {
            return (level ?? this.Level) * 13;
        }
    }



    public enum ResourceType
    {
        Wheat,
        Iron,
        Clay,
        Wood
    }
}