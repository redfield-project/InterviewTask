﻿namespace InterviewTask.WebApi.Infrastructure;

using System.Text.RegularExpressions;

public class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
    {
        if (value == null)
        {
            return null;
        }

        // Slugify value
        return Regex.Replace(value.ToString()!,
                         "([a-z])([A-Z])",
                         "$1$2",
                         RegexOptions.CultureInvariant,
                         TimeSpan.FromMilliseconds(100)).ToLowerInvariant().ToLower();
    }
}
