open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup

let wXaml =
    """
<Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" Title="Task 6" Width="300" Height="300">
    <StackPanel HorizontalAlignment="Center" VerticalAlignment="Center">
        <Slider Maximum="250" Minimum="100" Value="100" Name="Track" />
        <Button Name="Button" Width="100" Content="Text" />
    </StackPanel>
</Window>
"""

let mw = XamlReader.Parse wXaml :?> Window
let btn = mw.FindName "Button" :?> Button
let slider = mw.FindName "Track" :?> Slider

slider.ValueChanged.Add <| fun _ ->
    btn.Width <- slider.Value

[<STAThread>]
ignore <| (new Application()).Run mw
