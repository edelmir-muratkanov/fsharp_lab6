open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup

let mwXaml =
    """
<Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" Title="Task1">
    <Menu Padding="10" VerticalAlignment="Top">
        <MenuItem Header="Forms">
            <MenuItem Header="Form 1" Name="Form1"/>
            <MenuItem Header="Form 2" Name="Form2"/>
            <MenuItem Header="Form 3" Name="Form3"/>
        </MenuItem>
    </Menu>
</Window>
"""

let form1Xaml =
    """
<Window
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    HorizontalAlignment="Center"
    VerticalAlignment="Center">
        Form 1
</Window>
"""

let form2Xaml =
    """
<Window
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    HorizontalAlignment="Center"
    VerticalAlignment="Center">
        Form 2
</Window>
"""

let form3Xaml =
    """
<Window
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    HorizontalAlignment="Center"
    VerticalAlignment="Center">
        Form 3
</Window>
"""

let getWindow xaml =
    let obj = XamlReader.Parse xaml
    obj :?> Window

let mainWindow = getWindow mwXaml
let Form1Window = getWindow form1Xaml
let Form2Window = getWindow form2Xaml
let Form3Window = getWindow form3Xaml

let miForm1 =
    mainWindow.FindName("Form1") :?> MenuItem

let miForm2 =
    mainWindow.FindName("Form2") :?> MenuItem

let miForm3 =
    mainWindow.FindName("Form3") :?> MenuItem


miForm1.Click.AddHandler(fun _ _ -> Form1Window.ShowDialog() |> ignore)
miForm2.Click.AddHandler(fun _ _ -> Form2Window.ShowDialog() |> ignore)
miForm3.Click.AddHandler(fun _ _ -> Form3Window.ShowDialog() |> ignore)

[<STAThread>]
ignore <| (new Application()).Run mainWindow
