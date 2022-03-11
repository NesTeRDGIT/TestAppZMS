using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace TestAppZMS.Entity
{
    public class MSSQLContext : DbContext
    {
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ZGLV>().HasMany(x => x.ZAP).WithOne(x => x.ZGLV).HasForeignKey(x => x.ZGLV_ID);
            modelBuilder.Entity<ZAP>().HasMany(x => x.NPR).WithOne(x => x.ZAP).HasForeignKey(x => x.ZAP_ID);
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Properties.Settings.Default.ConStr);
        }
        public virtual DbSet<ZGLV> ZGLV { get; set; }
        public virtual DbSet<ZAP> ZAP { get; set; }
        public virtual DbSet<NPR> NPR { get; set; }
    }


    public class ZGLV
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ZGLV_ID { get; set; }
        [Required]
        [MaxLength(5)]
        public string VERSION { get; set; }
        [Required]
        public DateTime DATA { get; set; }
        [MaxLength(26)]
        public string FILENAME { get; set; }
        public int CODE { get; set; }
        public int YEAR { get; set; }
        public int MONTH { get; set; }
        public int DAY { get; set; }
        [MaxLength(6)]
        [Required]
        public string CODE_MO { get; set; }
        [MaxLength(8)]
        public string CODE_LPU { get; set; }
        public virtual ICollection<ZAP> ZAP { get; set; } = new List<ZAP>();
    }
    public class ZAP
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ZAP_ID { get; set; }
        public int ZGLV_ID { get; set; }

        public int N_ZAP { get; set; }
        [MaxLength(36)]
        [Required]
        public string ID_PAC { get; set; }
        public int? VPOLIS { get; set; }
        [MaxLength(10)]
        public string SPOLIS { get; set; }
        [MaxLength(20)]
        public string NPOLIS { get; set; }
        [MaxLength(5)]
        public string SMO { get; set; }
        [MaxLength(5)]
        public string ST_OKATO { get; set; }
        [MaxLength(40)]
        [Required]
        public string FAM { get; set; }
        [MaxLength(40)]
        [Required]
        public string IM { get; set; }
        [MaxLength(40)]
        public string OT { get; set; }
        public int W { get; set; }
        public DateTime DR { get; set; }
        [MaxLength(50)]
        public string PHONE { get; set; }
        [MaxLength(250)]
        public string COMENTP { get; set; }
        public virtual ICollection<NPR> NPR { get; set; } = new List<NPR>();
        public virtual ZGLV ZGLV { get; set; }
    }
    public class NPR
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NPR_ID { get; set; }
        public int ZAP_ID { get; set; }

        public int IDNPR { get; set; }
        [MaxLength(20)]
        [Required]
        public string NPR_NUM { get; set; }
        public DateTime DATE { get; set; }
        public int FOR_POM { get; set; }
        [MaxLength(6)]
        [Required]
        public string NPR_MO { get; set; }
        [MaxLength(8)]
      
        public string NPR_LPU { get; set; }
        [MaxLength(6)]
        [Required]
        public string DEST_MO { get; set; }
        [MaxLength(8)]
       
        public string DEST_LPU { get; set; }
        [MaxLength(10)]
        [Required]
        public string DS { get; set; }
        public int? PODR { get; set; }

        public int PROFIL { get; set; }
        [MaxLength(3)]
        [Required]
        public string PROFK { get; set; }
        [MaxLength(25)]
        [Required]
        public string CODE_MD { get; set; }
        public DateTime PLAN_DATE { get; set; }
        [MaxLength(250)]
        public string COMENTN { get; set; }
        public virtual ZAP ZAP { get; set; }
    }

}