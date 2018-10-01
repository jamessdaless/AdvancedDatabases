namespace FootballFixtures
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Fixture
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fixture()
        {
            PlayerFixtures = new HashSet<PlayerFixture>();
        }

        public int FixtureID { get; set; }

        public int Gameweek { get; set; }

        [Column(TypeName = "date")]
        public DateTime DatePlayed { get; set; }

        public TimeSpan TimePlayed { get; set; }

        public int HomeTeamID { get; set; }

        public int HTGoals { get; set; }

        public int ATGoals { get; set; }

        public int AwayTeamID { get; set; }

        public int CompetitionID { get; set; }

        public int RefereeID { get; set; }

        public virtual Competition Competition { get; set; }

        public virtual Referee Referee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlayerFixture> PlayerFixtures { get; set; }
    }
}
