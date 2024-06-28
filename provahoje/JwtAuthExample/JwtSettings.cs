using System.Diagnostics;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public record JwtSettings(string Key, string Issuer, string Audience)
{
    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}