# LumexField Component Design

**Date:** 2026-02-04
**Status:** Draft
**Author:** Collaborative design session

## Overview

`LumexField` is a reusable component that renders the standard field layout (label, content, description/error). It will be used internally by all input components and exposed for custom component authors to ensure consistency across the library.

## Problem Statement

Currently, LumexUI has inconsistent handling of labels, descriptions, and error messages:

1. **`LumexInputFieldBase`** has Label, Description, ErrorMessage, LabelPlacement properties
2. **`LumexSelect`** reimplements these properties independently (duplication)
3. **`LumexCheckbox/Radio/Switch`** use `ChildContent` for labels with no Description or ErrorMessage support
4. **Custom components** inheriting `LumexInputBase` don't have access to these properties and must implement them independently, leading to inconsistency

## Solution

Create a `LumexField` component that:
- Provides consistent label/description/error rendering
- Supports both vertical (TextInput) and horizontal (Checkbox) orientations
- Is used internally by all input components
- Can be used by custom component authors for consistency

## Component API

### Parameters

```csharp
[Parameter] public string? Label { get; set; }
[Parameter] public string? Description { get; set; }
[Parameter] public string? ErrorMessage { get; set; }
[Parameter] public bool Invalid { get; set; }
[Parameter] public bool Required { get; set; }
[Parameter] public bool Disabled { get; set; }
[Parameter] public Orientation Orientation { get; set; } = Orientation.Vertical;
[Parameter] public RenderFragment? ChildContent { get; set; }
[Parameter] public FieldSlots? Classes { get; set; }
```

### Orientation Enum

```csharp
public enum Orientation
{
    Vertical,   // Label above content (TextInput, Select, etc.)
    Horizontal  // Label beside content (Checkbox, Radio, Switch)
}
```

## Rendering Structure

### Vertical Layout

For TextInput, Select, Numbox, Datebox, etc.

```html
<div data-slot="field" data-orientation="vertical" data-invalid="false" data-disabled="false" data-required="false">
    <label data-slot="label">Email *</label>
    <div data-slot="content">
        <!-- ChildContent: the actual input component -->
    </div>
    <div data-slot="helper">
        <span data-slot="description">We'll never share your email</span>
        <!-- OR when Invalid=true -->
        <span data-slot="error-message">Email is required</span>
    </div>
</div>
```

### Horizontal Layout

For Checkbox, Radio, Switch.

```html
<div data-slot="field" data-orientation="horizontal" data-invalid="false" data-disabled="false" data-required="false">
    <div data-slot="content">
        <!-- ChildContent: the checkbox/radio/switch visual -->
    </div>
    <div data-slot="label-wrapper">
        <label data-slot="label">Remember me</label>
        <span data-slot="description">Stay signed in for 30 days</span>
        <!-- OR when Invalid=true -->
        <span data-slot="error-message">You must accept the terms</span>
    </div>
</div>
```

## Slots

### FieldSlots Class

```csharp
public class FieldSlots : SlotBase
{
    public string? Root { get; set; }
    public string? Label { get; set; }
    public string? Content { get; set; }
    public string? LabelWrapper { get; set; }  // For horizontal orientation only
    public string? Helper { get; set; }
    public string? Description { get; set; }
    public string? ErrorMessage { get; set; }
}
```

## Styling

### New File: `Styles/Field.cs`

Base styles for the field component:

```csharp
// Vertical orientation
_verticalRoot = "flex flex-col gap-1.5"
_verticalLabel = "text-small text-foreground-500"
_verticalContent = "" // No additional styling, content controls itself
_verticalHelper = "flex flex-col gap-1"

// Horizontal orientation
_horizontalRoot = "inline-flex items-start gap-2"
_horizontalContent = "flex-shrink-0"
_horizontalLabelWrapper = "flex flex-col gap-0.5"
_horizontalLabel = "text-small text-foreground"

// Shared
_description = "text-tiny text-foreground-400"
_errorMessage = "text-tiny text-danger"

// States
_required = "after:content-['*'] after:text-danger after:ml-0.5"
_disabled = "opacity-disabled"
_invalid = "" // Error message styling handles this
```

## Property Migration

### Move to `LumexInputBase`

The following properties move from `LumexInputFieldBase` to `LumexInputBase`:

```csharp
[Parameter] public string? Label { get; set; }
[Parameter] public string? Description { get; set; }
[Parameter] public string? ErrorMessage { get; set; }
```

### Keep in `LumexInputFieldBase`

`LabelPlacement` (Inside/Outside) stays in `LumexInputFieldBase` as it only applies to input-like components with floating label behavior.

