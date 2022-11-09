open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup

let wXaml =
    """
<Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" Title="Task 5" Width="300" Height="300">
    <StackPanel HorizontalAlignment="Center" VerticalAlignment="Center">
        <Calendar Name="Calendar"/>
        <Button Name="Button" Content="Click"/>
    </StackPanel>
</Window>
"""

let mw = XamlReader.Parse wXaml :?> Window
let btn = mw.FindName "Button" :?> Button
let calendar = mw.FindName "Calendar" :?> Calendar

btn.Click.Add <| fun _ ->
    MessageBox.Show
    <| match calendar.DisplayDate.Month with
        | 1 | 2 | 12 -> "Winter"
        | 3 | 4 | 5 -> "Spring"
        | 6 | 7 | 8 -> "Summer"
        | _ -> "Autumn"
    |> ignore
    
[<STAThread>]
ignore <| (new Application()).Run mw
