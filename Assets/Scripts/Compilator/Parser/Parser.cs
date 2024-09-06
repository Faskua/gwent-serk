using System.Data.Common;
using System.Dynamic;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;

public class Parsel
{
    //Tengo que tener un stack con los scope para controlar las variables
    public List<Token> tokens {get; private set;}
    public List<string> Errores = new List<string>();
    Stack<Scope> Scopes;
    public Parsel(List<Token> tokens){ this.tokens = tokens;}
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
        LookAhead(new List<TokenType>(){type});
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
    public ExpressionDSL ParseNum(){
        List<string> Operations = new List<string>(){"+", "-", "*", "/", "^"};
        Consume(TokenType.Int);
        ExpressionDSL left = new UnaryVal(tokens[position]);
        LookAhead();
        while(Operations.Contains(TokenPlus.Value)){
            Token operation = TokenPlus;
            Consume(TokenPlus.Type);
            LookAhead(TokenType.Int);
            ExpressionDSL right = new UnaryVal(TokenPlus);
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
    public ExpressionDSL ParseBoolean(){
        List<TokenType> operators = new List<TokenType>(){TokenType.And, TokenType.Or, TokenType.Greater, TokenType.Less, 
                                    TokenType.GreaterEqual, TokenType.LessEqual, TokenType.Equals, TokenType.NotEquals};
        ExpressionDSL left = new UnaryVal(TokenPlus);
        Consume(TokenPlus.Type);
        LookAhead();
        while(operators.Contains(TokenPlus.Type)){
            Token operation = TokenPlus;
            Consume(TokenPlus.Type);
            LookAhead(new List<TokenType>(){TokenType.True, TokenType.False, TokenType.Int, TokenType.String});
            ExpressionDSL right = new UnaryVal(TokenPlus);
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
    public ExpressionDSL ParseString(){
        List<TokenType> Operations = new List<TokenType>(){TokenType.Concat, TokenType.SpaceConcat};
        ExpressionDSL left = new UnaryVal(TokenPlus);
        Consume(TokenType.String);
        LookAhead();
        while(Operations.Contains(TokenPlus.Type)){
            Token operation = TokenPlus;
            LookAhead(TokenType.String);
            ExpressionDSL right = new UnaryVal(TokenPlus);
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
        // }\
        if (Scopes.Count == 0) Scopes.Push(Scope.Global);
        if(TokenPlus.Type == TokenType.Identifier){
            Token id = TokenPlus;
            Consume(TokenType.Identifier);
            LookAhead();
            if(TokenPlus.Type is TokenType.Assignation){
                Consume(TokenType.Assignation);
                LookAhead();
                ExpressionDSL expression = ParseExp();
                LookAhead();
                if(TokenPlus.Type != TokenType.Semicolon) Errores.Add($"A ; was expected at line: {TokenPlus.Location.Line}, column: {TokenPlus.Location.Column}");
                Statement statement = new Enunciation(id, Scopes.Peek(), expression);
                return statement;
            }
            
        }
        throw new Exception($"An error ocured at line: {TokenPlus.Location.Line}, column: {TokenPlus.Location.Column}");
    }
    public ExpressionDSL ParseExp(){
        throw new NotImplementedException();
    }
    public Statement ParseIf(){
        Token IF = TokenPlus;
        Consume(new List<TokenType>(){TokenType.If, TokenType.LParen});
        ExpressionDSL condition = ParseBoolean();
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
        Consume(TokenType.For);
        LookAhead(TokenType.Identifier);
        Token id = TokenPlus;
        Consume(new List<TokenType>(){TokenType.Identifier, TokenType.In});
        LookAhead(TokenType.Identifier);
        ExpressionDSL collection = ParseExp();
        LookAhead();
        if(TokenPlus.Type == TokenType.LCurlyB){
            Consume(TokenType.LCurlyB);
            Statement body = ParseBody();
            Consume(TokenType.RCurlyB);
            return new For(collection, body, Scope.Global, id);
        }
        return new For(collection, ParseSimple(), Scope.Global, id);

    }
    public Statement ParseWhile(){
        Token While = TokenPlus;
        Consume(new List<TokenType>(){TokenType.While, TokenType.LParen});
        ExpressionDSL condition = ParseBoolean();
        Consume(TokenType.RParen);
        LookAhead();
        if(TokenPlus.Type == TokenType.RCurlyB){
            Consume(TokenType.RCurlyB);
            Statement body = ParseBody();
            Consume(TokenType.RCurlyB);
            return new While(body, condition, While.Location);
        }
        return new While(ParseSimple(), condition, While.Location);
    }
    #endregion

    public List<DSL> Parse(){
        List<DSL> CardsNEffects = new List<DSL>();
        LookAhead();
        while(TokenPlus.Type == TokenType.Card || TokenPlus.Type == TokenType.Effect){
            if(TokenPlus.Type == TokenType.Card){
                CardsNEffects.Add(ParseCard());
            }
            if(TokenPlus.Type == TokenType.Effect){
                CardsNEffects.Add(ParseEffect());
            }
        }
        return CardsNEffects;
    }

    #region Effect
    public ExpressionDSL ParseName(){
        List<TokenType> expected = new List<TokenType>(){TokenType.Name, TokenType.Colon, TokenType.String};
        Consume(expected);
        return new UnaryVal(tokens[position]);
    }
    public ExpressionDSL ParseAmount(){
        List<TokenType> expected = new List<TokenType>(){TokenType.Amount, TokenType.Colon, TokenType.Int};
        Consume(expected);
        return new UnaryVal(tokens[position]);
    }
    public Dictionary<string, ExpressionDSL> ParseParam(){
        Dictionary<string, ExpressionDSL> param = new Dictionary<string, ExpressionDSL>();
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
        List<Statement> statements = new List<Statement>();
        while(TokenPlus.Type != TokenType.RCurlyB){
            switch(TokenPlus.Type){
                case TokenType.If:
                    statements.Add(ParseIf());
                    LookAhead();
                    if(!TokenPlus.Check(TokenType.Semicolon)){
                        Errores.Add($"A ; was expected at line: {TokenPlus.Location.Line}, column: {TokenPlus.Location.Column}");
                        continue;
                    }
                    Consume(TokenType.Semicolon);
                    break;
                case TokenType.For:
                    statements.Add(ParseFor());
                    LookAhead();
                    if(!TokenPlus.Check(TokenType.Semicolon)){ 
                        Errores.Add($"A ; was expected at line: {TokenPlus.Location.Line}, column: {TokenPlus.Location.Column}");
                        continue;
                    }
                    Consume(TokenType.Semicolon);
                    break;
                case TokenType.While:
                    statements.Add(ParseWhile());
                    LookAhead();
                    if(!TokenPlus.Check(TokenType.Semicolon)) {
                        Errores.Add($"A ; was expected at line: {TokenPlus.Location.Line}, column: {TokenPlus.Location.Column}");
                        continue;
                    }
                    Consume(TokenType.Semicolon);
                    break;
                default:
                    statements.Add(ParseSimple());
                    LookAhead();
                    if(!TokenPlus.Check(TokenType.Semicolon)) {
                        Errores.Add($"A ; was expected at line: {TokenPlus.Location.Line}, column: {TokenPlus.Location.Column}");
                        continue;
                    }
                    Consume(TokenType.Semicolon);
                    break;
            }
            LookAhead();
        }
        Statement body = new EnunBlock(statements);
        return body;
    }
    public EffectDSL ParseEffect(){
        ExpressionDSL Name = null;
        Dictionary<string, ExpressionDSL> Params = null;
        Action Action = null;;
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
        ExpressionDSL? Name = null;
        string name = "";
        ExpressionDSL? Power = null;
        double power = 0;
        ExpressionDSL? Type = null;
        string type = "";
        ExpressionDSL? Faction = null;
        string faction = "";
        List<ExpressionDSL>? Ranges = null;
        List<string> ranges = new List<string>();
        List<SavedEffect>? Activation = null;

        List<TokenType> needed = new List<TokenType>(){TokenType.Name, TokenType.Power, TokenType.Type, TokenType.Faction, TokenType.Range, TokenType.OnActivation};
        List<TokenType> punctuation = new List<TokenType>() {TokenType.Comma, TokenType.RCurlyB};
        Consume(new List<TokenType>(){TokenType.Card, TokenType.LCurlyB});
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
        if(Name is not null){
            if(Name.Validation()) name = (string)Name.Implement();
            else Errores.AddRange(Name.Errors);
        }
        if(Power is not null){
            if(Power.Validation()) power = ((Int)Power.Implement()).Value;
            else Errores.AddRange(Power.Errors);
        }
        if(Type is not null){
            if(Type.Validation()) type = (string)Type.Implement();
            else Errores.AddRange(Type.Errors);
        }if(Faction is not null){
            if(Faction.Validation()) faction = (string)Faction.Implement();
            else Errores.AddRange(Faction.Errors);
        }
        if(Ranges.Count > 0){
            foreach(var rango in Ranges){
                if(rango.Validation()) ranges.Add((string)rango.Implement());
                else Errores.AddRange(rango.Errors);
            }
        }

        if(faction == "Sacrificios" || faction == "Falconia"){
            switch(type){
                    case "Leader":
                        if(Name != null && Faction != null && Activation != null){ 
                        ICard card = new Leader(name, faction, power, type, Activation);
                        return card;
                        }
                        else throw new Exception("There are Parameters to fill");
                    case "Golden":
                        if(Name != null && Power != null && Faction != null && Ranges != null && Activation != null){ 
                        ICard card = new Golden(name, faction, power, type, ranges, Activation);
                        return card;
                        }
                        else throw new Exception("There are Parameters to fill");
                    case "Silver":
                        if(Name != null && Power != null && Faction != null && Ranges != null && Activation != null){ 
                        ICard card = new Silver(name, faction, power, type, ranges, Activation);
                        return card;
                        }
                        else throw new Exception("There are Parameters to fill");
                    case "Dummy":
                        if(Name != null && Power != null && Faction != null && Ranges != null && Activation != null){ 
                        ICard card = new Dummy(name, faction, power, type, ranges, Activation);
                        return card;
                        }
                        else throw new Exception("There are Parameters to fill");
                    case "Buff":
                        if(Name != null && Faction != null && Ranges != null && Activation != null){ 
                        ICard card = new Buff(name, faction, power, type, ranges, Activation);
                        return card;
                        }
                        else throw new Exception("There are Parameters to fill");
                    default:
                        if(Name != null && Faction != null && Ranges != null && Activation != null){ 
                        ICard card = new Weather(name, faction, power, type, ranges, Activation);
                        return card;
                        }
                        else throw new Exception("There are Parameters to fill");
                }
        }
        else Errores.Add($"Unvalid Faction at line: {Faction.Location.Line}, column: {Faction.Location.Column}");
        return null;
    }
    public ExpressionDSL ParsePower(){
        Consume(new List<TokenType>(){TokenType.Power, TokenType.Colon});
        LookAhead(TokenType.Int);
        return ParseNum();
    }
    public ExpressionDSL ParseFaction(){
        Consume(new List<TokenType>(){TokenType.Faction, TokenType.Colon});
        LookAhead(TokenType.String);
        return ParseString();
    }
    public ExpressionDSL ParseType(){
        Consume(new List<TokenType>(){TokenType.Type, TokenType.Comma});
        LookAhead(TokenType.String);
        return ParseString();
    }
    public List<ExpressionDSL> ParseRange(){
        List<ExpressionDSL> output = new List<ExpressionDSL>();
        Consume(new List<TokenType>(){TokenType.Range, TokenType.Colon, TokenType.LBracket});
        LookAhead(new List<TokenType>(){TokenType.String, TokenType.RBracket});
        while(!TokenPlus.Check(TokenType.RBracket)){
            output.Add(ParseString());
            LookAhead(new List<TokenType>(){TokenType.Comma, TokenType.RBracket});
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