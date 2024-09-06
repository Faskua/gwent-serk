using System;
using System.Collections.Generic;

public class Action{
    Token Target { get; }
    Token Context { get; }
    public Statement Block { get; }

    public Action(Token target, Token context, Statement block){
        Target = target;
        Context = context;
        Block = block;
    }
}

public class GameContext : ExpressionDSL
{
    public static GameContext? context;
    Board board;
    public override IDType Type => throw new NotImplementedException();

    public override CodeLocation Location { get => throw new NotImplementedException(); protected set => throw new NotImplementedException(); }

    public override object? Implement()
    {
        throw new NotImplementedException();
    }

    public override bool Validation()
    {
        throw new NotImplementedException();
    }
}

public class Selector : ExpressionDSL<object>
{
    Token selector;
    ExpressionDSL Source { get;}
    ExpressionDSL? Single { get;}
    Predicate predicate { get;}
    ExpressionDSL Parent;
    public Selector(Token selector, ExpressionDSL source, Predicate predicate, ExpressionDSL parent, ExpressionDSL? single = null){
        this.selector = selector;
        this.predicate = predicate;
        Source = source;
        Parent = parent;
        Single = single;
    }

    public override IDType Type => IDType.List;

    public override CodeLocation Location { get => selector.Location; protected set => throw new NotImplementedException(); }

    //TODO
    public override object Implement()
    {
        throw new NotImplementedException();
    }

    public override bool Validation()
    {
        if(!Source.CheckType(IDType.String)) this.Errors.Add($"Unvalid Source at line: {Location.Line}, column: {Location.Column}");
        else if(!Source.Validation()) this.Errors.AddRange(Source.Errors);
        else if((string)Source.Implement() == "parent" && Parent is null) this.Errors.Add($"Parent not defined at line: {Location.Line}, column: {Location.Column}");

        if(!Single.CheckType(IDType.Boolean)) this.Errors.Add($"Unvalid Single at line: {Location.Line}, column: {Location.Column}");
        if(!Single.Validation()) this.Errors.AddRange(Single.Errors);

        if(!predicate.Validation()) this.Errors.AddRange(predicate.Errors);
        
        if(Errors.Count != 0){
            string error = "";
            foreach (var item in Errors){
                error += item;
                error += "\n=";
            }
            throw new Exception(error);
        }
        return true;
    }
}

public class Predicate : ExpressionDSL<object>
{
    Token predicate;
    ExpressionDSL expression;
    Scope scope;
    public Predicate(Token token, ExpressionDSL expr, Scope scope){
        predicate = token;
        expression = expr;
        this.scope = scope;
    }

    public override CodeLocation Location { get => predicate.Location; protected set => throw new NotImplementedException(); }

    public override IDType Type => throw new NotImplementedException();

    public override object Implement(){
        throw new NotImplementedException();
    }

    public override bool Validation(){
        if(!expression.CheckType(IDType.Boolean)) Errors.Add($"The Predicate at line: {Location.Line},column: {Location.Column} is not a boolean");
        return Errors.Count == 0;
    }
}

class Board
{
    public Dictionary<string, List<ICard>> Campo;
    public Player player;
    public Player enemy;
    public Board(Player player, Player enemy){
        Campo.Add("MeleePlayer", player.Cards["Melee"]);
        Campo.Add("RangePlayer", player.Cards["Range"]);
        Campo.Add("SiegePlayer", player.Cards["Siege"]);
        Campo.Add("MeleeClimagePlayer", player.Cards["MeleeClimage"]);
        Campo.Add("RangeClimagePlayer", player.Cards["RangeClimage"]);
        Campo.Add("SiegeClimagePlayer", player.Cards["SiegeClimage"]);
        Campo.Add("PlayerGraveyard", player.Cards["Graveyard"]);
        Campo.Add("MeleeEnemy", enemy.Cards["Melee"]);
        Campo.Add("RangeEnemy", enemy.Cards["Range"]);
        Campo.Add("SiegeEnemy", enemy.Cards["Siege"]);
        Campo.Add("MeleeClimageEnemy", enemy.Cards["MeleeClimage"]);
        Campo.Add("RangeClimageEnemy", enemy.Cards["RangeClimage"]);
        Campo.Add("SiegeClimageEnemy", enemy.Cards["SiegeClimage"]);
        Campo.Add("EnemyGraveyard", enemy.Cards["Graveyard"]);
        this.player = player;
        this.enemy = enemy;
    }
}

public class Faction{
    public ICard Leader;
    public string Name { get;}
    public Faction(string name, ICard leader){
        Name = name;
        Leader = leader;
    }
    public void SaveFaction(){
        Factions.AddFaction(this);
    }
}

public static class Factions{
    public static Dictionary<string, Faction> factions { get; set;}
    public static void AddFaction(Faction faction){
        factions.Add(faction.Name, faction);
    }
    public static Faction GetFaction(string name){
        if(factions.ContainsKey(name)){
            return factions[name];
        }
        throw new Exception("Faction not defined");
    }
}

class Player
{
    public Dictionary<string, List<ICard>> Cards;
    public int Points;
    public int MeleePoints;
    public int RangePoints;
    public int SiegePoints;
    public Player(List<ICard> deck){
        Cards.Add("Deck", deck);
        Cards.Add("Melee", new List<ICard>());
        Cards.Add("Range", new List<ICard>());
        Cards.Add("Siege", new List<ICard>());
        Cards.Add("Graveyard", new List<ICard>());
        Cards.Add("MeleeClimage", new List<ICard>());
        Cards.Add("RangeClimage", new List<ICard>());
        Cards.Add("SiegeClimage", new List<ICard>());
    }
    // public void RefreshPoints(){
    //     int aux = 0;
    // }
}