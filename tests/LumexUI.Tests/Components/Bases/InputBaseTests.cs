// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Globalization;

using Microsoft.Extensions.DependencyInjection;

using TailwindMerge;

namespace LumexUI.Tests.Components;

public class InputBaseTests : TestContext
{
    public InputBaseTests()
    {
        Services.AddSingleton<TwMerge>();
    }

    [Fact]
    public void InputBase_WithValue_ShouldGetCurrentValue()
    {
        var model = new TestModel();
        var cut = RenderComponent<TestInputComponent<string?>>( p => p
            .Add( p => p.Value, "some value" )
            .Add( p => p.ValueExpression, () => model.StringProperty )
        );

        cut.Instance.CurrentValue.Should().Be( "some value" );
    }

    [Fact]
    public void InputBase_WhenChanged_ShouldReadBackChanges()
    {
        var model = new TestModel();
        var cut = RenderComponent<TestInputComponent<string?>>( p => p
            .Add( p => p.Value, "initial value" )
            .Add( p => p.ValueExpression, () => model.StringProperty )
        );

        cut.Instance.CurrentValue.Should().Be( "initial value" );

        cut.Instance.CurrentValue = "new value";

        cut.Instance.CurrentValue.Should().Be( "new value" );
    }

    [Theory]
    [InlineData( null )]
    [InlineData( "" )]
    public async Task InputBase_WhenChangedToNullOrEmptyWithNullableType_ShouldSetNull( string? value )
    {
        var model = new TestModel();
        var cut = RenderComponent<TestInputComponent<int?>>( p => p
            .Add( p => p.Value, 1 )
            .Add( p => p.ValueExpression, () => model.NullableIntProperty )
        );

        await cut.Instance.SetCurrentValueAsStringAsync( value );

        cut.Instance.CurrentValue.Should().BeNull();
    }

    [Fact]
    public async Task InputBase_WithValue_ShouldSupplyCurrentValueAsString()
    {
        var dt = new DateTime( 1915, 3, 2 );
        var model = new TestModel();
        var cut = RenderComponent<TestInputComponent<DateTime>>( p => p
            .Add( p => p.Value, dt )
            .Add( p => p.ValueExpression, () => model.DateProperty )
        );

        await cut.Instance.SetCurrentValueAsStringAsync( "1915/03/02" );

        cut.Instance.CurrentValueAsString.Should().Be( dt.ToString() );
    }

    [Fact]
    public void InputBase_WithValue_ShouldSupplyCurrentValueAsStringWithFormatting()
    {
        var model = new TestModel();
        var cut = RenderComponent<TestDateInputComponent>( p => p
            .Add( p => p.Value, new DateTime( 1915, 3, 2 ) )
            .Add( p => p.ValueExpression, () => model.DateProperty )
        );

        cut.Instance.CurrentValueAsString.Should().Be( "1915/03/02" );
    }

    [Fact]
    public async Task InputBase_WhenChangedValid_ShouldParseCurrentValueAsString()
    {
        var model = new TestModel();
        var cut = RenderComponent<TestDateInputComponent>( p => p
            .Add( p => p.Value, new DateTime( 1915, 3, 2 ) )
            .Add( p => p.ValueExpression, () => model.DateProperty )
        );

        await cut.Instance.SetCurrentValueAsStringAsync( "1991/11/20" );

        cut.Instance.CurrentValue.Year.Should().Be( 1991 );
        cut.Instance.CurrentValue.Month.Should().Be( 11 );
        cut.Instance.CurrentValue.Day.Should().Be( 20 );
        cut.Instance.CurrentValueAsString.Should().Be( "1991/11/20" );
    }

    [Fact]
    public async Task InputBase_WhenChangedInvalid_ShouldNotParseCurrentValueAsString()
    {
        var model = new TestModel();
        var cut = RenderComponent<TestDateInputComponent>( p => p
            .Add( p => p.Value, new DateTime( 1915, 3, 2 ) )
            .Add( p => p.ValueExpression, () => model.DateProperty )
        );

        await cut.Instance.SetCurrentValueAsStringAsync( "1991/11/40" );

        cut.Instance.CurrentValue.Year.Should().Be( 1915 );
        cut.Instance.CurrentValue.Month.Should().Be( 3 );
        cut.Instance.CurrentValue.Day.Should().Be( 2 );
        cut.Instance.CurrentValueAsString.Should().Be( "1991/11/40" );
    }

    [Fact]
    public void ShouldTriggerOnFocusCallbackAndSetFocusOnFocus()
    {
        var isFocused = false;
        var cut = RenderComponent<LumexTextBox>( p => p
            .Add( p => p.Value, "some value" )
            .Add( p => p.OnFocus, () => isFocused = true )
        );

        var baseWrapper = cut.Find( "[data-slot=base]" );
        var input = cut.Find( "input" );
        input.Focus();

        isFocused.Should().BeTrue();
        baseWrapper.GetAttribute( "data-focus" ).Should().Be( "true", because: "Internal `Focused` flag is true." );
    }

    [Fact]
    public void ShouldTriggerOnBlurCallbackAndRemoveFocusOnBlur()
    {
        var isBlurred = false;
        var cut = RenderComponent<LumexTextBox>( p => p
            .Add( p => p.Value, "some value" )
            .Add( p => p.OnBlur, () => isBlurred = true )
        );

        var baseWrapper = cut.Find( "[data-slot=base]" );
        var input = cut.Find( "input" );
        input.Blur();

        isBlurred.Should().BeTrue();
        baseWrapper.GetAttribute( "data-focus" ).Should().Be( "false", because: "Internal `Focused` flag is false." );
    }

    class TestModel
    {
        public int? NullableIntProperty { get; set; }
        public string? StringProperty { get; set; }
        public DateTime DateProperty { get; set; }
    }

    class TestInputComponent<T> : LumexInputBase<T>
    {
        public new T? CurrentValue
        {
            get => base.CurrentValue;
            set { base.CurrentValue = value; }
        }

        public new string? CurrentValueAsString
        {
            get => base.CurrentValueAsString;
        }

        public new async Task SetCurrentValueAsStringAsync( string? value )
        {
            // This is equivalent to the subclass writing to CurrentValueAsString
            // (e.g., from @bind), except to simplify the test code there's an InvokeAsync
            // here. In production code it wouldn't normally be required because @bind
            // calls run on the sync context anyway.
            await InvokeAsync( () => { base.CurrentValueAsString = value; } );
        }

        protected override bool TryParseValueFromString( string? value, out T? result )
        {
            throw new NotImplementedException();
        }
    }

    private class TestDateInputComponent : TestInputComponent<DateTime>
    {
        protected override string FormatValueAsString( DateTime value )
            => value.ToString( "yyyy/MM/dd", CultureInfo.InvariantCulture );

        protected override bool TryParseValueFromString( string? value, out DateTime result )
        {
            if( DateTime.TryParse( value, out result ) )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}