string Summarize(int[] numbers) => numbers switch
{
    [var first, .. var rest] => $"First: {first}, Rest count: {rest.Length}",
    [var only] => $"Single element: {only}",
    [] => "Empty list"
};
