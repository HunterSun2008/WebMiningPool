using System;
using System.ComponentModel.DataAnnotations;

namespace WebMiningPool.Models
{
    public class Miner
    {
        public int Id { get; set; }

        [Display(Name = "名称")]
        public string Name { get; set; }

        [Display(Name = "算力(M)")]
        public int CalculationPow { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "注册日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegisterDate { get; set; }

    }
}
