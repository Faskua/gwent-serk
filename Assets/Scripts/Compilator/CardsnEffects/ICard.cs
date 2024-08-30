public interface ICard{
    Expression Name { get;}
    Expression Faction { get;}
    Expression Type { get;}
    List<SavedEffect> Effects { get;}
}
public class Leader : ICard
{
    Expression name;
    Expression faction;
    Expression type;
    List<SavedEffect> effects;

    public Leader(Expression Name, Expression Faction, Expression Type, List<SavedEffect> Effects){
        name = Name;
        faction = Faction;
        type = Type;
        effects = Effects;
    }
    public Expression Faction => faction;

    public List<SavedEffect> Effects => effects;

    Expression ICard.Name => name;

    Expression ICard.Type => type;
}

public class Golden : ICard
{
    Expression name;
    Expression power;
    Expression faction;
    Expression type;
    List<Expression> ranges;
    List<SavedEffect> effects;

    public Golden(Expression Name, Expression Power, Expression Faction, Expression Type, List<Expression> Ranges, List<SavedEffect> Effects){
        name = Name;
        power = Power;
        faction = Faction;
        type = Type;
        ranges = Ranges;
        effects = Effects;
    }

    public Expression Name => name;

    public Expression Power => power;

    Expression ICard.Faction => faction;

    Expression ICard.Type => type;

    public List<Expression> Ranges => ranges;

    public List<SavedEffect> Effects => effects;
}

public class Silver : ICard
{
    Expression name;
    Expression power;
    Expression faction;
    Expression type;
    List<Expression> ranges;
    List<SavedEffect> effects;

    public Silver(Expression Name, Expression Power, Expression Faction, Expression Type, List<Expression> Ranges, List<SavedEffect> Effects){
        name = Name;
        power = Power;
        faction = Faction;
        type = Type;
        ranges = Ranges;
        effects = Effects;
    }

    public List<SavedEffect> Effects => effects;

    Expression ICard.Name => name;
    
    public Expression Power => power;

    Expression ICard.Faction => faction;

    Expression ICard.Type => type;

    public List<Expression> Ranges => ranges;
}

public class Dummy : ICard
{
    Expression name;
    Expression power;
    Expression faction;
    Expression type;
    List<Expression> ranges;
    List<SavedEffect> effects;

    public Dummy(Expression Name, Expression Power, Expression Faction, Expression Type, List<Expression> Ranges, List<SavedEffect> Effects){
        name = Name;
        power = Power;
        faction = Faction;
        type = Type;
        ranges = Ranges;
        effects = Effects;
    }

    public List<SavedEffect> Effects => effects;

    Expression ICard.Name => name;

    public Expression Power => power;

    Expression ICard.Faction => faction;

    Expression ICard.Type => type;

    public List<Expression> Ranges => ranges;
}

public class Buff : ICard
{
    Expression name;
    Expression faction;
    Expression type;
    List<Expression> ranges;
    List<SavedEffect> effects;

    public Buff(Expression Name, Expression Faction, Expression Type, List<Expression> Ranges, List<SavedEffect> Effects){
        name = Name;
        faction = Faction;
        type = Type;
        ranges = Ranges;
        effects = Effects;
    }

    public List<SavedEffect> Effects => effects;

    Expression ICard.Name => name;

    Expression ICard.Faction => faction;

    Expression ICard.Type => type;

    public List<Expression> Ranges => ranges;
}

public class Weather : ICard
{
    Expression name;
    Expression faction;
    Expression type;
    List<Expression> ranges;
    List<SavedEffect> effects;

    public Weather(Expression Name, Expression Faction, Expression Type, List<Expression> Ranges, List<SavedEffect> Effects){
        name = Name;
        faction = Faction;
        type = Type;
        ranges = Ranges;
        effects = Effects;
    }

    public List<SavedEffect> Effects => effects;

    Expression ICard.Name => name;

    Expression ICard.Faction => faction;

    Expression ICard.Type => type;

    public List<Expression> Ranges => ranges;
}