// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

namespace LumexUI;

public interface ILumexRadioValueProvider<out TValue>
{
    public TValue? CurrentValue { get; }
}