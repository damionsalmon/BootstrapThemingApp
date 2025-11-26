using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum FieldType
{
    Text,
    Email,
    Select
}

public class SelectOption
{
    public string Value { get; set; } = default!;
    public string Label { get; set; } = default!;
}

public class FormFieldConfig
{
    public string Name { get; set; } = default!;
    public string Label { get; set; } = default!;
    public FieldType FieldType { get; set; }
    public bool Required { get; set; } = false;
    public int ColSpan { get; set; } = 6;
    public string? ErrorMessage { get; set; }
    public IList<SelectOption>? Options { get; set; }
}

public class FormConfig
{
    public IList<FormFieldConfig> Fields { get; set; } = new List<FormFieldConfig>();
}

// Wrapper that lets us load both config + model from JSON
public class DynamicFormDefinition<TModel>
{
    public FormConfig Config { get; set; } = new();
    public TModel Model { get; set; } = default!;
}

public class UserCredentialsModel
{
    public string? JobTitle { get; set; }
    public string? Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Department { get; set; }

    // Bag for arbitrary client-defined fields
    public Dictionary<string, string?> Custom { get; set; } = new();
}
