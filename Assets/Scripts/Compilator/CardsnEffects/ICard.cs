using System.Collections.Generic;

public interface ICard{
    string Name { get;}
    string Faction { get;}
    double Power { get;}
    double OriginalPower { get;}
    string Type { get;}
    List<string> Ranges { get;}
    List<SavedEffect> Effects { get;}
}
public class Leader : ICard
{
    string name;
    string faction;
    double power;
    double ogPower;
    string type;
    List<SavedEffect> effects;

    public Leader(string Name, string Faction, double Power, string Type, List<SavedEffect> Effects){
        name = Name;
        faction = Faction;
        type = Type;
        power = Power;
        ogPower = Power;
        effects = Effects;
    }
    public string Faction => faction;

    public List<SavedEffect> Effects => effects;

    string ICard.Name => name;
    
    public double Power => power;
    public double OriginalPower => ogPower;
    public List<string> Ranges => new List<string>();

    string ICard.Type => type;

}

public class Golden : ICard
{
    string name;
    double power;
    double ogPower;
    string faction;
    string type;
    List<string> ranges;
    List<SavedEffect> effects;

    public Golden(string Name, string Faction, double Power, string Type, List<string> Ranges, List<SavedEffect> Effects){
        name = Name;
        power = Power;
        ogPower = Power;
        faction = Faction;
        type = Type;
        ranges = Ranges;
        effects = Effects;
    }

    public string Name => name;

    public double Power => power;
    public double OriginalPower => ogPower;

    string ICard.Faction => faction;

    string ICard.Type => type;

    public List<string> Ranges => ranges;

    public List<SavedEffect> Effects => effects;
}

public class Silver : ICard
{
    string name;
    double power;
    double ogPower;
    string faction;
    string type;
    List<string> ranges;
    List<SavedEffect> effects;

    public Silver(string Name, string Faction, double Power, string Type, List<string> Ranges, List<SavedEffect> Effects){
        name = Name;
        power = Power;
        ogPower = Power;
        faction = Faction;
        type = Type;
        ranges = Ranges;
        effects = Effects;
    }

    public List<SavedEffect> Effects => effects;

    string ICard.Name => name;
    
    public double Power => power;
    public double OriginalPower => ogPower;

    string ICard.Faction => faction;

    public string Type => type;

    public List<string> Ranges => ranges;
}

public class Dummy : ICard
{
    string name;
    double power;
    double ogPower;
    string faction;
    string type;
    List<string> ranges;
    List<SavedEffect> effects;

    public Dummy(string Name, string Faction, double Power, string Type, List<string> Ranges, List<SavedEffect> Effects){
        name = Name;
        power = Power;
        ogPower = Power;
        faction = Faction;
        type = Type;
        ranges = Ranges;
        effects = Effects;
    }

    public List<SavedEffect> Effects => effects;

    string ICard.Name => name;

    public double Power => power;
    public double OriginalPower => ogPower;

    string ICard.Faction => faction;

    string ICard.Type => type;

    public List<string> Ranges => ranges;
}

public class Buff : ICard
{
    string name;
    string faction;
    double power;
    double ogPower;
    string type;
    List<string> ranges;
    List<SavedEffect> effects;

    public Buff(string Name, string Faction, double Power, string Type, List<string> Ranges, List<SavedEffect> Effects){
        name = Name;
        faction = Faction;
        power = Power;
        ogPower = Power;
        type = Type;
        ranges = Ranges;
        effects = Effects;
    }

    public List<SavedEffect> Effects => effects;

    string ICard.Name => name;

    string ICard.Faction => faction;

    string ICard.Type => type;
    public double Power => power;
    public double OriginalPower => ogPower;

    public List<string> Ranges => ranges;
}

public class Weather : ICard
{
    string name;
    string faction;
    double power;
    double ogPower;
    string type;
    List<string> ranges;
    List<SavedEffect> effects;

    public Weather(string Name, string Faction, double Power, string Type, List<string> Ranges, List<SavedEffect> Effects){
        name = Name;
        faction = Faction;
        power = Power;
        ogPower = Power;
        type = Type;
        ranges = Ranges;
        effects = Effects;
    }

    public List<SavedEffect> Effects => effects;

    string ICard.Name => name;

    string ICard.Faction => faction;

    string ICard.Type => type;
    double ICard.Power => power;
    public double OriginalPower => ogPower;

    public List<string> Ranges => ranges;
}