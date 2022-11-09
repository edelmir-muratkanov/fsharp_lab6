open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup

let wXaml =
    """
<Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" Title="Task 10" Width="300" Height="300">
    <StackPanel HorizontalAlignment="Center" VerticalAlignment="Center">
        <StackPanel Orientation="Horizontal" HorizontalAlignment="Center" VerticalAlignment="Center" Margin="0, 10">
            <TextBlock TextAlignment="Center" Text="Длина" Width="50" Margin="10"/>
            <TextBox TextAlignment="Center" Name="Length" Padding="24, 4 " />
        </StackPanel>
        <StackPanel Orientation="Horizontal" HorizontalAlignment="Center" VerticalAlignment="Center" Margin="0, 10">
            <TextBlock TextAlignment="Center" Text="Ширина" Width="50" Margin="10"/>
            <TextBox TextAlignment="Center" Name="Width" Padding="24, 4"/>
        </StackPanel>
        <TextBlock TextAlignment="Center" Name="Output" Padding="24, 4"/>
    </StackPanel>
</Window>
"""

let mw = XamlReader.Parse wXaml :?> Window
let len = mw.FindName "Length" :?> TextBox
let wid = mw.FindName "Width" :?> TextBox
let output = mw.FindName "Output" :?> TextBlock

let calculate _ =
    let parseFloat s =
        match Double.TryParse s with
        | true, n -> Ok n
        | _ -> Error "Некорректная "
        
    match parseFloat (len.Text.Replace(".", ",")) with
    | Error e -> output.Text <- e + "длина"
    | Ok a ->
        match parseFloat (wid.Text.Replace(".", ",")) with
        | Error e -> output.Text <- e + "ширина"
        | Ok b ->
            output.Text <- sprintf "Площадь: %g" (a * b)

len.TextChanged.Add <| calculate 
wid.TextChanged.Add <| calculate 

[<STAThread>]
ignore <| (new Application()).Run mw
