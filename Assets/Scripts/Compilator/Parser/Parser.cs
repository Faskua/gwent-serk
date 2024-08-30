using System.Data.Common;
using System.Dynamic;

public class Parser
{
    //Tengo que tener un stack con los scope para controlar las variables
    public List<Token> tokens {get; private set;}
    public List<string> Errores = [];
    public Parser(List<Token> tokens){ this.tokens = tokens;}
    #region Methods
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
    //TODO
    public Statement Enunciation(Token id){
        throw new NotImplementedException();
    }
    public Expression ParseNum(){
        List<string> Operations = ["+", "-", "*", "/", "^"];
        Consume(TokenType.Int);
        Expression left = new UnaryVal(tokens[position]);
        LookAhead();
        while(Operations.Contains(TokenPlus.Value)){
            Token operation = TokenPlus;
            Consume(TokenPlus.Type);
            LookAhead(TokenType.Int);
            Expression right = new UnaryVal(TokenPlus);
            Consume(TokenType.Int);
            left = new NumericalBinary(right, left, operation);
            LookAhead();
        }
        if(!left.Validation()){
            string error = "";
            foreach (var item in left.Errors){
                error+=item;
                error+="\n";
            }
            throw new Exception(error);
        }
        return left;

    }
    public Expression ParseBoolean(){
        List<TokenType> operators = [TokenType.And, TokenType.Or, TokenType.Greater, TokenType.Less, 
                                    TokenType.GreaterEqual, TokenType.LessEqual, TokenType.Equals, TokenType.NotEquals];
        Expression left = new UnaryVal(TokenPlus);
        Consume(TokenPlus.Type);
        LookAhead();
        while(operators.Contains(TokenPlus.Type)){
            Token operation = TokenPlus;
            Consume(TokenPlus.Type);
            LookAhead([TokenType.True, TokenType.False, TokenType.Int, TokenType.String]);
            Expression right = new UnaryVal(TokenPlus);
            Consume(TokenPlus.Type);
            left = new BooleanBinary(right, left, operation);
            LookAhead();
        }
        if(!left.Validation()){
            string error = "";
            foreach (var item in left.Errors){
                error+=item;
                error+="\n";
            }
            throw new Exception(error);
        }
        return left;
    }
    public Expression ParseString(){
        List<TokenType> Operations = [TokenType.Concat, TokenType.SpaceConcat];
        Expression left = new UnaryVal(TokenPlus);
        Consume(TokenType.String);
        LookAhead();
        while(Operations.Contains(TokenPlus.Type)){
            Token operation = TokenPlus;
            LookAhead(TokenType.String);
            Expression right = new UnaryVal(TokenPlus);
            Consume(TokenPlus.Type);
            left = new StringBinary(right, left, operation);
            LookAhead();
        }
        if(!left.Validation()){
            string error = "";
            foreach (var item in left.Errors){
                error+=item;
                error+="\n";
            }
            throw new Exception(error);
        }
        return left;
    }
    public Statement ParseSimple(){ //TODO
        // if(tokens[position].Type == TokenType.String) return ParseString();
        // if(tokens[position].Type == TokenType.True || tokens[position].Type == TokenType.False) return ParseBoolean();
        // if(tokens[position].Type == TokenType.LParen){
        //     Consume(TokenType.LParen);
        //     Expression expression = ParseExpr();
        //     Consume(TokenType.RParen);
        //     if(!expression.Validation()){
        //         string error = "";
        //             foreach (var item in expression.Errors){
        //                 error+=item;
        //                 error+="\n";
        //             }
        //         throw new Exception(error);
        //     }
        //     return expression;
        // }
        if(TokenPlus.Type == TokenType.Identifier){
            Token id = TokenPlus;
            Consume(TokenType.Identifier);
            LookAhead();
            if(TokenPlus.Type is TokenType.Assignation){
                Consume(TokenType.Assignation);
                var statement = Enunciation(id);
                return statement;
            }
            throw new Exception($"= was expected at line: {TokenPlus.Location.Line}, column: {TokenPlus.Location.Column}");
        }
        throw new Exception($"An error ocured at line: {TokenPlus.Location.Line}, column: {TokenPlus.Location.Column}");
    }
    public Expression ParseExp(){
        throw new NotImplementedException();
    }
    public Statement ParseIf(){
        Token IF = TokenPlus;
        Consume([TokenType.If, TokenType.LParen]);
        Expression condition = ParseBoolean();
        Consume(TokenType.RParen);
        Consume(TokenType.LCurlyB);
        Statement body = ParseBody();
        Consume(TokenType.RCurlyB);
        LookAhead();
        if(TokenPlus.Type == TokenType.LCurlyB){
            Consume(TokenType.LCurlyB);
            Statement elsebody = ParseBody();
            Consume(TokenType.RCurlyB);
            return new IF(body, condition, IF.Location, elsebody);
        }
        return new IF(body, condition, IF.Location);    
    }
    public Statement ParseFor(){
        Consume([TokenType.For]);
        LookAhead(TokenType.Identifier);
        Token id = TokenPlus;
        Consume([TokenType.Identifier, TokenType.In]);
        LookAhead(TokenType.Identifier);
        Expression collection = ParseExp();
        LookAhead();
        if(TokenPlus.Type == TokenType.LCurlyB){
            Consume(TokenType.LCurlyB);
            Statement body = ParseBody();
            Consume(TokenType.RCurlyB);
            return new For(collection, body, Scope.Global, id);
        }
        return new For(collection, ParseInst(), Scope.Global, id);

    }
    public Statement ParseWhile(){
        Token While = TokenPlus;
        Consume([TokenType.While, TokenType.LParen]);
        Expression condition = ParseBoolean();
        Consume(TokenType.RParen);
        LookAhead();
        if(TokenPlus.Type == TokenType.RCurlyB){
            Consume(TokenType.RCurlyB);
            Statement body = ParseBody();
            Consume(TokenType.RCurlyB);
            return new While(body, condition, While.Location);
        }
        return new While(ParseInst(), condition, While.Location);
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
    public Action ParseAction(){
        Consume(new List<TokenType>() {TokenType.Action, TokenType.Colon, TokenType.LParen});
        LookAhead(TokenType.Targets);
        Token targets = TokenPlus;
        Consume(new List<TokenType>() {TokenType.Targets, TokenType.Comma});
        LookAhead(TokenType.Context);
        Token context = TokenPlus;
        Consume(new List<TokenType>() {TokenType.Context, TokenType.LParen, TokenType.Implication});
        LookAhead();
        if(TokenPlus.Type != TokenType.LCurlyB) return new Action(targets, context, ParseSimple());
        Consume(TokenType.LCurlyB);
        Statement body = ParseBody();
        Consume(TokenType.RCurlyB);
        Action action = new Action(targets, context, body);
        return action;
    }

    public Statement ParseBody(){
        LookAhead();
        List<Statement> statements = [];
        while(TokenPlus.Type != TokenType.RCurlyB){
            switch(TokenPlus.Type){
                case TokenType.If:
                    statements.Add(ParseIf());
                    break;
                case TokenType.For:
                    statements.Add(ParseFor());
                    break;
                case TokenType.While:
                    statements.Add(ParseWhile());
                    break;
                case TokenType.Semicolon:
                    Consume(TokenType.Semicolon);
                    break;
                default:
                    statements.Add(ParseSimple());
                    break;
            }
            LookAhead();
        }
        Statement body = new EnunBlock(statements);
        return body;
    }
    public Statement ParseInst(){
        LookAhead();
        List<Statement> statements = [];
        switch(TokenPlus.Type){
            case TokenType.If:
                statements.Add(ParseIf());
                break;
            case TokenType.For:
                statements.Add(ParseFor());
                break;
            case TokenType.While:
                statements.Add(ParseWhile());
                break;
            default:
                statements.Add(ParseSimple());
                break;
        }
        Statement body = new EnunBlock(statements);
        return body;
    }
    public EffectDSL ParseEffect(){
        Expression? Name = null;
        Dictionary<string, Expression>? Params = null;
        Action? Action = null;;
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
        
    #region Card

    public ICard ParseCard(){
        Expression? Name = null;
        Expression? Power = null;
        Expression? Type = null;
        Expression? Faction = null;
        List<Expression>? Ranges = null;
        List<SavedEffect>? Activation = null;

        List<TokenType> needed = [TokenType.Name, TokenType.Power, TokenType.Type, TokenType.Faction, TokenType.Range, TokenType.OnActivation];
        List<TokenType> punctuation = [TokenType.Comma, TokenType.RCurlyB];
        Consume([TokenType.Card, TokenType.LCurlyB]);
        LookAhead(needed);
        while(needed.Contains(TokenPlus.Type)){
            if(TokenPlus.Check(TokenType.Name)) Name = ParseName();
            if(TokenPlus.Check(TokenType.Power)) Power = ParsePower();
            if(TokenPlus.Check(TokenType.Faction)) Faction = ParseFaction();
            if(TokenPlus.Check(TokenType.Type)) Type = ParseType();
            else if(TokenPlus.Check(TokenType.Range)) Ranges = ParseRange();
            Activation = ParseActivation();
            LookAhead(punctuation);
            if(TokenPlus.Check(TokenType.Comma)) 
                Consume(TokenType.Comma);
            else 
                break;
            needed.Remove(TokenPlus.Type);
            LookAhead();
        }
        Consume(TokenType.RCurlyB);
        switch((string)Type.Implement()){
            case "Leader":
                if(Name != null && Faction != null && Activation != null){ 
                 ICard card = new Leader(Name, Faction, Type, Activation);
                 return card;
                }
                else throw new Exception("There are Parameters to fill");
            case "Golden":
                if(Name != null && Power != null && Faction != null && Ranges != null && Activation != null){ 
                 ICard card = new Golden(Name, Power, Faction, Type, Ranges, Activation);
                 return card;
                }
                else throw new Exception("There are Parameters to fill");
            case "Silver":
                if(Name != null && Power != null && Faction != null && Ranges != null && Activation != null){ 
                 ICard card = new Silver(Name, Power, Faction, Type, Ranges, Activation);
                 return card;
                }
                else throw new Exception("There are Parameters to fill");
            case "Dummy":
                if(Name != null && Power != null && Faction != null && Ranges != null && Activation != null){ 
                 ICard card = new Dummy(Name, Power, Faction, Type, Ranges, Activation);
                 return card;
                }
                else throw new Exception("There are Parameters to fill");
            case "Buff":
                if(Name != null && Faction != null && Ranges != null && Activation != null){ 
                 ICard card = new Buff(Name, Faction, Type, Ranges, Activation);
                 return card;
                }
                else throw new Exception("There are Parameters to fill");
            default:
                if(Name != null && Faction != null && Ranges != null && Activation != null){ 
                 ICard card = new Weather(Name, Faction, Type, Ranges, Activation);
                 return card;
                }
                else throw new Exception("There are Parameters to fill");
        }

    }
    public Expression ParsePower(){
        Consume([TokenType.Power, TokenType.Colon]);
        LookAhead(TokenType.Int);
        return ParseNum();
    }
    public Expression ParseFaction(){
        Consume([TokenType.Faction, TokenType.Colon]);
        LookAhead(TokenType.String);
        return ParseString();
    }
    public Expression ParseType(){
        Consume([TokenType.Type, TokenType.Comma]);
        LookAhead(TokenType.String);
        return ParseString();
    }
    public List<Expression> ParseRange(){
        List<Expression> output = [];
        Consume([TokenType.Range, TokenType.Colon, TokenType.LBracket]);
        LookAhead([TokenType.String, TokenType.RBracket]);
        while(!TokenPlus.Check(TokenType.RBracket)){
            output.Add(ParseString());
            LookAhead([TokenType.Comma, TokenType.RBracket]);
            if(TokenPlus.Check(TokenType.Comma)) Consume(TokenType.Comma);
            LookAhead();
        }
        Consume(TokenType.RBracket);
        return output;
    }
    public List<SavedEffect> ParseActivation(){
        throw new NotImplementedException();
    }

    #endregion
}