// GolBet.Entities/Bet.cs
using System.ComponentModel.DataAnnotations.Schema;
using GolBet.Entities.Common;
using GolBet.Entities.Enums;

namespace GolBet.Entities;

public class Bet : AuditableEntity
{
    [Column(TypeName = "decimal(12,2)")]
    public decimal Amount { get; set; }

    /// <summary>Odds frozen at placement time. Admin odds changes never affect placed bets.</summary>
    [Column(TypeName = "decimal(5,2)")]
    public decimal OddsAtPlacement { get; set; }

    public BetPick Pick { get; set; }

    public BetStatus Status { get; set; } = BetStatus.Pending;

    //PK
    public int MatchId { get; set; }

    //Navigation Property
    public Match Match { get; set; } = null!;

    // Module 7 will add:  public string UserId  +  AppUser User
}