### Distinction

- **`LabelPlacement`** (Inside/Outside) - Controls floating label position within input border
- **`Orientation`** (Vertical/Horizontal) - Controls overall field layout direction

## Component Impact

| Component | Current Base | Changes |
|-----------|--------------|---------|
| `LumexTextbox` | `LumexDebouncedInputBase` | Use `LumexField` internally |
| `LumexNumbox` | `LumexDebouncedInputBase` | Use `LumexField` internally |
| `LumexSelect` | `LumexInputBase` | Use `LumexField`, remove duplicated properties |
| `LumexCheckbox` | `LumexBooleanInputBase` | Use `LumexField` (Horizontal), gains Description & ErrorMessage |
| `LumexRadio` | `LumexBooleanInputBase` | Use `LumexField` (Horizontal), gains Description & ErrorMessage |
| `LumexSwitch` | `LumexBooleanInputBase` | Use `LumexField` (Horizontal), gains Description & ErrorMessage |
| `LumexDatebox` | `LumexInputFieldBase` | Use `LumexField` internally |

## Backwards Compatibility

### Checkbox ChildContent

`LumexCheckbox` currently uses `ChildContent` for the label:

```razor
<LumexCheckbox>Remember me</LumexCheckbox>
```

To maintain backwards compatibility:
- Both `ChildContent` and `Label` parameter will work
- When both are provided, `Label` takes precedence
- When only `ChildContent` is provided, it's used as the label

## Usage Examples

### Built-in Component (Internal Usage)

**LumexTextbox:**
```razor
<LumexField Label="@Label"
            Description="@Description"
            ErrorMessage="@ErrorMessage"
            Invalid="@Invalid"
            Required="@Required"
            Disabled="@Disabled"
            Orientation="Orientation.Vertical"
            Classes="@FieldClasses">
    <div class="@InputWrapperClass" data-slot="input-wrapper">
        @StartContent
        <input type="text" class="@InputClass" @bind="@CurrentValue" />
        @EndContent
        @if (ClearButtonVisible) { ... }
    </div>
</LumexField>
```

**LumexCheckbox:**
```razor
<LumexField Label="@ResolvedLabel"
            Description="@Description"
            ErrorMessage="@ErrorMessage"
            Invalid="@Invalid"
            Required="@Required"
            Disabled="@Disabled"
            Orientation="Orientation.Horizontal"
            Classes="@FieldClasses">
    <span class="@WrapperClass" data-slot="wrapper">
        <input type="checkbox" class="@StyleUtils.VisuallyHidden" @bind="@CurrentValue" />
        <span class="@IconClass" data-slot="icon">
            @_checkIcon
        </span>
    </span>
</LumexField>

@code {
    private string? ResolvedLabel => Label ?? ChildContent?.ToString();
}
```

### Custom Component (External Usage)

```razor
@inherits LumexInputBase<DateTimeOffset?>

<LumexField Label="@Label"
            Description="@Description"
            ErrorMessage="@ErrorMessage"
            Invalid="@Invalid"
            Required="@Required"
            Disabled="@Disabled"
            Orientation="Orientation.Vertical">
    <div class="my-custom-datepicker">
        <!-- Custom datepicker implementation -->
    </div>
</LumexField>
```

## Implementation Order

1. **Create `LumexField` component**
   - `LumexField.razor` and `LumexField.razor.cs`
   - `FieldSlots.cs`
   - `Styles/Field.cs`

2. **Move properties to `LumexInputBase`**
   - Add Label, Description, ErrorMessage parameters
   - Update XML documentation

3. **Refactor `LumexInputFieldBase`**
   - Use `LumexField` internally
   - Keep `LabelPlacement` and input-specific logic
   - Simplify rendering

4. **Update `LumexSelect`**
   - Use `LumexField` internally
   - Remove duplicated Label, Description, ErrorMessage properties

5. **Update boolean input components**
   - `LumexCheckbox`: Use `LumexField` with Horizontal orientation
   - `LumexRadio`: Same
   - `LumexSwitch`: Same
   - Implement ChildContent fallback for Label

6. **Add/update tests**
   - Unit tests for `LumexField`
   - Update existing component tests
   - Test backwards compatibility

## Testing Considerations

- Verify vertical and horizontal orientations render correctly
- Verify error messages display instead of descriptions when Invalid=true
- Verify Required adds asterisk to label
- Verify Disabled state styling
- Verify slot customization works
- Verify backwards compatibility with Checkbox ChildContent

## Future Considerations

- Size variants (Small/Medium/Large) could be added later
- Color variants for labels could be considered
- Animation support for error message transitions
