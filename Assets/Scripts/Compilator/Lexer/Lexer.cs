using System.Runtime.Serialization;
using System.Text.RegularExpressions;

public class Lexer
{

    public static Regex tokenExpression = new Regex (
        @"(?<Boolean>\b(true|false|==)\b)|
          (?<Symbol>[@@])|
          (?<String>""(?:[^""\\]|\\.)*"")|
          (?<Int>\b\d+(\.\d+)?\b)|
          (?<Number>\bNumber\b)|
          (?<Text>\bText\b)|
          (?<Bool>\bBool\b)|
          (?<Operation>\b\+\-\/\*\b)|
          (?<Greater>>)|
          (?<Less><)|
          (?<GreaterEqual>>=)|
          (?<LessEqual><=)|
          (?<Assignation>\=)|
          (?<Implication>\=>\b)|
          (?<Comma>,)|
          (?<Semicolon>;)|
          (?<Colon>:)|
          (?<Dot>\.)|
          (?<Loop>\b(for|while)\b)|
          (?<LBracket>\[)|
          (?<LParen>\()|
          (?<LCurlyB>\{)|
          (?<RBracket>\])|
          (?<RParen>\))|
          (?<RCurlyB>\})|
          (?<Card>\b(Card|card)\b)|
          (?<Name>\bName\b)|
          (?<Type>\bType\b)|
          (?<Faction>\bFaction\b)|
          (?<Range>\bRange\b)|
          (?<Power>\bPower\b)|
          (?<Board>\bBoard\b)|
          (?<Targets>\btargets\b)|
          (?<Effect>\b(Effect|effect)\b)|
          (?<Predicate>\bPredicate\b)|
          (?<PostAction>\bPostAction\b)|
          (?<OnActivation>\bOnActivation\b)|
          (?<Action>\bAction\b)|
          (?<Params>\bParams\b)|
          (?<Source>\bSource\b)|
          (?<Single>\bSingle\b)|
          (?<Selector>\bSelector\b)|
          (?<In>\bin\b)|
          (?<Identifier>\b[a-zA-Z_][a-zA-Z0-9_]*\b)|
          (?<Whitespace>[\s\t]+)",
        RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace
    );

