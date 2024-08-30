using System.Data.Common;
using System.Dynamic;

public class Parser
{
    public List<Token> tokens {get; private set;}
    public Parser(List<Token> tokens){ this.tokens = tokens;}
    #region MethodsForMovility
    int position = 0;
    Token TokenPlus { get; set;}

    public int Position { get { return position; } }

    public bool End => position == tokens.Count-1;

    public void MoveNext(int k = 1)
    {
        position += k;
    }

    public void MoveBack(int k = 1)
    {
        position -= k;
    }

    public bool Next()
    {
        if (position < tokens.Count - 1)
        {
            position++;
        }

        return position < tokens.Count- 1;
    }
    public int NextNStay(){
        if(position < tokens.Count - 1) return position + 1;
        return -1;
    }
    public Token NextTokenStay(){
        if(position < tokens.Count - 1) return tokens[position + 1];
        return null;
    }
    public Token NextTokenMove(){
        if(position < tokens.Count - 1){
            position++;
            return tokens[position];
        }
        return null;
    }

    public void Consume(TokenType type){
        if( tokens[position + 1].Type == type) position++;
        else{
            Token token = tokens[position + 1];
            throw new Exception($"Invalid Sintax Error. Unexpected Token at line {token.Location.Line}, column: {token.Location.Column}");
        }
    }
    public void Consume(List<TokenType> types){
        foreach (TokenType type in types){
            Consume(type);
        }
    }
    public void LookAhead(TokenType type){
        LookAhead([type]);
    }

    public void LookAhead(List<TokenType>? types = null){
        if(Position + 1 >= tokens.Count) throw new Exception($"Out of range at line: {tokens[tokens.Count-1].Location.Line}, column: {tokens[tokens.Count-1].Location.Column}");
        if(types == null) {TokenPlus = tokens[position + 1];    return;}
        if(types.Contains(tokens[Position + 1].Type)) TokenPlus = tokens[Position + 1];
        else throw new Exception($"Unexpected Token at line: {tokens[Position+1].Location.Line}, column: {tokens[position+1].Location.Column}");;
    }

    public bool NextToken( TokenType type )
    {
        if (position < tokens.Count-1 && GiveToken(1).Type == type)
        {
            position++;
            return true;
        }

        return false;
    }

    public bool NextToken(string value)
    {            
        if (position < tokens.Count-1 && GiveToken(1).Value == value)
        {
            position++;
            return true;
        }

        return false;
    }

    public bool CanLookAhead(int k = 0)
    {
        return tokens.Count - position > k;
    }

    public Token GiveToken(int k = 0)
    {
        return tokens[position + k];
    }

    public Token InPosition(int k)
    {
        if (k > -1 && k < tokens.Count)
        {
            position ++;
            return tokens[k];
        }
        else throw new Exception("Index out of range");
    }
    #endregion
    #region Effect
    public Expression ParseName(){
        List<TokenType> expected = [TokenType.Name, TokenType.Colon, TokenType.String];
        Consume(expected);
        return new UnaryVal(tokens[position]);
    }
    public Dictionary<string, Expression> ParseParam(){
        Dictionary<string, Expression> param = new Dictionary<string, Expression>();
        Token Name;
        Consume(new List<TokenType>(){TokenType.Params, TokenType.Colon, TokenType.LCurlyB});
        List<TokenType> expected = new List<TokenType>() {TokenType.RCurlyB, TokenType.Identifier};
        LookAhead(expected);

        while(TokenPlus.Type != TokenType.RCurlyB){
            Name = TokenPlus;
            Consume(new List<TokenType>() {TokenPlus.Type, TokenType.Colon} );
            LookAhead(new List<TokenType>() {TokenType.Int, TokenType.String, TokenType.True, TokenType.False});
            param.Add(Name.Value, new UnaryVal(TokenPlus));
            Consume(TokenPlus.Type);
            LookAhead(new List<TokenType>() {TokenType.Comma, TokenType.RCurlyB});
            if( TokenPlus.Type == TokenType.Comma) Consume(TokenType.Comma);
            LookAhead(expected);
        }
        Consume(TokenType.RCurlyB);
        return param;
    }
    public Statement ParseAction(){
        Consume(new List<TokenType>() {TokenType.Action, TokenType.Colon, TokenType.LParen});
        LookAhead(TokenType.Identifier);
        Token targets = TokenPlus;
        Consume(new List<TokenType>() {TokenType.Identifier, TokenType.Comma});
        LookAhead(TokenType.Identifier);
        Token context = TokenPlus;
        Consume(new List<TokenType>() {TokenType.Identifier, TokenType.LParen, TokenType.Implication});
        LookAhead();
        if(TokenPlus.Type != TokenType.LCurlyB) return ParseInst(targets, context);
        Consume(TokenType.LCurlyB);
        Statement body = ParseBody(targets, context);
        Consume(TokenType.RCurlyB);
        return body;
    }

    public Statement ParseBody(Token targets, Token context){

    }
    public Statement ParseInst(Token targets, Token context){

    }
    public EffectDSL ParseEffect(){
        Expression? Name = null;
        Dictionary<string, Expression>? Params = null;
        Statement? Action = null;;
        Consume(new List<TokenType>() { TokenType.Effect, TokenType.LCurlyB});
        var expected1 = new List<TokenType>() {TokenType.Name, TokenType.Params, TokenType.Action};
        var expected2 = new List<TokenType>() {TokenType.Comma, TokenType.RCurlyB};
        LookAhead(expected1);
        while(expected1.Contains(TokenPlus.Type)){
            var type = TokenPlus.Type;
            if(type is TokenType.Name) Name = ParseName();
            else if(type is TokenType.Params) Params = ParseParam();
            else Action = ParseAction();

            LookAhead(expected2);
            if(TokenPlus.Type != TokenType.Comma) break;
            Consume(TokenType.Comma);
            expected1.Remove(type);
            LookAhead(expected1);
        }
        Consume(TokenType.RCurlyB);
        if(Name != null && Action != null) return new EffectDSL(Name, Action, Params);
        throw new Exception($"Invalid declaration of the Effect");
    }
    #endregion
    public ICard ParseCard(){

    }    
}