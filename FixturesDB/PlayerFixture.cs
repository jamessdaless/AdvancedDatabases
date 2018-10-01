namespace FixturesDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PlayerFixture
    {
        [Key]
        public int PlayerFixturesID { get; set; }

        public int FixtureID { get; set; }

        public int TeamID { get; set; }

        public int PlayerID { get; set; }

        public int GoalsScored { get; set; }

        public int YellowCards { get; set; }

        public int RedCards { get; set; }

        public int Assists { get; set; }

        public virtual Fixture Fixture { get; set; }

        public virtual Player Player { get; set; }
    }
}
