using System.Data.Common;
using System.Dynamic;

// public class CardParser
// {
//     public CardParser(TokenStream stream) {Stream = stream;}
//     public TokenStream Stream { get; private set; }
//     public void CheckSemantic(List<Token> tokens, List<CompilingError> errors)
//     {
//         if (Stream.InPosition(0).Value != "card") errors.Add(new CompilingError(ErrorType.Expected, tokens[0].Location, "You need to define a 'card'"));
//         if (!Stream.Next("{"))
//         {
//             errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, "{ expected"));
//         }
//         if (!Stream.Next("Type"))
//         {
//             errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, "Type field expected"));
//         }
//         if (!Stream.Next(":"))
//         {
//             errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, ": expected"));
//         }
//         if (!Stream.Next(TokenType.Text))
//         {
//             errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, "You need to insert the type"));
//         }
//         if(!Stream.Next(","))
//         {
//             errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, ", expected"));
//         }
//         if (!Stream.Next("Name"))
//         {
//             errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, "Name field expected"));
//         }
//         if (!Stream.Next(":"))
//         {
//             errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, ": expected"));
//         }
//         if (!Stream.Next(TokenType.Text))
//         {
//             errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, "You need to insert the name"));
//         }
//         if(!Stream.Next(","))
//         {
//             errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, ", expected"));
//         }
//         if (!Stream.Next("Power"))
//         {
//             errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, "Power field expected"));
//         }
//         if (!Stream.Next(":"))
//         {
//             errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, ": expected"));
//         }
//         if (!Stream.Next(TokenType.Number))
//         {
//             errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, "You need to insert the power"));
//         }
//         if(!Stream.Next(","))
//         {
//             errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, ", expected"));
//         }
//         if(!Stream.Next("Range"))
//         {
//             errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, "Range field expected"));
//         }
//         if(!Stream.Next(":"))
//         {
//             errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, ": expected"));
//         }
//         if(Stream.InPosition(Stream.Position + 1).Value != "Melee" || Stream.InPosition(Stream.Position + 1).Value != "Ranged" || Stream.InPosition(Stream.Position + 1).Value != "Siege")
//         {
//             if(!Stream.Next("[")) 
//             { errors.Add(new CompilingError(ErrorType.Expected,Stream.LookAhead().Location, "[ expected")); }
//             else{
//                 while(Stream.InPosition(Stream.Position + 1).Value != "]"){
//                     if(!Stream.Next(TokenType.Text)){
//                         errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, "You need to insert the range"));
//                     }
//                     if(!Stream.Next(",")){
//                         errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, ", expected"));
//                     }
//                 }
//             }
//         }
//         if(!Stream.Next(","))
//         {
//             errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, ", expected"));
//         }
//         // if (!Stream.Next("OnActivation")) // en el onActivation hay que revisar tallitas
//         // {
//         //     errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, "OnActivation field expected"));
//         // }
//         // if (!Stream.Next(":"))
//         // {
//         //     errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, ": expected"));
//         // }
//         // if (!Stream.Next("["))
//         // {
//         //     errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, "[ expected"));
//         // }
//         // if(!Stream.Next("{"))
//         // {
//         //     errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, "{ expected"));
//         // }
//         // if (!Stream.Next("Effect"))
//         // {
//         //     errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, "Effect field expected"));
//         // }
//         // if (!Stream.Next(":"))
//         // {
//         //     errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, ": expected"));
//         // }
//         // if (!Stream.Next("{"))
//         // {
//         //     errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, "{"));
//         // }
//         // if(!Stream.Next("Name"))
//         // {
//         //     errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, "Name field expected"));
//         // }
//         // if (!Stream.Next(":"))
//         // {
//         //     errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, ": expected"));
//         // }
//         // if (!Stream.Next(TokenType.Text))
//         // {
//         //     errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, "You need to insert the name"));
//         // }
//         // if (!Stream.Next(","))
//         // {
//         //     errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, ", expected"));
//         // }
//         // if(!Stream.Next(","))
//         // {
//         //     errors.Add(new CompilingError(ErrorType.Expected, Stream.LookAhead().Location, ", expected"));
//         // }
//     }
// }


public class Parser
{
    public Parser(List<Token> tokens)
    {
        Stream = new TokenStream(tokens);
        Tokens = tokens;
    }
    public TokenStream Stream {get; private set;}

    public List<Token> Tokens {get; private set;}

    
    
}