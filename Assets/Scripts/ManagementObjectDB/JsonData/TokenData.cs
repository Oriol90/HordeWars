using System;

public class TokenData : IElementDB
{
    public Guid id { get; set; } = Guid.NewGuid();
    public Token token { get; set; }
    public int value { get; set; }

    public TokenData(Token token, int value)
    {
        this.token = token;
        this.value = value;
    }
}


