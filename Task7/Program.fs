open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup


let wXaml =
    """
<Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" Title="Task 7" Width="300" Height="300">
    <StackPanel HorizontalAlignment="Center" VerticalAlignment="Center">
        <CheckBox Margin="10" Name="CheckBox1" Content="Flag1"/>
        <CheckBox Margin="10" Name="CheckBox2" Content="Flag2"/>
        <Button Margin="10" Content="Click" Name="Button"/>
    </StackPanel>
</Window>
"""

let mw = XamlReader.Parse wXaml :?> Window
let check1 = mw.FindName "CheckBox1" :?> CheckBox
let check2 = mw.FindName "CheckBox2" :?> CheckBox
let btn = mw.FindName "Button" :?> Button

btn.Click.Add <| fun _ ->
    MessageBox.Show
    <| match check1.IsChecked.Value, check2.IsChecked.Value with
        | true, true -> "Оба флага установлены"
        | true, false -> "1 флаг установлен"
        | false, true -> "2 флаг установлен"
        | _ -> "Ни один флаг не установлен"
    |> ignore
    
[<STAThread>]
ignore <| (new Application()).Run mw
