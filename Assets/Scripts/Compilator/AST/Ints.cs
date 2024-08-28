using System.Globalization;

public struct Int
{
    public double Value { get;}
    public Int(double value){Value = value;}

    public Int Plus(Int value) => new Int(Value + value.Value);
    public Int Minus(Int value) => new Int(Value - value.Value);
    public Int Multip(Int value) => new Int(Value * value.Value);
    public Int Pow(Int value) => new Int(Math.Pow(Value, value.Value));
    public Int Division(Int value){
        if(value.Value == 0) throw new Exception("Invalid operation. Attempt to divide by 0. Espabila");
        else return new Int(Value / value.Value);
    }
    public Int Opposite() => new Int(-Value);

    public bool Greater(Int value) => Value > value.Value;
    public bool Less(Int value) => Value < value.Value;
    public bool Equals(Int value) => Value == value.Value;
    public bool GreaterEquals(Int value) => Value >= value.Value;
    public bool LessEqual(Int value) => Value <= value.Value;

    public override string ToString() => Value.ToString();
}