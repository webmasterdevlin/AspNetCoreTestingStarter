﻿namespace EmployeesApp.Validation;

public class AccountNumberValidation
{
    private const int StartingPartLength = 3;
    private const int MiddlePartLength = 10;
    private const int LastPartLength = 2;

    /// <summary>
    /// First version of the method
    /// </summary>
    /// <param name="accountNumber"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public bool IsValidFirstVersion(string accountNumber)
    {
        var firstDelimiter = accountNumber.IndexOf('-');
        var secondDelimiter = accountNumber.LastIndexOf('-');

        if (firstDelimiter == -1 || secondDelimiter == -1)
            throw new ArgumentException( "Invalid account number");

        var firstPart = accountNumber[..firstDelimiter];
        if (firstPart.Length != StartingPartLength)
            return false;

        var tempPart = accountNumber.Remove(0, StartingPartLength + 1);
        var middlePart = tempPart[..tempPart.IndexOf('-')];
        if (middlePart.Length != MiddlePartLength)
            return false;

        var lastPart = accountNumber[(secondDelimiter + 1)..];
        return lastPart.Length == LastPartLength;
    }

    public bool IsValid(string accountNumber)
    {
        var firstDelimiter = accountNumber.IndexOf('-');
        var secondDelimiter = accountNumber.LastIndexOf('-');

        if (firstDelimiter == -1 || (firstDelimiter == secondDelimiter))
            throw new ArgumentException("Invalid account number");

        var firstPart = accountNumber[..firstDelimiter];
        if (firstPart.Length != StartingPartLength)
            return false;

        var tempPart = accountNumber.Remove(0, StartingPartLength + 1);
        var middlePart = tempPart[..tempPart.IndexOf('-')];
        if (middlePart.Length != MiddlePartLength)
            return false;

        var lastPart = accountNumber[(secondDelimiter + 1)..];
        return lastPart.Length == LastPartLength;
    }
}