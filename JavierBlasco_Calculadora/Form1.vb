Public Class Form1
    ''Dim resultado As Double
    'Variable que gestiona las operaciones +-*/'
    Dim operacion As String
    'Esta variable aceptara valores nulos y es de tipo double y sera igual a nothing / nada'
    Dim valorResultado As Nullable(Of Double) = Nothing
    'Es la variable encargada de guardar el resultado introducido, es Nothing y Nullable'
    Dim Valor2 As Nullable(Of Double) = Nothing
    'Nos servira de flag / bandera y sera nuestro interruptor al ser boolean (on/off)'
    Dim Bandera As Boolean
    Dim numberZero As String = "0"
    'Private label2 As Object
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PanelScientific.Hide()
    End Sub
    Public Sub DeterminarConcatenar()
        'Una vez que pulsamos un boton ejerce una concatenación
        If Bandera = True Then
            Label1.Text = ""
            Bandera = False
        ElseIf Label1.Text = "0" Then
            Label1.Text = ""
        End If
    End Sub

    Private Sub ClickButtonNumber(sender As Object, e As EventArgs) Handles buttonZero.Click, buttonTwo.Click, buttonThree.Click, buttonSix.Click, buttonSeven.Click, buttonOne.Click, buttonFour.Click, buttonFive.Click, buttonEight.Click, butonNine.Click
        'Una vez que pulsamos en el boton, debe aparecer en el textbox'
        'TextBox = boton que hemos presionado'
        'TextBox = valor que estaba en TextBox seguido con el nuevo valor'
        'TextBox = TextBox + numero que añadimos'
        DeterminarConcatenar()
        Label1.Text &= sender.text
    End Sub
    Public Sub OperacionProceso()
        Bandera = True
        Valor2 = Val(Label1.Text)

        If valorResultado IsNot Nothing Then
            Select Case operacion
                Case "+"
                    valorResultado = valorResultado + Valor2
                Case "-"
                    valorResultado -= Valor2
                Case "*"
                    valorResultado *= Valor2
                Case "/"
                    valorResultado /= Valor2
                Case "+/-" 'Cambio de Signo
                    'valorResultado = valorResultado - (valorResultado * 2)
                    'valorResultado = valorResultado * -1
                    'Label1.Text = valorResultado
                    ' valorResultado = valorResultado - (valorResultado * 2)
                    'Label1.Text = valorResultado

                Case "%" 'Porcentaje
                    valorResultado = (valorResultado / 100) '* Valor2
                Case "1/x" 'Numero inverso al introducido en el visor
                    valorResultado = 1 / Valor2
                Case "x2" 'Elevar al cuadrado
                    valorResultado = valorResultado ^ 2
                    Label2.Text = "(" & Label1.Text & ")" & "²"
                Case "x3" 'al cuabo'
                    valorResultado = valorResultado ^ 3
                    Label2.Text = "(" & Label1.Text & ")" & "³"
                Case "elevadoX" 'Elevar a x'
                    Label2.Text = "(" & Label1.Text & ")" & Valor2
                    valorResultado = valorResultado ^ Valor2
                Case "Factorial" 'Calcular el factorial de un numero'
                    Label2.Text = "(" & "Fact" & ")" & Label1.Text
                Case "raizCuadrada" 'Raiz cuadrada
                    valorResultado = Math.Sqrt(valorResultado)

            End Select
            Label1.Text = valorResultado
        Else
            valorResultado = Valor2
        End If
    End Sub

    Private Sub buttnResult_Click(sender As Object, e As EventArgs) Handles buttnResult.Click
        OperacionProceso()
        operacion = ""

    End Sub

    Private Sub buttonSum_Click(sender As Object, e As EventArgs) Handles buttonSum.Click
        OperacionProceso()
        operacion = "+"
    End Sub

    Private Sub buttonSubtract_Click(sender As Object, e As EventArgs) Handles buttonSubtract.Click
        OperacionProceso()
        operacion = "-"
    End Sub

    Private Sub buttonMultiply_Click(sender As Object, e As EventArgs) Handles buttonMultiply.Click
        OperacionProceso()
        operacion = "*"
    End Sub

    Private Sub buttonDivision_Click(sender As Object, e As EventArgs) Handles buttonDivision.Click
        OperacionProceso()
        operacion = "/"
    End Sub

    Private Sub buttonBack_Click(sender As Object, e As EventArgs) Handles buttonBack.Click, buttonBack2.Click
        If Len(Label1.Text) > 0 Then
            Label1.Text = Mid(Label1.Text, 1, Len(Label1.Text) - 1)
            Label2.Text = " "
            ''valorResultado = Label1.Text
        End If
    End Sub

    Private Sub buttonC_Click(sender As Object, e As EventArgs) Handles buttonC.Click, buttonC2.Click
        Label1.Text = "0"
        Valor2 = Nothing
        valorResultado = Nothing
    End Sub

    Private Sub buttonCE_Click(sender As Object, e As EventArgs) Handles buttonCE.Click, buttonCE2.Click
        If Len(Label1.Text) > 1 Then
            Label1.Text = Mid(Label1.Text, 1, Len(Label1.Text) - 1)
            Label2.Text = " "
            valorResultado = Label1.Text
        End If
    End Sub

    Private Sub buttonPoint_Click(sender As Object, e As EventArgs) Handles buttonPoint.Click
        DeterminarConcatenar()
        If InStr(Label1.Text, ".", CompareMethod.Text) = 0 Then
            Label1.Text &= "."
        End If
    End Sub

    Private Sub buttonChangeSign_Click(sender As Object, e As EventArgs) Handles buttonChangeSign.Click
        'OperacionProceso()
        operacion = "+/-"
        Label2.Text = " "

        Label1.Text = Label1.Text * (-1)

        'If Label1.Text <> numberZero AndAlso Not Label1.Text.Contains("-") Then
        'valorResultado = valorResultado * (-1)
        'Label1.Text = "-" + Label1.Text
        'Else
        'valorResultado = valorResultado * (-1)
        'Label1.Text.Replace("-", "")
        'End If

    End Sub

    Private Sub ButtonStandar_Click(sender As Object, e As EventArgs) Handles ButtonStandar.Click
        PanelScientific.Hide()
    End Sub

    Private Sub ButtonScientific_Click(sender As Object, e As EventArgs) Handles ButtonScientific.Click
        PanelScientific.Show()
    End Sub

    Private Sub ButtonAlCuadrado_Click_1(sender As Object, e As EventArgs) Handles ButtonAlCuadrado.Click
        OperacionProceso()
        operacion = "x2"
    End Sub

    Private Sub ButtonAlcubo_Click_1(sender As Object, e As EventArgs) Handles ButtonAlcubo.Click
        OperacionProceso()
        operacion = "x3"
    End Sub

    Private Sub ButtonElevado_a_X_Click(sender As Object, e As EventArgs) Handles ButtonElevado_a_X.Click
        OperacionProceso()
        operacion = "elevadoX"
    End Sub

    Private Sub ButtonFactorial_Click_1(sender As Object, e As EventArgs) Handles ButtonFactorial.Click
        OperacionProceso()
        ' Label1.Text = ""
        ' Label2.Text = ""

        operacion = "Factorial"
        Dim factorial As Double
        factorial = 1
        For numero = 1 To Val(Label1.Text)
            factorial = factorial * numero

        Next
        ' Label1.Text = factorial
        valorResultado = factorial

        '''''''''''''''''''''''''''''
        ' operacion = "Factorial" 'Calcula Factorial, multiplica por todos los numeros enteros que tiene por debajo hasta 0'
        '   Dim num, i, factorial As Integer
        '  num = CInt(Label1.Text)
        ' factorial = 1
        'For i = 1 To num
        ' factorial = factorial * i
        ' Next
        ' valorResultado = factorial
    End Sub

    Private Sub buttonPercentage_Click(sender As Object, e As EventArgs) Handles buttonPercentage.Click
        OperacionProceso()
        operacion = "%"
        Label2.Text = " "
    End Sub

    Private Sub ButtonInversa_Click(sender As Object, e As EventArgs) Handles ButtonInversa.Click
        OperacionProceso()
        operacion = "1/x"
        Label2.Text = " "
    End Sub

    Private Sub ButtonRaizCuadrada_Click(sender As Object, e As EventArgs) Handles ButtonRaizCuadrada.Click
        OperacionProceso()
        operacion = "raizCuadrada"
        Label2.Text = ""

    End Sub

    Private Sub AyudaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AyudaToolStripMenuItem.Click
        Form2.Show()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub AutorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutorToolStripMenuItem.Click
        Form3.Show()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class
