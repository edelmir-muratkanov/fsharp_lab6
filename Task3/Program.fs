open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup

let wXaml =
    """
<Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" Title="Task 3" Width="300" Height="300">
   <StackPanel VerticalAlignment="Center">
        <StackPanel Margin="50" Orientation="Horizontal" HorizontalAlignment="Center" VerticalAlignment="Center">
            <TextBox Name="Num1" Padding="12, 8" VerticalAlignment="Center" Text="0" />
            <ComboBox Padding="16, 8" Margin="10, 0" Name="Operation">
                <ComboBoxItem IsSelected="True">+</ComboBoxItem>
                <ComboBoxItem>-</ComboBoxItem>
                <ComboBoxItem>/</ComboBoxItem>
                <ComboBoxItem>*</ComboBoxItem>
            </ComboBox>
            <TextBox Name="Num2" Padding="12, 8" VerticalAlignment="Center" Text="0" />
        </StackPanel>
        <Button Width="150" Padding="8, 16" Name="Button1">Решить</Button>
   </StackPanel>
</Window>
"""

let mw = XamlReader.Parse wXaml :?> Window
let num1 = mw.FindName "Num1" :?> TextBox
let num2 = mw.FindName "Num2" :?> TextBox

let operation =
    mw.FindName "Operation" :?> ComboBox

let btn = mw.FindName "Button1" :?> Button


btn.Click.Add
<| fun _ ->
    let parseFloat s =
        match Double.TryParse s with
        | true, n -> Ok n
        | _ -> Error "Invalid parameter"

    let add x y = x + y

    let sub x y = x - y

    let mul x y = x * y

    let div x y =
        match x, y with
        | _, 0. -> Error "Division by zero"
        | a, b -> Ok(a / b)

    let op =
        operation.SelectedItem :?> ComboBoxItem

    match parseFloat (num1.Text.Replace(".", ",")) with
    | Error e -> MessageBox.Show("Invalid 1 number") |> ignore
    | Ok a ->
        match parseFloat (num2.Text.Replace(".", ",")) with
        | Error e -> MessageBox.Show("Invalid 2 number") |> ignore
        | Ok b ->
            match op.Content.ToString() with
            | "+" ->
                add a b
                |> sprintf "%g"
                |> MessageBox.Show
                |> ignore
            | "-" ->
                sub a b
                |> sprintf "%g"
                |> MessageBox.Show
                |> ignore
            | "*" ->
                mul a b
                |> sprintf "%g"
                |> MessageBox.Show
                |> ignore
            | "/" ->
                match div a b with
                | Error e -> MessageBox.Show e |> ignore
                | Ok v -> sprintf "%g" v |> MessageBox.Show |> ignore
            | _ -> "" |> ignore


[<STAThread>]
ignore <| (new Application()).Run mw
