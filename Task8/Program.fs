
open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup

let mwXaml = """
<Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" Title="Task 8" Width="300" Height="300">
    <StackPanel HorizontalAlignment="Center" VerticalAlignment="Center" Width="200">
        <TextBox Margin="10" Name="Input" />
        <ListBox Margin="10" Name="ListBox" MinHeight="50" />
        <Button Margin="10" Content="Add" Name="Button"/>
    </StackPanel>
</Window>
"""

let mw = XamlReader.Parse mwXaml :?> Window
let input = mw.FindName "Input" :?> TextBox
let list = mw.FindName "ListBox" :?> ListBox
let btn = mw.FindName "Button" :?> Button

btn.Click.Add <| fun _ ->
    list.Items.Add <| input.Text |> ignore

[<STAThread>]
ignore <| (new Application()).Run mw
