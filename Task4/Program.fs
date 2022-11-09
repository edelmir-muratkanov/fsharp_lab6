open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup
open System.Windows.Media.Imaging

let wXaml = """
    <Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" Title="Task 4" Width="300" Height="300">
        <StackPanel HorizontalAlignment="Center" VerticalAlignment="Center">
            <Image Source="C:\CODE\FSharp\Lab6\Task4\1.jpg" Height="200" Name="Image"/>
            <Button Name="Button" Height="50">Change</Button>
        </StackPanel>   
    </Window>
"""
let mw = XamlReader.Parse wXaml :?> Window
let image = mw.FindName "Image" :?> Image
let btn = mw.FindName "Button" :?> Button

btn.Click.Add <| fun _ ->
    if image.Source.ToString().Contains("1.jpg") then
        image.Source <- BitmapImage <| Uri "C:\CODE\FSharp\Lab6\Task4\2.jpg"
    else
        image.Source <- BitmapImage <| Uri "C:\CODE\FSharp\Lab6\Task4\1.jpg"

[<STAThread>]
ignore <| (new Application()).Run mw
