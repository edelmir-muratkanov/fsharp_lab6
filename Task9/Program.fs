open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup

let wXaml =
    """
<Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" Title="Task 9" Width="300" Height="300">
    <StackPanel HorizontalAlignment="Center" VerticalAlignment="Center" Width="200">
        <ProgressBar Minimum="0" Maximum="100" Margin="10" Name="ProgressBar" Height="30"/>
        <TextBox Margin="10" Name="Input" />
    </StackPanel>
</Window>
"""

let mw = XamlReader.Parse wXaml :?> Window
let input = mw.FindName "Input" :?> TextBox
let bar = mw.FindName "ProgressBar" :?> ProgressBar

input.TextChanged.Add <| fun _ ->
    bar.Value <- float <| input.Text.Length 

[<STAThread>]
ignore <| (new Application()).Run mw
