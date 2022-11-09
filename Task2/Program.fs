open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup

let wXaml =
    """
<Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" Title="Task 2" Width="300" Height="300">
    <StackPanel>
        <StackPanel 
            Margin="0, 50, 0, 0"
            Orientation="Horizontal" 
            VerticalAlignment="Center" 
            HorizontalAlignment="Center"
            >
            <TextBox Padding="8, 4" Name="AParam" VerticalAlignment="Center">1</TextBox>
            <Label Padding="5">x^2 + </Label>
            <TextBox Padding="8, 4" Name="BParam" VerticalAlignment="Center">1</TextBox>
            <Label Padding="5">x + </Label>
            <TextBox Padding="8, 4" Name="CParam" VerticalAlignment="Center">1</TextBox>
            <Label Padding="5"> = 0</Label>
        </StackPanel>
        <StackPanel Margin="10,50">
            <TextBox Name="Output" />
        </StackPanel>
    </StackPanel>
</Window>
"""

let mw = XamlReader.Parse wXaml :?> Window

let varA = mw.FindName "AParam" :?> TextBox
let varB = mw.FindName "BParam" :?> TextBox
let varC = mw.FindName "CParam" :?> TextBox

let output =
    mw.FindName "Output" :?> TextBox

let calculate _ =
    let parseFloat s =
        match Double.TryParse s with
        | true, n -> Ok n
        | _ -> Error "Invalid parameter"

    match parseFloat (varA.Text.Replace('.', ',')) with
    | Error e -> output.Text <- e + " a"
    | Ok a ->
        match parseFloat (varB.Text.Replace(".", ",")) with
        | Error e -> output.Text <- e + " b"
        | Ok b ->
            match parseFloat (varC.Text.Replace(".", ",")) with
            | Error e -> output.Text <- e + " c"
            | Ok c ->
                let d = b ** 2. - 4. * a * c

                match d with
                | d when d = 0. -> output.Text <- sprintf "x = %g" ((-b) / (2. * a))
                | d when d > 0. ->
                    let x1 = (-b + sqrt d) / (2. * a)
                    let x2 = (-b - sqrt d) / (2. * a)
                    output.Text <- sprintf "x1 = %g \nx2 = %g" x1 x2
                | d when d < 0. -> output.Text <- "D < 0"
                | _ -> failwith "todo"


varA.TextChanged.Add <| calculate
varB.TextChanged.Add <| calculate
varC.TextChanged.Add <| calculate

[<STAThread>]
ignore <| (new Application()).Run mw
