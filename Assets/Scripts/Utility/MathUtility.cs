using System;

public enum Calculation
{
    Add,
    Subtract,
    Multiply,
    Divide,
}

public enum Evaluation
{
    Less,
    LEqual,
    Greater,
    GEqual,
    Equal,
    NotEqual
}

public static class MathUtility
{
    public static bool Evaluate(int a_leftHand, int a_rightHand, Evaluation a_evaluation)
    {
        switch (a_evaluation)
        {
            case Evaluation.Less:
                return a_leftHand < a_rightHand;

            case Evaluation.LEqual:
                return a_leftHand <= a_rightHand;

            case Evaluation.Greater:
                return a_leftHand > a_rightHand;

            case Evaluation.GEqual:
                return a_leftHand >= a_rightHand;

            case Evaluation.Equal:
                return a_leftHand == a_rightHand;

            case Evaluation.NotEqual:
                return a_leftHand != a_rightHand;

            default:
                throw new ArgumentOutOfRangeException("a_evaluation");
        }
    }

    public static bool Evaluate(float a_leftHand, float a_rightHand, Evaluation a_evaluation)
    {
        switch (a_evaluation)
        {
            case Evaluation.Less:
                return a_leftHand < a_rightHand;

            case Evaluation.LEqual:
                return a_leftHand <= a_rightHand;

            case Evaluation.Greater:
                return a_leftHand > a_rightHand;

            case Evaluation.GEqual:
                return a_leftHand >= a_rightHand;

            case Evaluation.Equal:
                return a_leftHand == a_rightHand;

            case Evaluation.NotEqual:
                return a_leftHand != a_rightHand;

            default:
                throw new ArgumentOutOfRangeException("a_evaluation");
        }
    }
}