    public List<Token> Tokenizer(string input, string fileName, List<CompilingError> Erors)
    {
        List<Token> tokens = [];
        MatchCollection matches = tokenExpression.Matches(input);
        string RemainingInput = input;
        int Line = 1;
        int Column = 1;
        int Last = 0;
        foreach (var match in matches.ToList())
        {
            for (int i = Last; i < match.Index; i++)
            {
                if ( input[i] == '\n')
                {
                    Line += 1;
                    Column = 1;
                }
                Column += 1;
            }
            Last = match.Index;
            if (match.Groups["Symbol"].Success) {
                tokens.Add(new Token(TokenType.Symbol, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if (match.Groups["Boolean"].Success){
                tokens.Add(new Token(TokenType.Boolean, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if (match.Groups["Identifier"].Success){
                tokens.Add(new Token(TokenType.Identifier, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["String"].Success){
                tokens.Add(new Token(TokenType.String, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Int"].Success){
                tokens.Add(new Token(TokenType.Int, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Number"].Success){
                tokens.Add(new Token(TokenType.Number, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Text"].Success){
                tokens.Add(new Token(TokenType.Text, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Bool"].Success){
                tokens.Add(new Token(TokenType.Bool, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Operation"].Success){
                tokens.Add(new Token(TokenType.Operation, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Grater"].Success){
                tokens.Add(new Token(TokenType.Greater, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Less"].Success){
                tokens.Add(new Token(TokenType.Less, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["GreaterEqual"].Success){
                tokens.Add(new Token(TokenType.GreaterEqual, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["LessEqual"].Success){
                tokens.Add(new Token(TokenType.LessEqual, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Assignation"].Success){
                tokens.Add(new Token(TokenType.Assignation, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Implication"].Success){
                tokens.Add(new Token(TokenType.Implication, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Comma"].Success){
                tokens.Add(new Token(TokenType.Comma, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Semicolon"].Success){
                tokens.Add(new Token(TokenType.Semicolon, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Colon"].Success){
                tokens.Add(new Token(TokenType.Colon, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Dot"].Success){
                tokens.Add(new Token(TokenType.Dot, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Loop"].Success){
                tokens.Add(new Token(TokenType.Loop, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["LBracket"].Success){
                tokens.Add(new Token(TokenType.LBracket, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["LParen"].Success){
                tokens.Add(new Token(TokenType.LParen, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["LCurlyb"].Success){
                tokens.Add(new Token(TokenType.LCurlyB, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["RBracket"].Success){
                tokens.Add(new Token(TokenType.RBracket, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["RParen"].Success){
                tokens.Add(new Token(TokenType.RParen, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["RCurlyB"].Success){
                tokens.Add(new Token(TokenType.RCurlyB, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Card"].Success){
                tokens.Add(new Token(TokenType.Card, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Name"].Success){
                tokens.Add(new Token(TokenType.Name, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Type"].Success){
                tokens.Add(new Token(TokenType.Type, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Faction"].Success){
                tokens.Add(new Token(TokenType.Faction, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Range"].Success){
                tokens.Add(new Token(TokenType.Range, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Power"].Success){
                tokens.Add(new Token(TokenType.Power, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Board"].Success){
                tokens.Add(new Token(TokenType.Board, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Targets"].Success){
                tokens.Add(new Token(TokenType.Targets, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Effect"].Success){
                tokens.Add(new Token(TokenType.Effect, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Predicate"].Success){
                tokens.Add(new Token(TokenType.Predicate, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["PostAction"].Success){
                tokens.Add(new Token(TokenType.PostAction, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["OnActivation"].Success){
                tokens.Add(new Token(TokenType.OnActivation, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Action"].Success){
                tokens.Add(new Token(TokenType.Action, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Params"].Success){
                tokens.Add(new Token(TokenType.Params, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Source"].Success){
                tokens.Add(new Token(TokenType.Source, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Single"].Success){
                tokens.Add(new Token(TokenType.Single, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Selector"].Success){
                tokens.Add(new Token(TokenType.Selector, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["In"].Success){
                tokens.Add(new Token(TokenType.In, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            RemainingInput = RemainingInput.Substring(match.Length);
        }
        if (!string.IsNullOrEmpty(RemainingInput)){
            throw new Exception("Token not recognized");
        }
         return tokens;

   }
}
// {
//     //Diccioario con los tipos de tokens y sus expresiones
//     public Dictionary<TokenType, string> RegexExp = new Dictionary<TokenType, string>(){
//         {TokenType.Boolean, @"\b(true|false)\b"},
//         {TokenType.String, @"(?:[^""\\]|\\.)*"},
//         {TokenType.Int, @"\b\d+(\.\d+)?\b"},
//         {TokenType.Number, @"\bNumber\b"},
//         {TokenType.Text, @"\bText\b"},
//         {TokenType.Bool, @"\bBool\b"},
//         {TokenType.Operation, @"\+\-\*\/"}, //pendiente
//         {TokenType.Greater, @">"},
//         {TokenType.Less, @"<"},
//         {TokenType.GreaterEqual, @">="},
//         {TokenType.LessEqual, @"<="},
//         {TokenType.Assignation, @"="},
//         {TokenType.Semicolon, @";"},
//         {TokenType.Comma, @","},
//         {TokenType.Colon, @":"},
//         {TokenType.Dot, @"."},
//         {TokenType.Loop, @"(for|while)"},
//         {TokenType.Identifier, @"\b[a-zA-Z_][a-zA-Z0-9_]*\b"},
//         {TokenType.LBracket, @"\["},
//         {TokenType.LParen, @"\("},
//         {TokenType.LCurlyB, @"\{"},
//         {TokenType.RBracket, @"\]"},
//         {TokenType.RParen, @"\)"},
//         {TokenType.RCurlyB, @"\}"},
//         {TokenType.Card, @"\bcard\b"},
//         {TokenType.Name, @"\bName\b"},
//         {TokenType.Type, @"\bType\b"},
//         {TokenType.Faction, @"\bFaction\b"},
//         {TokenType.Range, @"\bRange\b"},
//         {TokenType.Power, @"\bPower\b"},
//         {TokenType.Board, @"\bBoard\b"},
//         {TokenType.Targets, @"\btargets\b"},
//         {TokenType.Effect, @"\beffect\b"},
//         {TokenType.Predicate, @"\bPredicate\b"},
//         {TokenType.PostAction, @"\bPostAction\b"},
//         {TokenType.OnActivation, @"\bOnActivation\b"},
//         {TokenType.Action, @"\bAction\b"},
//         {TokenType.Params, @"\bParams\b"},
//         {TokenType.Source, @"\bSource\b"},
//         {TokenType.Single, @"\bSingle\b"},
//         {TokenType.In, @"\bin\b"},
//         {TokenType.Implication, @"=>"},
//         {TokenType.SKIP, @"^\s+|^\/\/[^\n]*|^\/\*[\s\S]*?\*\/"}
//     };

//     public List<Token> Tokenize(string input, string fileName, List<CompilingError> errors){
//         List<Token> output = [];
//         int Line = 1;
//         int Column = 1;
//         string inputLeft = input;

//         while(!string.IsNullOrEmpty(inputLeft)){
//             bool DidMatch = false;
//             foreach(var expression in RegexExp){
//                 Match matches = Regex.Match(inputLeft, expression.Value);
//                 if ( matches.Success) {
//                     Column += matches.Value.Length;
//                     if(matches.Value.Contains("\n")){ //si encuentro un salto de linea se lo sumo y reinicio la columna
//                         Column = 1;
//                         int PlusLines = matches.Value.Count(l => l == '\n');
//                         Line += PlusLines;
//                     }
//                     if(expression.Key != TokenType.SKIP){
//                         output.Add(new Token(expression.Key, matches.Value, new CodeLocation(fileName, Line, Column)));
//                     }
//                     inputLeft = inputLeft.Substring(matches.Value.Length);
//                     DidMatch = true;
//                     break;
//                 }
//             }
//             if(!DidMatch){
//                 throw new Exception($"Unrecognized token at line {Line}, column {Column}");
//             }
//         }

//         return output;
//     }
//}