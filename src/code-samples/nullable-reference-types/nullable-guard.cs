string? displayName = FindDisplayName();

if (displayName is null)
{
    return;
}

Console.WriteLine(displayName.Length);
