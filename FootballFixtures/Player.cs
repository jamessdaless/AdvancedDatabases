namespace FootballFixtures
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Player
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Player()
        {
            PlayerFixtures = new HashSet<PlayerFixture>();
        }

        public int PlayerID { get; set; }

        public int TeamID { get; set; }

        [Required]
        [StringLength(50)]
        public string PlayerName { get; set; }

        [Required]
        [StringLength(2)]
        public string PlayerSquadNumber { get; set; }

        public int PositionID { get; set; }

        public int InjuryID { get; set; }

        public int NationalityID { get; set; }

        public virtual Injury Injury { get; set; }

        public virtual Nationality Nationality { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlayerFixture> PlayerFixtures { get; set; }

        public virtual Position Position { get; set; }

        public virtual Team Team { get; set; }
    }
}
