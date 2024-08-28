public interface ICard{
    string Name { get;}
    int Power { get;}
    string Faction { get;}
    string Type { get;}
    List<SavedEffect> effects { get;}
}
public class Card : ICard
{
    public string Faction => throw new NotImplementedException();

    public List<SavedEffect> effects => throw new NotImplementedException();

    string ICard.Name => throw new NotImplementedException();

    int ICard.Power => throw new NotImplementedException();

    string ICard.Type => throw new NotImplementedException();
}