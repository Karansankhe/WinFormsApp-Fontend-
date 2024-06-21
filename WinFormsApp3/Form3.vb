Imports System.IO
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class FormCreateSubmission
    Private stopwatch As New Stopwatch()
    Private ReadOnly dbFilePath As String = Path.Combine(Application.StartupPath, "db.json")

    Private Sub btnToggleStopwatch_Click(sender As Object, e As EventArgs) Handles btnToggleStopwatch.Click
        If stopwatch.IsRunning Then
            stopwatch.Stop()
        Else
            stopwatch.Start()
        End If
        UpdateStopwatchTime()
    End Sub

    Private Sub UpdateStopwatchTime()
        txtStopwatchTime.Text = stopwatch.Elapsed.ToString("hh\:mm\:ss")
    End Sub

    Private Async Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ' Create a new submission object
        Dim newSubmission As New Submission With {
            .SubmissionName = txtName.Text,
            .Email = txtEmail.Text,
            .PhoneNum = txtPhoneNum.Text,
            .GithubLink = txtGithubLink.Text,
            .StopwatchTime = txtStopwatchTime.Text
        }

        ' Save to server
        Await SaveSubmissionToServer(newSubmission)

        ' Save locally to db.json
        SaveSubmissionToLocalDb(newSubmission)

        ' Close the form or perform other actions
        Me.Close()
    End Sub

    Private Async Function SaveSubmissionToServer(submission As Submission) As Task
        Using httpClient As New HttpClient()
            Dim json As String = JsonConvert.SerializeObject(submission)
            Dim content As New StringContent(json, Encoding.UTF8, "application/json")
            Dim response As HttpResponseMessage = Await httpClient.PostAsync("http://localhost:3000/submit", content)
            response.EnsureSuccessStatusCode()
        End Using
    End Function

    Private Sub SaveSubmissionToLocalDb(submission As Submission)
        ' Ensure db.json exists
        EnsureDbFileExists()

        ' Read existing submissions from db.json
        Dim submissions As List(Of Submission) = LoadSubmissionsFromLocalDb()

        ' Add the new submission to the list
        submissions.Add(submission)

        ' Serialize the updated list to JSON
        Dim json As String = JsonConvert.SerializeObject(submissions, Formatting.Indented)

        ' Write to db.json file (overwrite existing content)
        File.WriteAllText(dbFilePath, json)
    End Sub

    Private Function LoadSubmissionsFromLocalDb() As List(Of Submission)
        ' Ensure db.json exists
        EnsureDbFileExists()

        Dim json As String = File.ReadAllText(dbFilePath)
        If String.IsNullOrWhiteSpace(json) Then
            Return New List(Of Submission)()
        Else
            Return JsonConvert.DeserializeObject(Of List(Of Submission))(json)
        End If
    End Function

    Private Sub EnsureDbFileExists()
        If Not File.Exists(dbFilePath) Then
            File.WriteAllText(dbFilePath, "[]")
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Control Or Keys.S) Then
            btnSubmit.PerformClick()
            Return True
        ElseIf keyData = (Keys.Control Or Keys.T) Then
            btnToggleStopwatch.PerformClick()
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
End Class


