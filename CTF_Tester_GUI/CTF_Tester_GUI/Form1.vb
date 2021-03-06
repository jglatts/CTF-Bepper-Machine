Imports System.IO.Ports
' Windows GUI for the CTF Tester
' ToDo
'   - add a check that will be sent from arduino to verify the test is completed
'   - the check will also say which pins passed/failed
Public Class Form1
    Shared SerialPort1 = New SerialPort()
    Dim count As Integer
    Dim check_short As Boolean
    Dim check_continunity As Boolean
    Shared globalArr As Array
    'Dim pin_array(0 To 10) As Integer
    ' Load the GUI and open up the serial ports
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
    ' Start-Test button-change function
    ' Verifies that the flex-size if correct and sends it to arudino
    ' If the pin_count not accepted, prompt user to enter another one
    Private Sub start_test_btn_Click(sender As Object, e As EventArgs) Handles start_test_btn.Click
        Dim pin_count = ffc_pin_count.Text
        Dim fileName = txtFileName.Text
        Dim dataDirectory As String = String.Format("{0}", Environment.CurrentDirectory)
        If (pin_count <> "1-50" And Trim(pin_count & vbNullString) <> vbNullString) Then
            Dim pin_array(0 To pin_count) As String
            count = pin_count
            MsgBox("Starting Test...")
            'writeSerial({pin_count})
            'readSerial(pin_array)
            addTextBoxes(pin_array)
            globalArr = pin_array
            ' clean all these guys up
            If Trim(fileName & vbNullString) <> vbNullString Then
                writeToFile(dataDirectory + "\" + fileName)
                MsgBox("Wrote Debug at: " + dataDirectory + "\" + fileName)
            Else
                writeToFile(dataDirectory + "\CTF_DEBUG_LOG.txt")
                MsgBox("Wrote Debug at: " + dataDirectory + "\CTF_DEBUG_LOG.txt")
            End If
        Else
            MsgBox("Please enter the number of FFC traces.", +vbExclamation)
        End If

    End Sub
    Private Sub writeToFile(ByVal fileName As String)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(fileName, True)
        file.WriteLine("Start Test: " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
        file.Write("Testing for Continuity: ")
        If check_continunity Then
            file.WriteLine(" YES")
        Else
            file.WriteLine(" NO")
        End If
        file.Write("Testing for Shorts: ")
        If check_short Then
            file.WriteLine(" YES")
        Else
            file.WriteLine(" NO" & vbNewLine)
        End If
        For i As Integer = 1 To count
            file.WriteLine("Pin #" & i & " IS TESTING")
        Next
        file.Close()
    End Sub
    ' Dynamically add textboxes
    Private Sub addTextBoxes(ByVal pin_count)
        Dim yValue = 77
        Dim TestLabel = New Label
        TestLabel.Text = "Test Results"
        TestLabel.Name = "TestLabel"
        TestLabel.Location = New Point(532, 60)
        TestLabel.Size = New System.Drawing.Size(78, 61)
        For index As Integer = 1 To count
            Dim NewTB = New TextBox
            Dim NewLB = New Label
            NewTB.Name = "tbNew" & index
            NewLB.Name = "labelNew" & index
            NewLB.Text = "Pin " & index
            If pin_count(index) > 0 Then
                NewTB.Text = "PASSED"
            Else
                NewTB.Text = "FAILED"
            End If
            AddHandler NewTB.TextChanged, AddressOf HandleTextChanged
            NewTB.Location = New Point(536, yValue)
            NewLB.Location = New Point(500, yValue + 2)
            yValue += 25
            Me.Controls.Add(TestLabel)
            Me.Controls.Add(NewTB)
            Me.Controls.Add(NewLB)
        Next
    End Sub
    Private Sub HandleTextChanged(sender As Object, e As EventArgs)
        ' MsgBox("Test")
    End Sub
    ' Write to the arduino to begin the test
    ' Sends a key depending on which test is running, 200 for contunity-test and 250 for shorts-test
    Private Sub writeSerial(ByVal data As Byte())
        SerialPort1.Open()
        If check_continunity Then
            Dim b() As Byte = New Byte() {200}
            SerialPort1.Write(b, 0, 1)
        End If
        If check_short Then
            Dim s() As Byte = New Byte() {250}
            SerialPort1.Write(s, 0, 1)
        End If
        ' send the amount of traces to test, e.g size of flexs
        SerialPort1.Write(data, 0, 1)
        SerialPort1.Close()
    End Sub
    ' Check if we should test for continuity
    ' If the button is clicked, we test for continuity 
    Private Sub check_continuity_CheckedChanged(sender As Object, e As EventArgs) Handles check_continuity.CheckedChanged
        If check_continunity <> True Then
            check_continunity = True
        Else
            check_continunity = False
        End If
    End Sub
    ' Check if we should test for shorts
    ' If the button is clicked, we test for shorts
    Private Sub check_shorts_CheckedChanged(sender As Object, e As EventArgs) Handles check_shorts.CheckedChanged
        If check_short <> True Then
            check_short = True
        Else
            check_short = False
        End If
    End Sub
    ' Poll for data from the serial port
    ' If we receive a 1, the pin passed
    ' If we receive a 0, the pin failed 
    Private Sub readSerial(ByRef pin_array)
        Dim count As Integer
        SerialPort1.Open()
        While True
            ' Poll for data until we recieve the stop bit
            Try
                Dim incoming As String = SerialPort1.ReadExisting()
                If incoming <> Nothing Then
                    If incoming >= 0 Then
                        pin_array(count) = incoming
                        count += 1
                    Else Exit While
                    End If
                End If
            Catch ex As InvalidOperationException
                MsgBox("Error: Serial Port read timed out.")
            End Try
        End While
        SerialPort1.Close()
    End Sub
    ' display all values from CTF test in MsgBox's, for now
    ' eventually add textboxes to populate
    Private Sub results_btn_Click(sender As Object, e As EventArgs) Handles results_btn.Click
        ' swap failing pins with -1 value to detect them
        'For Each i As Integer In pin_array
        'If i < 0 Then
        'i = -1
        'End If
        'Next
        ' Display and verify the passed\failed pins
        For Each value As Integer In globalArr
            MsgBox(value)
        Next

    End Sub
    Private Sub clearResults_Click(sender As Object, e As EventArgs) Handles clearResults.Click
        Me.Controls.RemoveByKey("TestLabel")
        For index As Integer = 1 To count
            Me.Controls.RemoveByKey("tbNew" & index)
            Me.Controls.RemoveByKey("labelNew" & index)
        Next
    End Sub

End Class
