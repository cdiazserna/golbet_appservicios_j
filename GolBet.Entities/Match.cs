// GolBet.Entities/Match.cs
using System.ComponentModel.DataAnnotations.Schema;
using GolBet.Entities.Common;
using GolBet.Entities.Enums;

namespace GolBet.Entities;

public class Match : AuditableEntity
{
    public DateTime Date { get; set; }

    public MatchStatus Status { get; set; } = MatchStatus.Scheduled;

    public int? HomeGoals { get; set; }
    public int? AwayGoals { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal HomeOdds { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal DrawOdds { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal AwayOdds { get; set; }

    // Two foreign keys to the same table (Team)
    public int HomeTeamId { get; set; } // PK
    public Team HomeTeam { get; set; } = null!; // la relación de esa PK con la tabla Team

    public int AwayTeamId { get; set; }
    public Team AwayTeam { get; set; } = null!; //NUNCA SERÁ NULA

    //Navigation Property 
    public ICollection<Bet> Bets { get; set; } = new List<Bet>();
}