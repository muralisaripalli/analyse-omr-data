Imports Excel = Microsoft.Office.Interop.Excel

Public Class EvaluateOMR

    Dim srcExcel As New Excel.Application
    Dim srcWB As Excel.Workbook
    Dim srcS As Excel.Worksheet

    Dim targetExcel As Excel.Application
    Dim targetWB As Excel.Workbook
    Dim targetS As Excel.Worksheet

    Dim fixedMsg As String

    Dim fileName As String
    Dim totOMR, totQ As Int16

    Dim startOMR, endOMR As Int16
    Dim currentRow As Int16
    Dim r As New List(Of String)
    Dim w As New List(Of String)
    Dim u As New List(Of String)
    Dim b As New List(Of String)
    Dim targetRow = 2

    Private Sub AnalyseOMR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnAnalyse.Visible = False
        rangeSelection.Visible = False
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        fixedMsg = ""
        totOMR = 0
        totQ = 0

        Dim browseFile As New OpenFileDialog()
        browseFile.Filter = "Excel files (*.xls, *.xlsx)|*.xls;*.xlsx"

        If browseFile.ShowDialog() =
            DialogResult.OK Then
            If Dir(browseFile.FileName) <> "" Then
                fileName = browseFile.FileName

                ShowMessage("Loading " & fileName)
                btnBrowse.Visible = False

                srcWB = srcExcel.Workbooks.Open(fileName)
                srcS = srcWB.Worksheets(1)
                FixMessage(fileName & " Loaded")

                'Counting total questions ==>
                ShowMessage("Counting questions..")
                Dim row = 1, column = 2
                While Not String.IsNullOrEmpty(srcS.Cells(row, column).Value)
                    totQ = totQ + 1
                    column = column + 1
                End While
                FixMessage("Total questions: " & totQ)
                '<== Counting total questions

                'Counting total OMRs ==>
                ShowMessage("Counting OMRs..")
                row = 2
                column = 1
                While Not String.IsNullOrEmpty(srcS.Cells(row, column).Value)
                    totOMR = totOMR + 1
                    row = row + 1
                End While
                FixMessage("Total OMRs: " & totOMR)
                '<== Counting total OMRs

                fromOMR.Text = 1
                toOMR.Text = totOMR
                rangeSelection.Visible = True
                ShowMessage("Change From and To values if required and click Evaluate to continue")
                btnAnalyse.Visible = True
            Else
                ShowMessage("File not found")
            End If
        End If
    End Sub

    Private Sub AnalyseOMR_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        srcExcel.Quit()
    End Sub

    Private Function IsValidEntry() As Boolean
        If IsNumeric(fromOMR.Text) And IsNumeric(toOMR.Text) Then
            startOMR = fromOMR.Text
            endOMR = toOMR.Text

            If startOMR <= 0 Or endOMR > totOMR Or startOMR > endOMR Then
                MessageBox.Show("Enter numbers in valid range")
                Return False
            End If
        Else
            MessageBox.Show("Enter valid numbers")
            Return False
        End If
        Return True
    End Function

    Private Sub btnAnalyse_Click(sender As Object, e As EventArgs) Handles btnAnalyse.Click
        If Not IsValidEntry() Then
            Return
        End If

        rangeSelection.Visible = False
        btnAnalyse.Visible = False

        'Generating Excel Template
        ShowMessage("Generating excel template")
        targetExcel = CreateObject("Excel.Application")
        targetWB = targetExcel.Workbooks.Add()
        targetS = targetWB.Sheets.Add()
        targetExcel.DisplayAlerts = False
        targetS.Cells(1, 1).Value = "OMR NO"
        targetS.Cells(1, 2).Value = "R"
        targetS.Cells(1, 3).Value = "W"
        targetS.Cells(1, 4).Value = "U"

        currentRow = startOMR + 1
        targetRow = 2
        Timer1.Start()
    End Sub

    Private Sub saveExcel()
        targetS.Columns("A:E").AutoFit()

        ' Showing save file dialog
        Dim saveFile As New SaveFileDialog()
        saveFile.DefaultExt = "xls"
        saveFile.AddExtension = True
        If startOMR = 1 And endOMR = totOMR Then
            saveFile.FileName = "Analysis_" & System.IO.Path.GetFileName(fileName)
        Else
            saveFile.FileName = "Analysis(" & startOMR & "-" & endOMR & ")_" & System.IO.Path.GetFileName(fileName)
        End If
        saveFile.Title = "Save the analysed file"
        If saveFile.ShowDialog <> 2 Then
            fileName = saveFile.FileName
            ShowMessage("Saving..")
            targetWB.SaveAs(fileName)
            targetExcel.Quit()
            FixMessage("Analysed file saved To " & fileName)
        Else
            FixMessage("Invalid save path")
        End If

        srcExcel.Quit()
        ShowMessage("Browse to start again")
        btnBrowse.Visible = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Dim omrNum = srcS.Cells(currentRow, 1).Value
        ShowMessage("Evaluating OMR " & (currentRow - 1) & "/" & totOMR & "(" & omrNum & ")")
        targetS.Cells(targetRow, 1).Value = omrNum
        For column = 2 To totQ + 1
            Dim qResult = LCase(srcS.Cells(currentRow, column).Value)
            Dim qNum = srcS.Cells(1, column).Value
            If qResult = "r" Then
                r.Add(qNum)
            ElseIf qResult = "w" Then
                w.Add(qNum)
            ElseIf qResult = "u" Then
                u.Add(qNum)
            Else
                b.Add(qNum)
            End If
        Next
        targetS.Cells(targetRow, 2).Value = String.Join(",", r)
        targetS.Cells(targetRow, 3).Value = String.Join(",", w)
        targetS.Cells(targetRow, 4).Value = String.Join(",", u)
        targetS.Cells(targetRow, 5).Value = String.Join(",", b)
        r.Clear()
        w.Clear()
        u.Clear()
        b.Clear()
        targetRow = targetRow + 1
        currentRow = currentRow + 1
        If currentRow > endOMR + 1 Then
            saveExcel()
        Else
            Timer1.Start()
        End If
    End Sub

    Private Sub ShowMessage(msg As String)
        statusMsg.Text = fixedMsg & vbNewLine & msg
    End Sub

    Private Sub FixMessage(msg As String)
        fixedMsg = fixedMsg & msg & vbNewLine
        statusMsg.Text = fixedMsg
    End Sub

End Class

