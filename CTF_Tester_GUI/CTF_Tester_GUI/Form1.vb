Imports System.IO
Imports System.IO.Ports
Imports System.Threading
' Windows GUI for the CTF Tester
' Eventually save as a .exe
Public Class Form1
    Shared SerialPort1 = New SerialPort()
    Dim check_short As Boolean
    Dim check_continunity As Boolean
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' set up serial port
        SerialPort1.PortName = "COM6"
        SerialPort1.BaudRate = 115200   ' make sure Arduino serial is set at 115200 bps  
        SerialPort1.DataBits = 8
        SerialPort1.Parity = Parity.None
        SerialPort1.StopBits = StopBits.One
        SerialPort1.Handshake = Handshake.None
        SerialPort1.Encoding = System.Text.Encoding.Default
        SerialPort1.ReadTimeout = 1000 ' keep at 1000 -- it's working
        check_short = False
        check_continunity = False
    End Sub
    Private Sub start_test_btn_Click(sender As Object, e As EventArgs) Handles start_test_btn.Click
        Dim pin_count = ffc_pin_count.Text
        ' writeSerial({pin_count}) ' pass the value as a byte-array
        MsgBox("Sent " & pin_count & " to the tester")
    End Sub
    Private Sub writeSerial(ByVal data As Byte())
        SerialPort1.Open()

        ' Test this guy out
        If check_continunity Then
            Dim b() As Byte = New Byte() {200}
            SerialPort1.Write(b, 0, 1)
        End If
        If check_short Then
            Dim s() As Byte = New Byte() {250}
            SerialPort1.Write(s, 0, 1)
        End If

        SerialPort1.Write(data, 0, 1)
        SerialPort1.Close()
    End Sub
    Private Sub check_continuity_CheckedChanged(sender As Object, e As EventArgs) Handles check_continuity.CheckedChanged
        If check_continunity <> True Then
            check_continunity = True
        Else
            check_continunity = False
        End If
    End Sub
    Private Sub check_shorts_CheckedChanged(sender As Object, e As EventArgs) Handles check_shorts.CheckedChanged
        If check_short <> True Then
            check_short = True
        Else
            check_short = False
        End If
    End Sub
End Class
